using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class ShoppingCartController : Controller
    {
        private WebQA2Entities db = new WebQA2Entities();
        string scart = "Cart";
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
            var carts = (List<Cart>)Session[scart];
            carts.RemoveAt(check);
            return View("index");
        }
        public ActionResult Clear()
        {
            Session.Remove(scart);
            return RedirectToAction("list","SanPhams");
        }
        public ActionResult Order(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                if (Session[scart]==null)
                {
                    List<Cart> carts = new List<Cart>
                    {
                       new Cart(db.SanPhams.Find(id),1)
                    };
                    Session[scart] = carts;
                }
                else
                {
                    var cart =(List<Cart>) Session[scart];
                    int check = isExistingCheck(id);
                    if (check == -1)
                    {
                        cart.Add(new Cart(db.SanPhams.Find(id), 1));
                    }
                    else
                    {
                        cart[check].Quantity++;
                    } 
                    Session[scart] = cart;
                }
                return RedirectToAction("index");
            }
        }
        private int isExistingCheck(int? id)
        {
            List<Cart> carts = Session[scart] as List<Cart>;
            for (int i = 0; i < carts.Count; i++)
            {
                if (carts[i].SanPham.MaSP==id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}