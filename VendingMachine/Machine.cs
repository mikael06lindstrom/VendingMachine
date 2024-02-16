using System;
using System.Collections.Generic;

namespace VendingMachine
{
    /// <summary>
    /// The class for the vending machine itself
    /// </summary>
    public class Machine
    {
        /// <summary>
        /// A properties for run status of this vending machine
        /// </summary>
        public bool IsRun { get; set; }

        /// <summary>
        /// Some private field for the machine
        /// </summary>
        private readonly int[] denominations = new int[9] { 1,2,10,20,50,100,200,500,1000};
        private int[] moneypool = new int[1];
        private int countBankNotes = 0, sum = 0, temp;
        private IList<Product> products = new List<Product>();
        private string input;


        /// <summary>
        /// Create and run the machine itself
        /// </summary>
        public Machine()
        {
            InsertBankNotes();
            CreateProductList();
            Buying();
            ChangeBack();
        }

        /// <summary>
        /// Get the user ability to buying some product from the machine 
        /// </summary>
        public void Buying()
        {
            // Set status of machine to true
            IsRun = true;

            // Run until status IsRun to false
            while(IsRun == true)
            {
                // Create a empty console window and show name of this program
                Console.Clear();
                Console.WriteLine(Program.ProgramName);

                // Make a empty row
                Console.WriteLine();

                // Check if user had any money to buy product for
                if(sum > 0) 
                {
                    Console.WriteLine($"You have {sum} to buy products for.");
                    WriteProductList();

                    Console.Write($"Choise any option: ");
                    int.TryParse(Console.ReadLine(), out temp);

                    // Check if the user choise quit the machine
                    if (temp == 99 && products.Count < 98 || temp == products.Count + 1) 
                        IsRun = false;
                    else
                    {
                        Product item = products[temp-1];

                        sum -= item.Purchase();
                        item.Use();

                        // Make a pause in this program
                        Console.ReadKey();
                    }
                }
                else
                    IsRun = false;

            }
        }
        /// <summary>
        /// Insert Bank notes in the machine
        /// </summary>
        public void InsertBankNotes()
        {
            // Set status of machine to true
            IsRun = true;

            while (IsRun == true)
            {
                Console.Write("Which denomation you will insert? (This are allowed: ");
                foreach (int item in denominations)
                {
                    Console.Write(item);
                    if (item != denominations[denominations.Length-1])
                        Console.Write(", ");
                }
                Console.Write("):");
                int.TryParse(Console.ReadLine(), out temp);

                for (int i = 0; i < denominations.Length; i++)
                {
                    // Check if the user had insert a allowed denomination
                    if (denominations[i] == temp)
                    {
                        moneypool[countBankNotes] = temp;
                        sum += temp;
                        countBankNotes++;

                        // Ask the user if they will insert more money
                        Console.Write("Will you insert more? Y/N ");
                        input = Console.ReadLine();

                        Console.WriteLine();

                        if (input.ToLower().Equals("n"))
                        {
                            IsRun = false;
                            break;
                        }
                        else
                        { 
                            Array.Resize(ref moneypool, moneypool.Length + 1);
                            break;
                        }
                    }
                    else if (i == denominations.Length - 1)
                    {
                        Console.WriteLine("The choise denomination aren't allowed.");
                    }
                }
            }
            Array.Reverse(moneypool);
        }    
       /// <summary>
        /// Give back money to user
        /// </summary>
        public void ChangeBack()
        {
            // A count of all denominations
            int[] changeCount = new int[denominations.Length];

            // Set change back count to zero for all denominations
            for (int i = 0; i < denominations.Length; i++)
                changeCount[i] = 0;

            // Make a empty console window and show the name of this machine
            Console.Clear();
            Console.WriteLine(Program.ProgramName);

            // Make a empty row
            Console.WriteLine();

            Console.WriteLine($"The machine give you {sum} back.");

            // Run this until the machine had give back all change back.
            while (sum > 0) 
            {
                for(int i = denominations.Length - 1; i >= 0; i--) 
                {
                    while(sum / denominations[i] > 0)
                    {
                        sum -= denominations[i];
                        changeCount[i]++;
                    }
                }
            }

            for(int i = 7; i >= 0; i--) 
            {
                if (changeCount[i] == 0)
                { }
                else
                    Console.WriteLine($"{changeCount[i]} x {denominations[i]} = {changeCount[i]* denominations[i]}");
            }

        }
        /// <summary>
        /// Create a list of products in the machine
        /// </summary>
        
        public void CreateProductList()
        {
            products.Add(new Drink("Coca Cola", "Coca Cola are a drink from Coca Cola Corp"));
            products.Add(new Drink("Fanta", "Fanta are a drink from Coca Cola Corp"));
            products.Add(new Snack("Chips", "Chips are make from potato"));
            products.Add(new Food("Sandswich", "Sandswich "));
        }
        /// <summary>
        /// Show a list of product in this machine
        /// </summary>
        public void WriteProductList()
        {
            for(int i = 0; i < products.Count; i++) 
            {
                Product item = products[i];
                Console.WriteLine($"{i+1}. {item.Name} -  {item.Price}");
            }
            if (products.Count < 99)
                Console.WriteLine("99. Quit the program");
            else
                Console.WriteLine($"{products.Count+1}. Quit the program");
        }
    }
}