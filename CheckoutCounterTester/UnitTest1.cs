using NUnit.Framework;
using CheckoutCounter;
using System.Collections.Generic;

namespace CheckoutCounterTester
{
    public class Tests
    {
        [Test]
        public void TestSimpleCheckout()
        {
            var sc = new SimpleCheckout();
            var total = sc.CalculateCost("ACB");
            Assert.AreEqual(100, total);
        }

        [Test]
        public void TestSimpleDiscountCheckout()
        {
            var sdc = new SimpleDiscountCheckout();
            var totalDiscount = sdc.CalculateCost("ACBACBACBACB");
            var total = sdc.CalculateCost("ACB");
            Assert.AreEqual(360, totalDiscount);
            Assert.AreEqual(100, total);
        }

        [Test]
        public void TestDiscountCheckout()
        {
            var dc = new DiscountCheckout();
            var bDiscount = dc.CalculateCost("BB");
            var dDiscount = dc.CalculateCost("ADDD");
            var total = dc.CalculateCost("ACB");
            Assert.AreEqual(30, bDiscount);
            Assert.AreEqual(60, dDiscount);
            Assert.AreEqual(100, total);
        }

        [Test]
        public void TestCheckout()
        {
            var checkout = new Checkout();
            var products1 = new List<Product>
            {
                new Product{id = 'B', price = 30, weight = 20, type = "Household Goods"},
                new Product{id = 'B', price = 30, weight = 20, type = "Household Goods"}
            };
            var products2 = new List<Product> 
            {
                new Product{id = 'A', price = 50, weight = 2, type = "Electronics"},
                new Product{id = 'E', price = 8, weight = 1.2, type = "Groceries"},
                new Product{id = 'D', price = 5, weight = 1, type = "Groceries"}
            };
            checkout.CalculateCost(products1,out var weight1, out var types1, out var total1);
            checkout.CalculateCost(products2, out var weight2, out var types2, out var total2);
            var checkList1 = new List<string> { "Household Goods" };
            var checkList2 = new List<string> { "Electronics", "Groceries" };
            Assert.AreEqual(30, total1);
            Assert.AreEqual(63, total2);
            Assert.AreEqual(40, weight1);
            Assert.AreEqual(4.2, weight2);
            Assert.AreEqual(checkList1, types1);
            Assert.AreEqual(checkList2, types2);
        }
    }
}