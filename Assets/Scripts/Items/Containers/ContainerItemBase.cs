using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContainerItemBase : MonoBehaviour
{
    public abstract void Collect();
    public abstract void ShowItem();
}
