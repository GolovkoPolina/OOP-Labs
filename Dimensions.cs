using System;

namespace laba1Nikitin
{
    internal class Dimensions
    {
        private readonly double weight;
        private readonly double volume;
        private readonly bool fragile;

        public Dimensions(double weight, double volume, bool fragile)
        {
            if (double.IsNaN(weight) || double.IsInfinity(weight) || weight <= 0)
                throw new ArgumentException("Вес должен быть больше нуля");
            if (double.IsNaN(volume) || double.IsInfinity(volume) || volume <= 0)
                throw new ArgumentException("Объём должен быть больше нуля");
            this.weight = weight;
            this.volume = volume;
            this.fragile = fragile;
        }

        public double Weight => weight;
        public double Volume => volume;
        public bool Fragile => fragile;
    }
}
