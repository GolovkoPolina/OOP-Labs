using System;
using System.Collections.Generic;

namespace laba1Nikitin
{
    internal class Warehouse
    {
        private readonly Product[] products;
        private int count;

        public Warehouse(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Вместимость должна быть больше нуля");
            products = new Product[capacity];
            count = 0;
        }

        public void DoseProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (count >= products.Length)
                throw new InvalidOperationException("Склад переполнен");
            if (FindByArticle(product.Article) != null)
                throw new InvalidOperationException("Товар с таким артикулом уже есть на складе");
            products[count] = product;
            count++;
        }

        public Product? FindByArticle(string article)
        {
            for (int i = 0; i < count; i++)
            {
                if (products[i].Article == article)
                    return products[i];
            }
            return null;
        }

        public bool ShipByArticle(string article, int amount)
        {
            Product? product = FindByArticle(article);
            if (product == null)
                return false;
            product.Ship(amount);
            return true;
        }

        public List<Product> GetLowRestProducts()
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                if (products[i].Quantity < products[i].Rest)
                    result.Add(products[i]);
            }
            return result;
        }

        public double GetMnogoValue()
        {
            double total = 0;
            for (int i = 0; i < count; i++)
                total += products[i].Price * products[i].Quantity;
            return total;
        }

        public Product[] GetProducts()
        {
            Product[] copy = new Product[count];
            for (int i = 0; i < count; i++)
                copy[i] = products[i];
            return copy;
        }
    }
}
