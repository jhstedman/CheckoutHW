namespace CheckoutCounter
{
    public class DiscountCheckout
    {
        public DiscountCheckout() { }

        public double CalculateCost(string items)
        {
            var total = 0.0;
            var boughtOne = false;
            var dCount = 0;
            var itemArray = items.ToCharArray();
            foreach (var item in itemArray)
            {
                switch (item)
                {
                    case 'A':
                        total += 50;
                        break;
                    case 'B':
                        if (!boughtOne) 
                        {
                            total += 30;
                            boughtOne = true;
                        }
                        else
                        {
                            boughtOne = false;
                        }
                        break;
                    case 'C':
                        total += 20;
                        break;
                    case 'D':
                        dCount++;
                        if (dCount < 3)
                        {
                            total += 5;
                        }
                        else
                        {
                            dCount = 0;
                        }
                        break;
                    default:
                        break;
                }
            }
            total *= (itemArray.Length > 10) ? 0.9 : 1;
            return total;
        }
    }
}