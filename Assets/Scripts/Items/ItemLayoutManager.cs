using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory {
    public class ItemLayoutManager : MonoBehaviour
    {
        public ItemLayout prefabLayout;
        public Transform container;
        
        public List<ItemLayout> itemLayouts;

        public void Start()
        {
            CreateItems();
        }

        private void CreateItems()
        {
            foreach(var setup in ItemManager.Instance.items)
            {
                var item = Instantiate(prefabLayout, container);
                item.Load(setup);
            }
        }

    }
}