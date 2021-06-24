using System.Collections.Generic;
using System.Linq;

namespace BakeryChallenge.Models
{
    public class BlueberryMuffin : IProduce
    {
        public string Name { get; } = "Blueberry Muffin";
        public ProduceCode Code { get; } = ProduceCode.MB11;
        public List<Pack> Packs { get; }
        
        public BlueberryMuffin()
        {
            Packs = new List<Pack>
            {
                new Pack {Quantity = 2, Price = 9.95F},
                new Pack {Quantity = 5, Price = 16.95F},
                new Pack {Quantity = 8, Price = 24.95F}
            };
            Packs = Packs.OrderByDescending(q => q.Quantity).ToList();
        }
    }
}