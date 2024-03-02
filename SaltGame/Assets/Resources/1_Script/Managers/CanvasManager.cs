using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Text textBox;
    public void UpdadeCurrencyText(int currentValue)
    {
        textBox.text = currentValue.ToString();
    }
}
