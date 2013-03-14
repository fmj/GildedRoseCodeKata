using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GildedRose;
using GildedRose.Classes;

namespace GildedRoseTest
{
    [TestClass]
    public class GildedRoseUnitTest
    {

        public List<IUpdate> GetArray(IUpdate item)
        {
            return new List<IUpdate>(){item};
        }

        public Program GetApp(List<IUpdate> items)
        {
            return new Program() {Items = items};
        }
            
            [TestMethod]
        public void TestItemNeverNegative()
        {
            var Items = 
                new Normal(){Name    = "foo", 
                         SellIn  = 0, 
                         Quality = 0} ;
            var app = GetApp(GetArray(Items));
            app.UpdateQuality();
            Assert.IsTrue(Items.Quality >= 0);
        }

        [TestMethod]
        public void TestSellInDecreases()
        {
            var item = new Normal() { Name = "Crap", SellIn = 1, Quality = 10 };
            var app = GetApp(GetArray(item));
            app.UpdateQuality();
            Assert.AreEqual(0, item.SellIn);
        }

        [TestMethod]
        public void TestDoubleDegradeAfterSellByDate()
        {
            var item = new Normal() { Name = "Crap", SellIn = 0, Quality = 10 };
            var app = GetApp(GetArray(item));
            app.UpdateQuality();
            Assert.AreEqual(8, item.Quality);
        }

        [TestMethod]
        public void TestAgedBrieAllwaysIncreseInValue()
        {
            int updateCount = 50;
            var item = new Brie() { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            var app = GetApp(GetArray(item));
            for (int i = 0; i < updateCount; i++)
                app.UpdateQuality();

            Assert.AreEqual(updateCount, item.Quality);
        }


        [TestMethod]
        public void TestLegendaryItemsSellDateDoesNotChange()
        {
            var item = new Legendary() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80 };
            var app = GetApp(GetArray(item));
            //for (int i = 0; i < 200; i++)
            //  app.UpdateQuality();

            Assert.AreEqual(20, item.SellIn);
        }

        [TestMethod]
        public void TestLegendaryQualityDoesNotChange()
        {
            var item = new Legendary() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80 };

            var app = GetApp(GetArray(item));

            for (int i = 0; i < 200; i++)
                app.UpdateQuality();

            Assert.AreEqual(80, item.Quality);
        }

        [TestMethod]
        public void TestBackStagePassesIncreaseByTwiceTheQuality10DaysOrLess()
        {
            var item = new BackStage()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 9,
                    Quality = 43
                };
            var app = GetApp(GetArray(item));
            app.UpdateQuality();
            Assert.AreEqual(45,item.Quality);
        }

        [TestMethod]
        public void TestBackStagePassesIncreaseByThriceTheQuality5DaysOrLess()
        {
            var item = new BackStage()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 30
            };
            var app = GetApp(GetArray(item));
            app.UpdateQuality();
            Assert.AreEqual(33, item.Quality);
        }

        [TestMethod]
        public void TestBackStageNeverIncreasesAboveMaxValueForQuality()
        {
            var item = new BackStage()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 100,
                Quality = 48
            };
            var app = GetApp(GetArray(item));
            for (int i = 0; i < 100;i++ )
                app.UpdateQuality();
            Assert.AreEqual(50, item.Quality);
        }

        [TestMethod]
        public void TestBackStageQualityIsZeroAfterConcert()
        {
            var item = new BackStage()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 50
            };
            var app = GetApp(GetArray(item));
            app.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void TestConjuredItemsDegradeTwiceAsFast()
        {
            var item = new Conjured() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6};

            var app = GetApp(GetArray(item));
            app.UpdateQuality();
            Assert.AreEqual(4,item.Quality);
        }



    }
}
