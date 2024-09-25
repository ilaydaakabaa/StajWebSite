using Microsoft.AspNetCore.Mvc;
using WebAppBaslangc.Models;

namespace WebAppBaslangc.Controllers
{
    public class ShoppingCartController : Controller
    {
        private static ShoppingCardViewModel cart = new ShoppingCardViewModel
        {
            cardItems = new List<ShoppingCardItem>(),
            totalPrice = 0,
            totalQuantity = 0
        };

        public IActionResult Index()
        {
            return View(cart);
        }
        public IActionResult ViewCart()
        {
            return View(cart); 
        }
        [HttpPost]
        public IActionResult AddToCart(int id, string brand, string model, decimal price)
        {
            var item = cart.cardItems.FirstOrDefault(i => i.ıd == id);

            if (item == null)
            {
                cart.cardItems.Add(new ShoppingCardItem
                {
                    ıd = id,
                    brand = brand,
                    model = model,
                    price = price,
                    quantity = 1
                });
            }
            else
            {
                item.quantity++;
            }

            UpdateCartTotals();

            return Json(new { success = true, redirectUrl = Url.Action("ViewCart", "ShoppingCart") });
        }

        public IActionResult RemoveItem(int id)
        {
            // Sepetteki öğeyi bul ve kaldır
            var item = cart.cardItems.FirstOrDefault(i => i.ıd == id);
            if (item != null)
            {
                cart.cardItems.Remove(item);

                // Sepet toplamlarını güncelle
                UpdateCartTotals();
            }

            // Sepet sayfasına yönlendir
            return RedirectToAction("ViewCart");
        }

        private void UpdateCartTotals()
        {
            cart.totalPrice = cart.cardItems.Sum(i => i.price * i.quantity);
            cart.totalQuantity = cart.cardItems.Sum(i => i.quantity);
        }
    }
}
