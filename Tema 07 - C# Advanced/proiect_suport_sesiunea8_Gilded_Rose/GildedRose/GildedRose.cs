using GildedRose;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Conjured = "Conjured";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            //aplicati Factory Pattern on init
            IList<Item> factoryItems = new List<Item>();
            foreach (Item item in Items)
            {
                switch(item.Name)
                {
                    case AgedBrie:
                        factoryItems.Add(ItemFactory.createItem(
                            ItemFactory.ItemType.AgedBrie, item.Name, item.SellIn, item.Quality));
                        break;
                    case Backstage:
                        factoryItems.Add(ItemFactory.createItem(
                            ItemFactory.ItemType.BackStage, item.Name, item.SellIn, item.Quality));
                        break;
                    case Conjured:
                        factoryItems.Add(ItemFactory.createItem(
                            ItemFactory.ItemType.Conjured, item.Name, item.SellIn, item.Quality));
                        break;
                    case Sulfuras:
                        factoryItems.Add(ItemFactory.createItem(
                            ItemFactory.ItemType.Sulfuras, item.Name, item.SellIn, item.Quality));
                        break;
                }
            }
            this.Items = factoryItems;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.ChangeDay();
                item.updateQuality();
            }
        }
    }
}
