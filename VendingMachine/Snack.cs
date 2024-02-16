using System;

namespace VendingMachine
{
    /// <summary>
    /// The class for snack products
    /// </summary>
    public class Snack : Product
    {
        /// <summary>
        /// Create a new snack product
        /// </summary>
        /// <param name="initName">The name of the new snack product</param>
        /// <param name="description">The descripton of the new snack product</param>
        public Snack(string initName, string description)
        {
            Name = initName;
            Price = 15;
            Description = description;
        }
        /// <summary>
        /// Get information of this snack product
        /// </summary>
        public override void GetInfo()
        {
            Console.WriteLine(Description);
        }

        /// <summary>
        /// Purchase this snack product
        /// </summary>
        /// <returns>The price of this snack product</returns>
        public override int Purchase()
        {
            Console.WriteLine($"This product cost {Price}.");
            return Price;
        }

        /// <summary>
        /// Use or eat this snack product
        /// </summary>
        public override void Use()
        {
            Console.WriteLine($"Eat the {Name}.");
        }
    }
}
