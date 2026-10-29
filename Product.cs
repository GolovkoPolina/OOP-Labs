using System;

namespace laba1Nikitin
{
    internal class Product
    {
        private readonly string article;
        private string name;
        private double price;
        private int quantity;
        private int rest;
        private Dimensions dimensions;

        private static int CreatedProducts = 0;
        public const double VAT = 0.13;

        public Product(string article, string name, double price, int quantity, int rest, Dimensions dimensions)
        {
            if (string.IsNullOrWhiteSpace(article))
                throw new ArgumentException("Артикул не может быть пустым");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название не может быть пустым");
            if (double.IsNaN(price) || double.IsInfinity(price) || price <= 0)
                throw new ArgumentException("Цена должна быть больше нуля");
            if (quantity < 0)
                throw new ArgumentException("Количество не может быть отрицательным");
            if (rest < 0)
                throw new ArgumentException("Минимальный остаток не может быть отрицательным");
            if (dimensions == null)
                throw new ArgumentNullException(nameof(dimensions));

            this.article = article;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.rest = rest;
            this.dimensions = dimensions;
            CreatedProducts++;
        }

        public Product(string article, string name, double price, Dimensions dimensions)
            : this(article, name, price, 0, 0, dimensions)
        {
        }

        public string Article => article;
        public string Name => name;
        public double Price => price;
        public int Quantity => quantity;
        public int Rest => rest;
        public Dimensions Dimensions => dimensions;

        public static int GetCreatedProducts() => CreatedProducts;

        public double priceWithTax() => priceWithTax(VAT);

        public double priceWithTax(double rate)
        {
            if (double.IsNaN(rate) || double.IsInfinity(rate) || rate < 0)
                throw new ArgumentException("Ставка налога не может быть отрицательной");
            return price * (1 + rate);
        }

        public void ChangePrice(double newPrice)
        {
            if (double.IsNaN(newPrice) || double.IsInfinity(newPrice) || newPrice <= 0)
                throw new ArgumentException("Цена должна быть больше нуля");
            price = newPrice;
        }

        public void Dose(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Количество должно быть больше нуля");
            checked { quantity += amount; }
        }

        public void Ship(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Количество для отгрузки должно быть больше нуля");
            if (amount > quantity)
                throw new InvalidOperationException("Нельзя отгрузить больше, чем есть на складе");
            quantity -= amount;
        }

        public void ChangeDimensions(Dimensions newDimensions)
        {
            dimensions = newDimensions ?? throw new ArgumentNullException(nameof(newDimensions));
        }

        public override string ToString()
        {
            return $"Артикул: {article}, Название: {name}, Цена: {price}, " +
                   $"Количество: {quantity}, Минимальный остаток: {rest}, " +
                   $"Вес: {dimensions.Weight}, Объём: {dimensions.Volume}, " +
                   $"Хрупкий: {dimensions.Fragile}";
        }
    }
}
