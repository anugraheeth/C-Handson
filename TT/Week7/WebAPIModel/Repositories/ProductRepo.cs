using WebAPIModel.Model;
namespace WebAPIModel.Repositories
{
    public interface IProductRepo
    {
        // Define methods for the product repository
        void AddProduct(Product product);
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
    public class ProductRepo : IProductRepo
    {
        private static  List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 1200.00, Stock = 10 },
            new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 800.00, Stock = 20 },
            new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 150.00, Stock = 30 }
        };


        //[FromBody] is not used here as we are not using ASP.NET Core's model binding in this repository class.
        //the parameter is expected to be passed directly when calling the method.
        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _products.Add(product);
        }
        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public void UpdateProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var existingProduct = GetProduct(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
            }
        }

        public void DeleteProduct(int id)
        {
            var product = GetProduct(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
