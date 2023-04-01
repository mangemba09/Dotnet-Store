// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


void Display()
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Tambah Produk");
    Console.WriteLine("2. Edit Produk");
    Console.WriteLine("3. Tampilkan Produk");
    Console.WriteLine("4. Hapus Produk");
    Console.WriteLine("5. Add produk ke Cart");
    Console.WriteLine("6. Hapus produk dari Cart");
    Console.WriteLine("7. Tampilkan Cart");
    Console.WriteLine("8. Checkout");
    Console.WriteLine("9. Keluar");
    Console.WriteLine("Pilihan ? : ");
}
var keluar = false;
var produk = new List<Produk>();
var cart = new List<Cart>();
while (!keluar)
{
    Display();
    var pilihan = Console.ReadLine();
    switch (pilihan)
    {
        case "1": //tambah produk
            Console.Write("Masukkan SKU: ");
            string sku = Console.ReadLine();

            Console.Write("Masukkan Nama: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan Stock: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Masukkan Harga: ");
            double harga = double.Parse(Console.ReadLine());

            var newProduk = new Produk(sku, nama, stock, harga);
            produk.Add(newProduk);

            Console.WriteLine("Produk berhasil ditambahkan!");
            break;
        case "2": //edit produk
            Console.Write("Masukkan SKU produk yang akan diubah: ");
            string skuUbah = Console.ReadLine();

            var produkToUpdate = produk.Find(p => p.Sku == skuUbah);
            if (produkToUpdate != null)
            {
                Console.Write("Masukkan Nama: ");
                produkToUpdate.Nama = Console.ReadLine();

                Console.Write("Masukkan Stock: ");
                produkToUpdate.Stock = int.Parse(Console.ReadLine());

                Console.Write("Masukkan Harga: ");
                produkToUpdate.Harga = double.Parse(Console.ReadLine());

                Console.WriteLine("Produk berhasil diubah!");
            }
            else
            {
                Console.WriteLine("Produk tidak ditemukan!");
            }
            break;
        case "3": //tampilkan produk
            Console.WriteLine("Daftar Produk");
            Console.WriteLine("=======================");
            if (produk.Count > 0)
            {
                foreach (var item in produk)
                {
                    Console.WriteLine("SKU : {0}", item.Sku);
                    Console.WriteLine("Nama : {0}", item.Nama);
                    Console.WriteLine("Stock : {0}", item.Stock);
                    Console.WriteLine("Harga : {0}", item.Harga);
                    Console.WriteLine("=======================");            
                }
            }
            else
            {
                Console.WriteLine("Tidak ada produk");
            }
            break;
        case "4": //hapus produk
            if (produk.Count == 0) 
            {
                Console.WriteLine("Belum ada produk yang ditambahkan");
                break;
            }
            Console.Write("Masukkan SKU produk yang akan dihapus: ");
            string skuHapus = Console.ReadLine();
            bool produkDitemukan = false;
            foreach (Produk p in produk) 
            {
                if (p.Sku == skuHapus) 
                {
                produkDitemukan = true;
                produk.Remove(p);
                Console.WriteLine($"Produk dengan SKU {skuHapus} telah dihapus");
                break;
                }
            }
            if (!produkDitemukan) 
            {
                Console.WriteLine($"Produk dengan SKU {skuHapus} tidak ditemukan");
            }
            Console.ReadLine();
            break;
        case "5": //add produk ke cart
            Console.Write("Masukkan SKU produk yang ingin ditambahkan ke Cart: ");
            string skuAddToCart = Console.ReadLine();
            var produkToAddToCart = produk.Find(p => p.Sku == skuAddToCart);
            if (produkToAddToCart != null)
            {
                Console.Write("Masukkan jumlah produk yang ingin ditambahkan ke Cart: ");
                int qty = int.Parse(Console.ReadLine());
                if (produkToAddToCart.Stock >= qty)
                {
                    var cartItem = new Cart(produkToAddToCart.Sku, produkToAddToCart.Nama, qty, produkToAddToCart.Harga);
                    cart.Add(cartItem);
                    produkToAddToCart.Stock -= qty;

                    Console.WriteLine("Produk berhasil ditambahkan ke Cart!");
                }
                else
                {
                    Console.WriteLine("Jumlah produk yang diminta melebihi stock yang tersedia!");
                }
            }
            else
            {
                Console.WriteLine("Produk tidak ditemukan!");
            }
            break;
        case "6": //hapus produk dari cart
            Console.Write("Masukkan SKU produk yang ingin dihapus dari Cart: ");
            string skuRemoveFromCart = Console.ReadLine();
            var cartItemToRemove = cart.Find(c => c.Sku == skuRemoveFromCart);
            if (cartItemToRemove != null)
            {
                produk.Find(p => p.Sku == cartItemToRemove.Sku).Stock += cartItemToRemove.Quantity;
                cart.Remove(cartItemToRemove);
                Console.WriteLine("Produk berhasil dihapus dari Cart!");
            }
            else
            {
                Console.WriteLine("Produk tidak ditemukan di Cart!");
            }
            break;
        case "7": //tampilkan cart
            double Total = 0;
            Console.WriteLine("Daftar Produk di Cart");
            Console.WriteLine("=======================");
            if (cart.Count > 0)
            {
                foreach (var item in cart)
                {
                    Console.WriteLine("SKU : {0}", item.Sku);
                    Console.WriteLine("Nama : {0}", item.Nama);
                    Console.WriteLine("Qty : {0}", item.Quantity);
                    Console.WriteLine("Harga : {0}", item.Harga);
                    Console.WriteLine("=======================");
                    Total += item.Quantity * item.Harga;
                }
                Console.WriteLine("Total : {0}", Total);
            }
            else
            {
                Console.WriteLine("Cart kosong!");
            }
            break;
        case "8":
            double total = 0;
            Console.WriteLine("Menu Checkout:");
            Console.WriteLine("1. Checkout semua produk di cart");
            Console.WriteLine("2. Checkout satu produk dari cart");
            Console.Write("Pilihan? ");
            string checkoutMenuOption = Console.ReadLine();
            if (checkoutMenuOption == "1")
            {
                Console.WriteLine("Daftar Produk di Cart");
                Console.WriteLine("=======================");
                if (cart.Count > 0)
                {
                    foreach (var item in cart)
                    {
                        Console.WriteLine("Nama : {0}", item.Nama);
                        Console.WriteLine("Qty : {0}", item.Quantity);
                        Console.WriteLine("Harga : {0}", item.Harga);
                        Console.WriteLine("=======================");
                        total += item.Quantity * item.Harga;
                    }

                    Console.WriteLine("Total : {0}", total);
                    Console.WriteLine("Bayar atau Cancel?");
                    string checkoutOption = Console.ReadLine();
                    if (checkoutOption.ToLower() == "bayar")
                    {
                        cart.Clear();
                        Console.WriteLine("Pembayaran berhasil, terima kasih telah berbelanja!");
                    }
                    else
                    {
                        Console.WriteLine("Pembayaran dibatalkan");
                    }
                }
                else
                {
                    Console.WriteLine("Cart kosong!");
                }
            }
            else if (checkoutMenuOption == "2")
            {
                if (cart.Count > 0)
                {
                    Console.WriteLine("Daftar Produk di Cart");
                    Console.WriteLine("=======================");
                    for (int i = 0; i < cart.Count; i++)
                    {
                        Console.WriteLine("{0}. Nama : {1}, Qty : {2}, Harga : {3}", i+1, cart[i].Nama, cart[i].Quantity, cart[i].Harga);
                    }
                    Console.Write("Pilih produk yang ingin di checkout: ");
                    int checkoutIndex = int.Parse(Console.ReadLine()) - 1;
                    if (checkoutIndex >= 0 && checkoutIndex < cart.Count)
                    {
                        var checkoutItem = cart[checkoutIndex];
                        Console.WriteLine("Anda akan membeli:");
                        Console.WriteLine("Nama : {0}", checkoutItem.Nama);
                        Console.WriteLine("Qty : {0}", checkoutItem.Quantity);
                        Console.WriteLine("Harga : {0}", checkoutItem.Harga);
                        Console.WriteLine("Total : {0}", checkoutItem.Quantity * checkoutItem.Harga);
                        Console.WriteLine("Bayar atau Cancel?");
                        string checkoutOption = Console.ReadLine();
                        if (checkoutOption.ToLower() == "bayar")
                        {
                            cart.RemoveAt(checkoutIndex);
                            Console.WriteLine("Pembayaran berhasil, terima kasih telah berbelanja!");
                        }
                        else
                        {
                            Console.WriteLine("Pembayaran dibatalkan");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Produk tidak ditemukan.");
                    }
                }
                else
                {
                    Console.WriteLine("Cart kosong!");
                }
            }
            break;
        case "9": //keluar
            keluar = true;
            break;
        default:
            Console.WriteLine("Pilihan tidak tersedia");
            break; 
    }
}
