using System.Collections.Generic;
using System.Linq;

namespace BakeryChallenge.Models
{
    public class VegemiteScroll : IProduce
    {
        public string Name { get; } = "Vegemite Scroll";
        public ProduceCode Code { get; } = ProduceCode.VS5;
        public List<Pack> Packs { get; }

        public VegemiteScroll()
        {
            Packs = new List<Pack>
            {
                new Pack {Quantity = 3, Price = 6.99F}, 
                new Pack {Quantity = 5, Price = 8.99F}
            };
            Packs = Packs.OrderByDescending(q => q.Quantity).ToList();
        }
    }
}