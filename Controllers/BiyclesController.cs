using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppBaslangc;
using WebAppBaslangc.Models;

namespace WebAppBaslangc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BiyclesController : Controller
    {
        private readonly AppDbContext _context;

        public BiyclesController(AppDbContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            return View(await _context.bicyles.ToListAsync());
        }
         
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biycle = await _context.bicyles
                .FirstOrDefaultAsync(m => m.ıd == id);
            if (biycle == null)
            {
                return NotFound();
            }

            return View(biycle);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ıd,brand,model,year,type,price,color,ImageFileName")] Biycle biycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biycle);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biycle = await _context.bicyles.FindAsync(id);
            if (biycle == null)
            {
                return NotFound();
            }
            return View(biycle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ıd,brand,model,year,type,price,color,ImageFileName")] Biycle biycle)
        {
            if (id != biycle.ıd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biycle);
                    biycle.UpdatedDate = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiycleExists(biycle.ıd))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(biycle);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biycle = await _context.bicyles
                .FirstOrDefaultAsync(m => m.ıd == id);
            if (biycle == null)
            {
                return NotFound();
            }

            return View(biycle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biycle = await _context.bicyles.FindAsync(id);

            if (biycle != null)
            {
                biycle.IsDeleted = true;
                biycle.DeletedDate = DateTime.UtcNow;
                biycle.UpdatedDate = DateTime.UtcNow;

                _context.bicyles.Update(biycle);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BiycleExists(int id)
        {
            return _context.bicyles.Any(e => e.ıd == id);
        }
    }
}



//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var biycle = await _context.bicyles
//                .FirstOrDefaultAsync(m => m.ıd == id);
//            if (biycle == null)
//            {
//                return NotFound();
//            }

//            return View(biycle);
//        }


//        public IActionResult Create()
//        {
//            return View();
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ıd,brand,model,year,type,price,color,ImageFileName")] Biycle biycle)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(biycle);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(biycle);
//        }


//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var biycle = await _context.bicyles.FindAsync(id);
//            if (biycle == null)
//            {
//                return NotFound();
//            }
//            return View(biycle);

//        }
//        [Route("bicyles/{brand?}")]
//        public IActionResult List(string brand = "all")
//        {
//            List<Biycle> bicyles;
//            if (brand.Equals("all"))
//            {
//                bicyles = _context.bicyles.ToList();
//            }
//            else
//            {
//                bicyles = _context.bicyles.Where(b => b.brand == brand).ToList();
//            }
//            return View(bicyles);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ıd,brand,model,year,type,price,color,ImageFileName")] Biycle biycle)
//        {
//            if (id != biycle.ıd)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(biycle);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!BiycleExists(biycle.ıd))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(biycle);
//        }

//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var biycle = await _context.bicyles
//                .FirstOrDefaultAsync(m => m.ıd == id);
//            if (biycle == null)
//            {
//                return NotFound();
//            }

//            return View(biycle);
//        }


//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            //var biycle = await _context.bicyles.FindAsync(id);
//            //if (biycle != null)
//            //{
//            //    _context.bicyles.Remove(biycle);
//            //}

//            //await _context.SaveChangesAsync();
//            //return RedirectToAction(nameof(Index));
//            var biycle = await _context.bicyles.SingleOrDefaultAsync(u => u.ıd== id);


//            biycle.IsDeleted = true;
//            biycle.DeletedDate = DateTime.UtcNow;
//            biycle.UpdatedDate = DateTime.UtcNow;

//            _context.bicyles.Update(biycle);


//                await _context.SaveChangesAsync();




//            return RedirectToAction("Index");
//        }

//        private bool BiycleExists(int id)
//        {
//            return _context.bicyles.Any(e => e.ıd == id);
//        }

//    }
//}
