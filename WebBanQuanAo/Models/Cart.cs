namespace WebBanQuanAo.Models
{
    public class Cart
    {
        public int MaSP { get; set; }
        public virtual SanPham SanPham { get; set; }
        public int Quantity { get; set; }
        //public DateTime NgayMua { get; set; }
        public int MaDonHang { get; set; }
        public Cart()
        {

        }
        public Cart(SanPham sanPham, int quantity)
        {
            this.SanPham = sanPham;
            this.Quantity = quantity;
        }
        public Cart(SanPham sanPham, int quantity, int maDH)
        {
            this.SanPham = sanPham;
            this.Quantity = quantity;
            this.MaDonHang = maDH;
        }
    }
}