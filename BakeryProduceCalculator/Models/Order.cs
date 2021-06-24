using System.Collections.Generic;

namespace BakeryChallenge.Models
{
    public class Order
    {
        public double Total { get; set; }
        public List<Pack> Packs { get; set; } = new List<Pack>();
    }
}