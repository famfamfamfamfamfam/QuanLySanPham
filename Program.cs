namespace QUANLYSANPHAM
{
class Program
{
    static string filePath = @"C:\Users\pc\Desktop\Module1\BaiTap\products.txt";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Chon mot tuy chon:");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Hien thi san pham");
            Console.WriteLine("3. Tim kiem san pham");
            Console.WriteLine("4. Thoat");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    DisplayProducts();
                    break;
                case "3":
                    SearchProduct();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Khong hop le");
                    break;
            }
        }
    }

    static void AddProduct()
    {
        var product = new Product();

        Console.Write("Nhap ma san pham: ");
        product.Id = Console.ReadLine();

        Console.Write("Nhap ten san pham: ");
        product.Name = Console.ReadLine();

        Console.Write("Nhap hang san xuat: ");
        product.Manufacturer = Console.ReadLine();

        Console.Write("Nhap gia san pham: ");
        product.Price = decimal.Parse(Console.ReadLine());

        Console.Write("Mo ta khac: ");
        product.Description = Console.ReadLine();

        File.AppendAllText(filePath, product.ToString() + Environment.NewLine);
        Console.WriteLine("Da Them San Pham");
    }

    static void DisplayProducts()
    {
        if (File.Exists(filePath))
        {
            var products = File.ReadAllLines(filePath);
            Console.WriteLine("Danh sach san pham:");
            foreach (var line in products)
            {
                var product = Product.FromString(line);
                Console.WriteLine($"Ma: {product.Id}, Ten: {product.Name}, Hang: {product.Manufacturer}, Gia: {product.Price}, Ghi chu: {product.Description}");
            }
        }
        else
        {
            Console.WriteLine("Chua them san pham nao");
        }
    }

    static void SearchProduct()
    {
        Console.Write("Nhap ma san pham: ");
        var searchId = Console.ReadLine();
        
        if (File.Exists(filePath))
        {
            var products = File.ReadAllLines(filePath);
            foreach (var line in products)
            {
                var product = Product.FromString(line);
                if (product.Id.Equals(searchId, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Ma: {product.Id}, Ten: {product.Name}, Hang: {product.Manufacturer}, Gia: {product.Price}, Ghi chu: {product.Description}");
                    return;
                }
            }
            Console.WriteLine("Khong tim thay san pham");
        }
        else
        {
            Console.WriteLine("Hien chua co san pham");
        }
    }
}
}