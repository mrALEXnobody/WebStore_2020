using System.Collections.Generic;
using System.Linq;

namespace WebStore_2020.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public int ItemsCount => Items?.Sum(x => x.Quantity) ?? 0;
    }
}
