using ShopForBussiness.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ShopForBussiness.Domain
{
    public class Cart
    {
        public List<(ProductDto product, int count)> ProductsList { get; private set; }
        public Cart()
        {
            ProductsList = new List<(ProductDto product, int count)>();
        }
        public void Add(ProductDto product, int count=1)
        {
            if(ProductsList.Any(x=>x.product.ID==product.ID))
            {
                ProductsList = ProductsList.Select(x =>
                {
                    if (x.product.ID == product.ID) x.count++;
                    return x;
                }).ToList();
            }
            else
            {
                ProductsList.Add((product, count));
            }
        }

        public int GetSum()
        {
            return ProductsList.Sum(x => x.count);
        }
    }
}