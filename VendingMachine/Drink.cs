using System;

namespace VendingMachine
{
    /// <summary>
    /// The class for drink products
    /// </summary>
    public class Drink : Product
    {
        /// <summary>
        /// Create new drink product and set some properites for it
        /// </summary>
        /// <param name="initName">The name of the new drink product</param>
        /// <param name="description">The description of the new drink product</param>
        public Drink(string initName, string description)
        {
            Name = initName;
            Price = 20;
            Description = description;
        }
        /// <summary>
        /// Get information about drink product
        /// </summary>
        public override void GetInfo()
        {
            Console.WriteLine(Description);
        }

        /// <summary>
        /// Purchase of this drink product
        /// </summary>
        /// <returns>The price of this drink product</returns>
        public override int Purchase()
        {
            Console.WriteLine($"This product cost {Price}.");

            return Price;
        }

        /// <summary>
        /// Use or drink the drink product
        /// </summary>
        public override void Use()
        {
            Console.WriteLine($"Drink the {Name}.");
        }
    }
}
