using System.Collections.Generic;

namespace BakeryChallenge.Models
{
    public static class ProduceInfo
    {
        public static List<IProduce> AvailableProduceItems { get; set; } = new List<IProduce>
        {
            new VegemiteScroll(),
            new BlueberryMuffin(),
            new Croissant()
        };

    }
}
