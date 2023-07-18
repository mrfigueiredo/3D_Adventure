using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public enum ITEMTYPE
    {
        COIN,
        LIFEPACK
    }


    public class ItemManager : Singleton<ItemManager>
    {
        public GameObject coinsHolder;
        public GameObject lifesHolder;

        public List<ItemSetup> items;

        private int _totalCoins;
        private int _totalLifes;

        protected override void Awake()
        {
            base.Awake();

            Reset();

            _totalCoins = coinsHolder.transform.childCount;
            _totalLifes = lifesHolder.transform.childCount;
        }

        private void Reset()
        {
            items.ForEach(item => item.SOItem.SetValue(0));

        }

        public void AddItemByType(ITEMTYPE type, int amount = 1)
        {
            if (amount <= 0)
                return;
            items.Find(i => i.ItemType == type)?.SOItem.AddValue(amount);
        }
        
        public void RemoveItemByType(ITEMTYPE type, int amount = 1)
        {
            if (amount <= 0)
                return;
            var item = items.Find(i => i.ItemType == type);

            if (item != null)
            {
                item.SOItem.RemoveValue(amount);

                if (item.SOItem.GetValue() < 0)
                    item.SOItem.SetValue(0);
            }
        }

        public ItemSetup GetSetupByType(ITEMTYPE type)
        {
            var item = items.Find(i => i.ItemType == type);
            if (item != null)
                return item;
            else
                return null;

        }

        public int GetCollectedByType(ITEMTYPE type)
        {
            var item = items.Find(i => i.ItemType == type);
            if (item != null)
                return item.SOItem.GetValue();
            else
                return -1;

        }

        public int GetTotalCoins()
        {
            return _totalCoins;
        }

        public int GetTotalLifes()
        {
            return _totalLifes;
        }

        public int LevelCompletionPercentage()
        {
            int coins = GetCollectedByType(ITEMTYPE.COIN);
            int life = GetCollectedByType(ITEMTYPE.LIFEPACK);
            float total = (float)(coins + life / (float)(_totalCoins + _totalLifes)) * 100f;
            return (int)total;
        }
    }

    [System.Serializable]
    public class ItemSetup
    {
        public ITEMTYPE ItemType;
        public SOInt SOItem;
        public Sprite icon;
    }
}