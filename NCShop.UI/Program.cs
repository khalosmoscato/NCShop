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
                // I am creating this bool set to true to use as a switch for a persistent menu
                bool showChoices = true;
                // I am initialising choice variable, I will need that in the loop with the possible choicec
                string choice = "";
                // starting the persistent menu, `while` the switch is true, keep the menu open, if false -> close menu
                while (showChoices)
                {
                    // clear the line to start the persistent menu with a fresh window
                    Console.Clear();
                    // give the user the possible options
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Remove Product");
                    Console.WriteLine("3. View Stock");
                    Console.WriteLine("4. Exit");
                    // now the user is prompter to type a choise, we assign that to our `choice` variable
                    choice = Console.ReadLine();
                    // depending on the choice we start our switch statement
                    switch (choice)
                    {
                        case "1":
                            // once the case selected starts, the window clears so we want to display a message to remind the user what action they are about to perform:
                            Console.WriteLine("Insert product to ADD:");
                            // we save the input
                            string productAdded = Console.ReadLine();
                            // we call the method which performs the needed instructions, in this case adds a product
                            ShopLogic.AddProduct(productAdded);
                            // this timer is to simulate delay
                            Thread.Sleep(2000);
                            // after the action is complete we want to tell the user how to go back to the menu, the `\n` takes us to the next line
                            Console.WriteLine("\nPress Enter to return to menu...");
                            Console.ReadLine();
                            // we finish the switch cases by breaking
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
                            // if the stock list is 0, we would not have anything to display, so let's check that:
                            if (ShopLogic.GetStockList().Count == 0)
                            {
                                Console.WriteLine("All stock is soldout.");
                            }
                            else
                            {
                                // if there are products in our stock list, we can print each product with a foreach statement:
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
                            // we turn this from true to false which closes the persistent menu
                            showChoices = false;
                            break;
                        default:
                            // if the user input does not correspond to our above mentioned switch cases, we get an "invalid selection" message
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
