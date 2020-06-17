using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;

        const int MinQuality = 0;
        const int MaxQuality = 50;
        const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        const string BackstagePassesToATafkal80etcConcert = "Backstage passes to a TAFKAL80ETC concert";
        const string AgedBrie = "Aged Brie";
        const string DexterityVest = "+5 Dexterity Vest";
        const string ElixirOfTheMongoose = "Elixir of the Mongoose";
        const string ConjuredManaCake = "Conjured Mana Cake";

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = DexterityVest, SellIn = 10, Quality = 20},
                    new Item {Name = AgedBrie, SellIn = 2, Quality = 0},
                    new Item {Name = ElixirOfTheMongoose, SellIn = 5, Quality = 7},
                    new Item {Name = SulfurasHandOfRagnaros, SellIn = 0, Quality = 80},
                    new Item {Name = BackstagePassesToATafkal80etcConcert, SellIn = 15, Quality = 20},
                    new Item {Name = ConjuredManaCake, SellIn = 3, Quality = 6}
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateQualityOfItem(item);
            }
        }

        private void UpdateQualityOfItem(Item item)
        {
            if (item.Name != AgedBrie && item.Name != BackstagePassesToATafkal80etcConcert)
            {
                if (item.Quality > MinQuality)
                {
                    if (item.Name != SulfurasHandOfRagnaros)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == BackstagePassesToATafkal80etcConcert)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < MaxQuality)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < MaxQuality)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != SulfurasHandOfRagnaros)
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackstagePassesToATafkal80etcConcert)
                    {
                        if (item.Quality > MinQuality)
                        {
                            if (item.Name != SulfurasHandOfRagnaros)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < MaxQuality)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}