using System.Collections.Generic;
using App.Models;

namespace App.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() {Id = 1, Name = "Iphone X", Price = 10000},
                new ProductModel() {Id = 2, Name = "Samsung", Price = 500},
                new ProductModel() {Id = 3, Name = "Sony xyz", Price = 400},
                new ProductModel() {Id = 4, Name = "Nokia X", Price = 800}
            });
        }
    }
}