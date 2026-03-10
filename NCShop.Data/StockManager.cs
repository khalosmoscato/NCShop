namespace NCShop.Data
{
    public class StockManager
    {
        // the reason we use `static` is because this list lives only in our local, not in a database, so we want to keep it static for it to stay as we perform the Add/Remove/Get methods.
        private static List<string> _stock = new List<string> { "Piano", "Violin", "Guitar" };
        // we need our methods to include `static` because the List is `static` itself
        public static bool AddStock(string product)
        {
            // here we are checking that a valid input was added so that we can add it to our list
            if (product.Length > 0)
            {
                _stock.Add(product);
                return true;
            }
            return false;
        }
        public static bool RemoveStock(string product)
        {
            if (product.Length > 0)
            {
                // the `.Remove` checks if the product is included in the list, as if it was performing a `.Contains(p)` automatically
                // so we can just return it which implicates it is true, otherwise we return false.
                return _stock.Remove(product);
            }
            return false;
        }
        public static List<string> GetStock()
        {
            return _stock;
        }
    }
}
