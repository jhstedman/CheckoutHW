namespace CheckoutCounter
{
    public class Checkout
    {
        public Checkout() { }

        public void CalculateCost(List<Product> items, out double weight, out List<string> categories, out double total)
        {
            total = 0.0;
            weight = 0.0;
            categories = new List<string>();
            var boughtOne = false;
            var dCount = 0;
            foreach (var item in items)
            {
                if(item.id == 'B')
                {
                    if (!boughtOne)
                    {
                        total += item.price;
                        boughtOne = true;
                    }
                    else
                    {
                        boughtOne = false;
                    }
                }
                else if (item.id == 'D')
                {
                    dCount++;
                    if (dCount < 3)
                    {
                        total += item.price;
                    }
                    else
                    {
                        dCount = 0;
                    }
                }
                else
                {
                    total += item.price;
                }
                weight += item.weight;
                if(!categories.Contains(item.type)) categories.Add(item.type);
            }
            total *= (items.Count > 10) ? 0.9 : 1;
        }
    }
}