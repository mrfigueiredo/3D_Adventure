using TMPro;
using UnityEngine;

public class SOIntTextUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI textMeshProUGUI;

    private void OnEnable()
    {
        soInt.OnEvent += UpdateTextAction;
    }

    private void OnDisable()
    {
        soInt.OnEvent -= UpdateTextAction;
    }

    private void Awake()
    {
        soInt.OnEvent += UpdateTextAction;
    }

    private void UpdateTextAction(int amount)
    {
        textMeshProUGUI.text = "x " + amount;
    }

}
