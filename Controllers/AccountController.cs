using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAppBaslangc.Entities;
using WebAppBaslangc.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebAppBaslngc.Models;

namespace WebAppBaslangc.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AccountController> _logger;

        // ILogger'ı dependency injection ile alıyoruz
        public AccountController(AppDbContext appDbcontext, ILogger<AccountController> logger)
        {
            _context = appDbcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_context.UsersA.ToList());
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.UsersA
                    .Where(x => (x.userName == model.userNameOrEmail || x.eMail == model.userNameOrEmail) &&
                                 x.password == model.password) 
                    .FirstOrDefaultAsync();

                if (user != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(ClaimTypes.Email, user.eMail),
                new Claim(ClaimTypes.Role, user.Role)
            };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("SecurePage");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username/Email or Password");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); 
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            
            _logger.LogInformation("Admin paneli görüntüleniyor.");
            var users = _context.UsersA.ToList();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUserByEmail = await _context.UsersA
                    .SingleOrDefaultAsync(u => u.eMail == model.eMail);
                var existingUserByUsername = await _context.UsersA
                    .SingleOrDefaultAsync(u => u.userName == model.userName);

                if (existingUserByEmail != null || existingUserByUsername != null)
                {
                    _logger.LogWarning("Kayıt işlemi başarısız: Benzersiz email veya kullanıcı adı gerekli.");
                    ModelState.AddModelError("", "Please enter a unique Email or Username");
                    return View(model);
                }

                var account = new UsersA
                {
                    eMail = model.eMail,
                    userName = model.userName,
                    password = model.password,
                    CreatedDate = DateTime.UtcNow
                };

                _context.UsersA.Add(account);
                try
                {
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Yeni kullanıcı kaydedildi: {account.userName}");

                    ModelState.Clear();
                    ViewBag.Message = $"{account.userName} registered successfully. Please login.";
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "Kayıt işlemi sırasında hata oluştu.");
                    ModelState.AddModelError("", "Error occurred while registering. Please try again.");
                    return View(model);
                }
                return View();
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(string userName)
        {
            var user = _context.UsersA.SingleOrDefault(u => u.userName == userName);
            if (user == null)
            {
                _logger.LogWarning($"Silme işlemi başarısız: {userName} bulunamadı.");
                return NotFound();
            }

            _logger.LogInformation($"Kullanıcı silme işlemi başlatıldı: {userName}");
            return View(user); 
        }

        [HttpPost, ActionName("DeleteUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string userName)
        {
            var user = await _context.UsersA.SingleOrDefaultAsync(u => u.userName == userName);
            if (user == null)
            {
                _logger.LogWarning($"Silme işlemi başarısız: {userName} bulunamadı.");
                return NotFound();
            }

            user.IsDeleted = true;
            user.DeletedDate = DateTime.UtcNow;
            user.UpdatedDate = DateTime.UtcNow;

            _context.UsersA.Update(user);
            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Kullanıcı silindi (soft delete): {userName}");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Kullanıcı silme işlemi sırasında hata oluştu: {userName}");
            }

            return RedirectToAction("AdminPanel");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUser(string userName)
        {
            var user = await _context.UsersA.SingleOrDefaultAsync(u => u.userName == userName);
            if (user == null)
            {
                return NotFound(); 
            }

            var model = new EditUserViewModel
            {
                userId = user.userId,
                userName = user.userName,
                eMail = user.eMail,
                Role = user.Role
            };

            return View(model); 
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.UsersA.SingleOrDefaultAsync(u => u.userName == model.userName);
                if (user != null)
                {
                    user.Role = model.Role; 
                    user.eMail = model.eMail; 

                    _context.UsersA.Update(user); 
                    user.UpdatedDate = DateTime.UtcNow;
                    try
                    {
                        await _context.SaveChangesAsync(); 
                        return RedirectToAction("AdminPanel");
                    }
                    catch (DbUpdateException ex)
                    {
                        
                        _logger.LogError(ex, "Kullanıcı rolünü güncellerken hata oluştu.");
                        ModelState.AddModelError("", "Kullanıcı rolü güncellenirken bir hata oluştu. Lütfen tekrar deneyin.");
                    }

                  
                   
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                }
            }
            return View(model); 
        }



        [Authorize]
        public IActionResult SecurePage()
        {
            return View();
        }
    }
}
