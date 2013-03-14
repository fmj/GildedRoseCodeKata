using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose
{
    public class Item
    {
        public Item()
        {
            Category = CategoryEnum.Normal;
        }
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public CategoryEnum Category { get; set; }

        public void Update()
        {
            switch (Category)
            {
                case CategoryEnum.Backstage:
                    {
                        if (SellIn == 0)
                            Quality = 0;
                        else
                        {
                            
                        }
                    }
            }
        }
    }

    public enum CategoryEnum
    {
        Backstage, Conjured, Brie, Legendary, Normal
    }
}
