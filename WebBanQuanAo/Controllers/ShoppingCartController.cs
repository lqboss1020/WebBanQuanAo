using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class ShoppingCartController : Controller
    {
        private WebQA2Entities db = new WebQA2Entities();
        string sCart = "Cart";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Del(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int check = isExistingCheck(id);
            var Carts = (List<Cart>)Session[sCart];
            Carts.RemoveAt(check);
            return View("index");
        }
        public ActionResult Clear()
        {
            Session.Remove(sCart);
            return RedirectToAction("list", "SanPhams");
        }
        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                if (Session[sCart] == null)
                {
                    List<Cart> Carts = new List<Cart>
                    {
                       new Cart(db.SanPhams.Find(id),1)
                    };
                    Session[sCart] = Carts;
                }
                else
                {
                    var Cart = (List<Cart>)Session[sCart];
                    int check = isExistingCheck(id);
                    if (check == -1)
                    {
                        Cart.Add(new Cart(db.SanPhams.Find(id), 1));
                    }
                    else
                    {
                        Cart[check].Quantity++;
                    }
                    Session[sCart] = Cart;
                }
                return RedirectToAction("index");
            }
        }
        private int isExistingCheck(int? id)
        {
            List<Cart> Carts = Session[sCart] as List<Cart>;
            for (int i = 0; i < Carts.Count; i++)
            {
                if (Carts[i].SanPham.MaSP == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}