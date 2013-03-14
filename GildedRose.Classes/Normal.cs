namespace GildedRose.Classes
{
    public class Normal : Item, IUpdate
    {
        private int _quality = 0;

        public new int Quality
        {
            get { return _quality; }
            set
            {
                if (value > 50)
                    _quality = 50;
                else if (value <= 0)
                    _quality = 0;
                else
                {
                    _quality = value;
                }
            }
        }

        public void Update()
        {
            if (SellIn <= 0)
                Quality--;

            Quality--;
            SellIn--;
        }
    }
}