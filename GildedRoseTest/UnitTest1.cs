using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GildedRose;

namespace GildedRoseTest
{
    [TestClass]
    public class GildedRoseUnitTest
    {

        [TestMethod]
        public void TestItemNeverNegative()
        {
            List<Item> Items = new List<Item>{ 
                new Item{Name    = "foo", 
                         SellIn  = 0, 
                         Quality = 0} 
            };
            Program app = new Program { Items = Items };
            app.UpdateQuality();
            Assert.IsTrue(Items.First().Quality >= 0);
        }

        [TestMethod]
        public void TestSellInDecreases()
        {
            var item = new Item() { Name = "Crap", SellIn = 1, Quality = 10 };
            var app = new Program() { Items = new List<Item>() { item } };
            app.UpdateQuality();
            Assert.AreEqual(0, item.SellIn);
        }

        [TestMethod]
        public void TestDoubleDegradeAfterSellByDate()
        {
            var item = new Item() { Name = "Crap", SellIn = 0, Quality = 10 };
            var app = new Program() { Items = new List<Item>() { item } };
            app.UpdateQuality();
            Assert.AreEqual(8, item.Quality);
        }

        [TestMethod]
        public void TestAgedBrieAllwaysIncreseInValue()
        {
            int updateCount = 50;
            var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            var app = new Program() { Items = new List<Item>() { item } };
            for (int i = 0; i < updateCount; i++)
                app.UpdateQuality();

            Assert.AreEqual(updateCount, item.Quality);
        }

        [TestMethod]
        public void TestMaxQualityValue()
        {
            var item = new Item() { Name = "test", Quality = 200, SellIn = 1 };
            var app = new Program() { Items = new List<Item>() { item } };
            app.UpdateQuality();

            Assert.AreEqual(50, item.Quality);
        }

        [TestMethod]
        public void TestLegendaryItemsSellDateDoesNotChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80 };
            var app = new Program() { Items = new List<Item>() { item } };
            //for (int i = 0; i < 200; i++)
            //  app.UpdateQuality();

            Assert.AreEqual(20, item.SellIn);
        }

        [TestMethod]
        public void TestLegendaryQualityDoesNotChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80 };

            var app = new Program() { Items = new List<Item>() { item } };

            for (int i = 0; i < 200; i++)
                app.UpdateQuality();

            Assert.AreEqual(80, item.Quality);
        }

        [TestMethod]
        public void TestBackStagePassesIncreaseByTwiceTheQuality10DaysOrLess()
        {
            var item = new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 9,
                    Quality = 43
                };
            var app = new Program() {Items = new List<Item>() {item}};
            app.UpdateQuality();
            Assert.AreEqual(45,item.Quality);
        }

        [TestMethod]
        public void TestBackStagePassesIncreaseByThriceTheQuality5DaysOrLess()
        {
            var item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 30
            };
            var app = new Program() { Items = new List<Item>() { item } };
            app.UpdateQuality();
            Assert.AreEqual(33, item.Quality);
        }

        [TestMethod]
        public void TestBackStageNeverIncreasesAboveMaxValueForQuality()
        {
            var item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 100,
                Quality = 48
            };
            var app = new Program() { Items = new List<Item>() { item } };
            for (int i = 0; i < 100;i++ )
                app.UpdateQuality();
            Assert.AreEqual(50, item.Quality);
        }

        [TestMethod]
        public void TestBackStageQualityIsZeroAfterConcert()
        {
            var item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 50
            };
            var app = new Program() { Items = new List<Item>() { item } };
            app.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void TestConjuredItemsDegradeTwiceAsFast()
        {
            var item = new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6};

            var app = new Program() {Items = new List<Item>() {item}};
            app.UpdateQuality();
            Assert.AreEqual(4,item.Quality);
        }



    }
}
