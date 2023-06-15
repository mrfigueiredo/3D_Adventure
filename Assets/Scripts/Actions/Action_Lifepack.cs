using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

public class Action_Lifepack : MonoBehaviour
{
    public KeyCode keyToHeal = KeyCode.L;
    public SOInt lifepackAmount;
    private PlayerBase _player;

    private void Start()
    {
        lifepackAmount = ItemManager.Instance.GetSetupByType(ITEMTYPE.LIFEPACK).SOItem;
        _player = FindObjectOfType<PlayerBase>();
    }

    private void RecoverLife()
    {
        if(lifepackAmount.GetValue() > 0)
        {
            ItemManager.Instance.RemoveItemByType(ITEMTYPE.LIFEPACK);
            _player.Heal();
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(keyToHeal))
        {
            RecoverLife();
        }
    }
}
