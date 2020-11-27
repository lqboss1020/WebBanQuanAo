using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanQuanAo.Models
{
    public class Cart
    {
        public SanPham SanPham { get; set; }
        public int Quantity { get; set; }
        public Cart()
        {

        }
        public Cart(SanPham sanPham,int quantity)
        {
            this.SanPham = sanPham;
            this.Quantity = quantity;
        }
    }
}