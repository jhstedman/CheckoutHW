namespace CheckoutCounter
{
    public class SimpleDiscountCheckout
    {
        public SimpleDiscountCheckout() { }

        public double CalculateCost(string items)
        {
            var total = 0.0;
            var itemArray = items.ToCharArray();
            foreach (var item in itemArray)
            {
                switch (item)
                {
                    case 'A':
                        total += 50;
                        break;
                    case 'B':
                        total += 30;
                        break;
                    case 'C':
                        total += 20;
                        break;
                    case 'D':
                        total += 5;
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