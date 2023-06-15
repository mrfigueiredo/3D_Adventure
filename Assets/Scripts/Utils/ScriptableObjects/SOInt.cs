using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class SOInt : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private int initialValue;

    [NonSerialized]
    private int value;

    public UnityAction<int> OnEvent;

    public void SetValue(int newValue)
    {
        value = newValue;
        ChangeEvent(value);
    }

    public int GetValue()
    {
        return value;
    }

    public void AddValue(int addValue)
    {
        value += addValue;
        ChangeEvent(value);
    }

    public void RemoveValue(int addValue)
    {
        value -= addValue;
        ChangeEvent(value);
    }

    public void OnAfterDeserialize()
    {
        value = initialValue;
    }

    public void OnBeforeSerialize() { }

    private void ChangeEvent(int value)
    {
        OnEvent?.Invoke(value);
    }

}