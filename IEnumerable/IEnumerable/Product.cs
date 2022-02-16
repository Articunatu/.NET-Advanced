using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IEnumerable
{
    public class Product
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public Product(string name, bool isActive)
        {
            this.Name = name;
            this.IsActive = isActive;
        }
        
        public void Dis(int amount)
        {
            Console.WriteLine("Produkten {0} har en rabatt på {1}%.", Name, amount);
        }
    }

    public class ProductStorage : IEnumerable<Product>
    {
        public List<Product> products;
        public ProductStorage()
        {
            products = new List<Product>()
            {
                new Product("Omen", true),
                new Product("Asus", true),
                new Product("Mac", false),
                new Product("Samsung", false),
                new Product("MSI", false),
            };
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return ((IEnumerable<Product>)products).GetEnumerator();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)products).GetEnumerator();
        }
    }
}
