using NUnit.Framework;
using System.Collections.Generic;
using BakeryChallenge.Models;

namespace BakeryProduceTests
{
    public class PrePackageCalculatorTests
    {
        private OrderCostCalculator _calculator;
        
        [SetUp]
        public void Setup()
        {
            _calculator = new OrderCostCalculator();
        }

        [Test]
        public void OrderCostCalculator_ShouldCalculateBestValueVS5()
        {
            var cart = new Cart
            {
                Quantity = 10,
                Produce = new VegemiteScroll()
            };

            var result = _calculator.Calculate(cart);

            var expectedResult = new Order
            {
                Total = 17.98,
                Packs = new List<Pack>
                {
                    new Pack()
                    {
                        Price = 8.95F,
                        Quantity = 5
                    },
                    new Pack()
                    {
                        Price = 8.95F,
                        Quantity = 5
                    },
                }
            };

            Assert.AreEqual(expectedResult.Total, result.Total);
            Assert.AreEqual(expectedResult.Packs.Count, result.Packs.Count);
        }

        [Test]
        public void OrderCostCalculator_ShouldCalculateBestValueMB11()
        {
            var cart = new Cart
            {
                Quantity = 14,
                Produce = new BlueberryMuffin()
            };

            var result = _calculator.Calculate(cart);

            var expectedResult = new Order
            {
                Total = 54.8,
                Packs = new List<Pack>
                {
                    new Pack()
                    {
                        Price = 24.95F,
                        Quantity = 8
                    },
                    new Pack()
                    {
                        Price = 9.95F,
                        Quantity = 2
                    },
                    new Pack()
                    {
                        Price = 9.95F,
                        Quantity = 2
                    },
                    new Pack()
                    {
                        Price = 9.95F,
                        Quantity = 2
                    },
                }
            };

            Assert.AreEqual(expectedResult.Total, result.Total);
            Assert.AreEqual(expectedResult.Packs.Count, result.Packs.Count);
        }

        [Test]
        public void OrderCostCalculator_ShouldCalculateBestValueCF()
        {
            var cart = new Cart
            {
                Quantity = 13,
                Produce = new Croissant()
            };

            var result = _calculator.Calculate(cart);

            var expectedResult = new Order
            {
                Total = 25.85,
                Packs = new List<Pack>
                {
                    new Pack()
                    {
                        Price = 9.95F,
                        Quantity = 5
                    },
                    new Pack()
                    {
                        Price = 9.95F,
                        Quantity = 5
                    },
                    new Pack()
                    {
                        Price = 5.95F,
                        Quantity = 3
                    }
                }
            };

            Assert.AreEqual(expectedResult.Total, result.Total);
            Assert.AreEqual(expectedResult.Packs.Count, result.Packs.Count);
        }

        [Test]
        public void OrderCostCalculator_ShouldCatchInfiniteLoopAndReturnNull()
        {
            var cart = new Cart
            {
                Quantity = 3,
                Produce = new BlueberryMuffin()
            };

            var result = _calculator.Calculate(cart);

            Assert.IsNull(result);
        }
    }
}
