using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose
{
    public class Item
    {
        private int _quality = 0;

        public Item()
        {

        }
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }


    }
}
