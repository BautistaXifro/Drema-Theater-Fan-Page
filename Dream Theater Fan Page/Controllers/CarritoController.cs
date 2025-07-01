using BuildShoppingCart.Helpers;
using Dream_Theater_Fan_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Theater_Fan_Page.Controllers
{
    public class CarritoController : Controller
    {
        private readonly DreamTheaterFanPageContext _Context;

        public List<Producto> Products = new List<Producto>();
        public List<Item> Mycart = new List<Item>();

        public CarritoController(DreamTheaterFanPageContext context)
        {
            _Context = context;
        }
        public IActionResult Index(string searchName = "", decimal? minPrice = null, decimal? maxPrice = null)
        {
            int cantidad = 0;
            var carrito = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (carrito != null) cantidad = carrito.Count();
            ViewBag.Contar = cantidad;

            var productsQuery = _Context.Productos.AsQueryable();
            // filtro por nombre
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                productsQuery = productsQuery.Where(p => p.Nombre.Contains(searchName));
            }
            // filtro por precio mínimo
            if (minPrice != null)
            {
                productsQuery = productsQuery.Where(p => p.Precio >= minPrice.Value);
            }
            // filtro por precio máximo
            if (maxPrice != null)
            {
                productsQuery = productsQuery.Where(p => p.Precio <= maxPrice.Value);
            }
            Products = productsQuery.ToList();
            return View(Products);
        }

        public IActionResult CarritoCompras()
        {
            var MyCart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (MyCart == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(MyCart);
            }

        }
        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Producto.ProductoId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        [HttpGet]
        public IActionResult Quitar(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            int index = Exists(cart, id);
            cart.RemoveAt(index);

            @ViewBag.Contar = cart.Count();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("CarritoCompras");
        }

        [HttpGet]
        public IActionResult Cart(int id)
        {
            var product = _Context.Productos.Find(id);
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item()
                {
                    Producto = product,
                    Cantidad = 1
                });

                @ViewBag.Contar = cart.Count();

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item()
                    {
                        Producto = product,
                        Cantidad = 1
                    });
                }
                else
                {
                    cart[index].Cantidad += 1;
                }

                @ViewBag.Contar = cart.Count();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("CarritoCompras");
        }
    }
}
