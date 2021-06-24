using System.Collections.Generic;
using System.Linq;

namespace BakeryChallenge.Models
{
    public class Croissant : IProduce
    {
        public string Name { get; } = "Croissant";
        public ProduceCode Code { get; } = ProduceCode.CF;
        public List<Pack> Packs { get; }

        public Croissant()
        {
            Packs = new List<Pack>
            {
                new Pack {Quantity = 3, Price = 5.95F},
                new Pack {Quantity = 5, Price = 9.95F},
                new Pack {Quantity = 9, Price = 16.99F}
            };
            Packs = Packs.OrderByDescending(q => q.Quantity).ToList();
        }
    }
}