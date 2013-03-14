namespace GildedRose.Classes
{
    public class Legendary : Item, IUpdate
    {
        private int _quality = 0;
        private int _sellin = 0;

        public new int SellIn { get { return _sellin; } set { _sellin = value > 0 ? value : 0; } }

        public new int Quality
        {
            get { return 80; }
            set { ; }
        }

        public void Update()
        {
        }
    }
}