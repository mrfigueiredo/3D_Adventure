using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Inventory
{
    public class ItemLayout : MonoBehaviour

    {
        private ItemSetup _currentSetup;
        public Image uiIcon;
        public TextMeshProUGUI uiText;

        public void Load(ItemSetup setup)
        {
            _currentSetup = setup;
            UpdateUI();
            AttachSOUpdate();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _currentSetup.icon;
            uiText.text = _currentSetup.SOItem.GetValue().ToString();
        }

        private void AttachSOUpdate()
        {
            GetComponentInChildren<SOIntTextUpdate>().soInt = _currentSetup.SOItem;
        }

    }
}