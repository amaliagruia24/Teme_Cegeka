using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class ItemFactory
    {
        public enum ItemType
        {
            AgedBrie, BackStage, Sulfuras, Conjured
        }

        public static Item createItem(ItemType itemType, string name, int sellIn, int quality)
        {
            switch (itemType)
            {
                case ItemType.AgedBrie: return new AgeBrie(name, sellIn, quality);
                case ItemType.Sulfuras: return new Sulfuras(name, sellIn, quality);
                case ItemType.BackStage: return new BackStage(name, sellIn, quality);
                case ItemType.Conjured: return new Conjured(name, sellIn, quality);

            }
            throw new ArgumentException($"The item type {itemType} is not recognized.");
        }
    }

}

