namespace BakeryChallenge.Models
{
    public class Cart
    {
        public int Quantity { get; set; }
        public IProduce Produce { get; set; }
    }
}