using System;

namespace VendingMachine
{
    /// <summary>
    /// The class for food products
    /// </summary>
    public class Food : Product
    {
        /// <summary>
        /// Create new food product
        /// </summary>
        /// <param name="initName">The name of the new food product</param>
        /// <param name="description">The description fo the new food productd</param>
        public Food(string initName, string description)
        {
            Name = initName;
            Price = 25;
            Description = description;
        }

        /// <summary>
        /// Get information of this food product
        /// </summary>
        public override void GetInfo()
        {
            Console.WriteLine(Description);
        }
        /// <summary>
        /// Purchase the food product
        /// </summary>
        /// <returns>The price of the food product</returns>
        public override int Purchase()
        {
            Console.WriteLine($"This product cost {Price}.");

            return Price;
        }

        /// <summary>
        /// Use or eat the food product
        /// </summary>
        public override void Use()
        {
            Console.WriteLine($"Eat the {Name}.");
        }
    }
}
