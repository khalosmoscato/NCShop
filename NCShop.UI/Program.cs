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
                Console.WriteLine("Access granted!");
            }
            else
            {
                // else if it returns false, we print another message (in our case `access denied`)
                Console.WriteLine("Access denied.");
            }
        }
    }
}
