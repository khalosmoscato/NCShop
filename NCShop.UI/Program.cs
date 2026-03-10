using NCShop.Business;
namespace NCShop.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // welcome message for the UI to be displayed when I build the project by clicking the green filled trianlge above
            Console.WriteLine("***Welcome to NCShop!***");
            // here I am trying to authenticate the user
            Console.WriteLine("Enter you username");
            // I need to save in a variable the user input, in the first line he's been asked to enter his userID
            string user = Console.ReadLine();
            // same process for password:
            Console.WriteLine("Eenter your password");
            string password = Console.ReadLine();
            // authentication logic is setup in the ShopLogic file, I am now calling the needed method
            if (ShopLogic.AuthenticateUser(user, password))
            {
                // if the method returns true, print a message (in our case it could be `access granted`)
                Console.WriteLine("logging in...");
                // delays 2 seconds (2000ms), could also be written `System.Threading.Thread.Sleep(2000);`
                Thread.Sleep(2000);
                // clears the UI now that we are logged in
                Console.Clear();
                Console.WriteLine("Welcome to NCShop");
                bool showChoices = true;
                string choice = "";
                while (showChoices)
                {
                    
                    Console.Clear();
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Remove Product");
                    Console.WriteLine("3. View Stock");
                    Console.WriteLine("4. Exit");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Insert product to ADD:");
                            string productAdded = Console.ReadLine();
                            ShopLogic.AddProduct(productAdded);
                            Thread.Sleep(2000);
                            Console.WriteLine("\nPress Enter to return to menu...");
                            Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("Type product to REMOVE:");
                            string productRemoved = Console.ReadLine();
                            ShopLogic.RemoveProduct(productRemoved);
                            Thread.Sleep(2000);
                            Console.WriteLine("\nPress Enter to return to menu...");
                            Console.ReadLine();
                            break;
                        case "3":
                            
                            if (ShopLogic.GetStockList().Count == 0)
                            {
                                Console.WriteLine("All stock is soldout.");
                            }
                            else
                            {
                                foreach (string p in ShopLogic.GetStockList())
                                {
                                    Console.WriteLine(p);
                                }
                            }
                            
                            Thread.Sleep(2000);
                            Console.WriteLine("\nPress Enter to return to menu...");
                            Console.ReadLine();
                            break;
                        case "4":
                            showChoices = false;
                            break;
                        default:
                            Console.WriteLine("invalid selection, please try again.");
                            Thread.Sleep(2000);
                            break;
                    }
                }
            }
            else
            {
                // else if it returns false, we print another message (in our case `access denied`)
                Console.WriteLine("Access denied.");
            }

        }
    }
}
