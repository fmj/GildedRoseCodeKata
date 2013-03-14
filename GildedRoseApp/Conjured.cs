namespace GildedRose
{
    public class Conjured : Item, IUpdate
    {
        private int _quality = 0;

        public new int Quality
        {
            get { return _quality; }
            set { _quality = value > 50 ? 50 : value; }
        }

        public void Update()
        {
            if (SellIn < 0)
                Quality-= 4;
            else
                Quality-= 2;

            SellIn--;
        }
    }
}