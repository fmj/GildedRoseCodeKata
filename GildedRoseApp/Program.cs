using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public List<IUpdate> Items { get; set; }

        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                {
                    Items = GetInitialItems()
                };

            string printFormat = "{0}\t\t\t\t{1}\t\t{2}";
            for (var i = 0; i < 31; i++)
            {
                System.Console.WriteLine("-------- day " + i + " --------");
                System.Console.WriteLine(printFormat,"name","sellIn","tquality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Item item = (Item) app.Items[j];
                    System.Console.WriteLine(printFormat,item.Name , item.SellIn, item.Quality);
                }
                System.Console.WriteLine("");
                app.UpdateQuality();
            }
            System.Console.ReadKey();

        }

        private static List<IUpdate> GetInitialItems()
            {
                return new List<IUpdate>
                    {
                        new Normal() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                        new Brie() {Name = "Aged Brie", SellIn = 2, Quality = 0},
                        new Normal() {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                        new Legendary() {Name = "Sulfuras, Hand of Ragnaros"},
                        new Legendary() {Name = "Sulfuras, Hand of Ragnaros"},
                        new BackStage()
                            {
                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                SellIn = 15,
                                Quality = 20
                            },
                        new BackStage()
                            {
                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                SellIn = 10,
                                Quality = 49
                            },
                        new BackStage()
                            {
                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                SellIn = 5,
                                Quality = 49
                            },
                        // this conjured item does not work properly yet
                        new Conjured() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                    };
            }
                //Updates quality for all items
        public void UpdateQuality()
        {
            foreach (IUpdate upd in Items) upd.Update();
        }
    }
}
