using System.Collections.Generic;

namespace BakeryChallenge.Models
{
    public interface IProduce
    {
        public string Name { get; }
        public ProduceCode Code { get; }
        public List<Pack> Packs { get; }
    }
}