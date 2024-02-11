
namespace MyDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // Create
                var product = new Product { Name = "New Product", Price = 9.99m };
                context.Products.Add(product);
                context.SaveChanges();

                // Read
                var products = context.Products.ToList();
                foreach (var p in products)
                {
                    Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}");
                }

                // Update
                var productToUpdate = context.Products.FirstOrDefault();
                if (productToUpdate != null)
                {
                    productToUpdate.Price = 19.99m;
                    context.SaveChanges();
                }

                // Delete
                var productToDelete = context.Products.FirstOrDefault(p => p.Name == "New Product");
                if (productToDelete != null)
                {
                    context.Products.Remove(productToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
