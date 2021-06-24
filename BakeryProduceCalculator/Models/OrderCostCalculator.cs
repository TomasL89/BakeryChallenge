using System;
using System.Linq;

namespace BakeryChallenge.Models
{
    public class OrderCostCalculator
    {
        public Order Calculate(Cart cart)
        {
            var originalOrderQuantity = cart.Quantity;

            var attemptArray = cart.Produce.Packs.ToArray();
            var incorrectPackIndex = 0;

            var order = new Order();
            // set an attempt limit that is determined by the number of possible combinations with the given packs
            var attemptLimit = Math.Pow(2, cart.Produce.Packs.Count);
            var attemptCount = 0;
            
            while (originalOrderQuantity > 0)
            {
                for (var i = 0; i < attemptArray.Length; i++)
                {
                    var pack = attemptArray[i];
                    var orderBreakdown = originalOrderQuantity / pack.Quantity;
                    if (orderBreakdown > 0)
                    {
                        originalOrderQuantity -= (pack.Quantity * orderBreakdown);
                        for (var j = 0; j < orderBreakdown; j++)
                        {
                            order.Packs.Add(pack);
                            order.Total += pack.Price;
                        }
                    }
                    else
                    {
                        // revert to the pack that did not suit the minimal number of pack requirement
                        incorrectPackIndex = i - 1;
                    }
                }
                // reset the attempt
                if (originalOrderQuantity > 0)
                {
                    if (attemptCount > attemptLimit)
                    {
                        return null;
                    }
                    attemptCount++;
                    order = new Order();
                    // select a new array of packs without the pack that caused a non-zero optimisation result
                    attemptArray = cart.Produce.Packs.Where((_, i) => i != incorrectPackIndex).ToArray();
                    originalOrderQuantity = cart.Quantity;
                }
            }

            order.Total = Math.Round(order.Total, 2);
            return order;
        }

    }
}
