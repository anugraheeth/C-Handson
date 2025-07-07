using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapperproduct.Model;
namespace Dapperproduct.Model
{
    public class ProductService
    {
        public List<Product> getAllProducts()
        {
            DbHelper hp = new DbHelper();
            using (IDbConnection connection = hp.GetDbConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM product";
                List<Product> products = connection.Query<Product>(sql).AsList();

                return products;
            }

        }

        public Product getProductById(int id)
        {
            DbHelper hp = new DbHelper();
            using (IDbConnection connection = hp.GetDbConnection())
            {
                connection.Open();
                string query = "select * from product where id =@id";
                Product p = connection.QueryFirstOrDefault<Product>(query, new { id = id });
                return p;
            }
        }

        public void addProduct(Product product)
        {
            DbHelper hp = new DbHelper();
            using (IDbConnection connection = hp.GetDbConnection())
            {
                connection.Open();
                string query = "INSERT INTO product (Id ,Name, Price) VALUES (@Id, @Name, @Price)";
                connection.Execute(query, product);
            }
        }

        public bool delProduct(int id)
        {
            DbHelper hp = new DbHelper();
            using (IDbConnection connection = hp.GetDbConnection())
            {
                connection.Open();
                string query = "delete from product where id= @id";
                int rowaffected =  connection.Execute(query, new { id = id});
                return rowaffected>0;
            }
        }

        public bool upProduct(int id, double price)
        {
            DbHelper hp = new DbHelper();
            using(IDbConnection connection = hp.GetDbConnection())
            {
                connection.Open();
                string query = "update product set price = @price where id =@id";
               int rowaffected = connection.Execute(query, new {price = price, id=id});

                return rowaffected>0;
            }
        }
    }
}

