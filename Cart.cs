public class Cart
{
    public string Sku { get; set; }
    public string Nama { get; set; }
    public int Quantity { get; set; }
    public double Harga { get; set; }

    public Cart(string sku, string nama, int quantity, double harga)
    {
        Sku = sku;
        Nama = nama;
        Quantity = quantity;
        Harga = harga;
    }
}