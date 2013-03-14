namespace GildedRose
{
    public class BackStage : Item, IUpdate
    {
        private int _quality = 0;
        public new int Quality
        {
            get { return _quality; }
            set { _quality = value > 50 ?  50 : value; }
        }

        public void Update()
        {
            if (SellIn <= 0)
                Quality = 0;
            else if (SellIn <= 5)
                Quality += 3;
            else if (SellIn <= 10)
                Quality += 2;
            else
            {
                Quality++;
            }
            SellIn--;
        }
    }
}