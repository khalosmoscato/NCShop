using NCShop.Data;
using System.Security.Authentication;
namespace NCShop.Business
{
    public class ShopLogic
    {
        // adding an authenication as per exercise
        public static bool AuthenticateUser(string username, string password)
        {
            // hardcoding the answers because we are not using a database with users yet
            string defaultUsername = "username";
            string defaultPassword = "password";
            // I am checkinf if the inserted data matches
            // because I hard coded the username and password to be all lower case, I want to make the input data lower case, this is not needed.
            if (username.ToLower() == defaultUsername && password.ToLower() == defaultPassword)
            {
                return true;
            }
            return false;
        }
        // we need to call the logic inside NCShop.Data library, so we create the methods here that call the NCShop.Data funtions
        public static bool AddProduct(string product)
        {
            // becuase at the top of the file we have the `using.NCShop.Data;` line, when we recall that library's methods, we cam do it as follows:
            return StockManager.AddStock(product);
            // instead of doing it like this -> `return NCShop.Data.StockManager.AddStock(product);`
        }
        public static bool RemoveProduct(string product)
        {
            return StockManager.RemoveStock(product);
        }
        public static List<string> GetStockList()
        {
            return StockManager.GetStock();
        }
    }
}
