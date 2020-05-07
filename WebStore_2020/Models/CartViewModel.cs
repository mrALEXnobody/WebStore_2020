using System.Collections.Generic;
using System.Linq;

namespace WebStore_2020.Models
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel,int> Items { get; set; }
        public int ItemsCount => Items?.Sum(x => x.Value) ?? 0;
    }
}
