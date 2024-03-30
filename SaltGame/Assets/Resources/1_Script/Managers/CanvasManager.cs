using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Text soulsText, lifeText;
    public void UpdadeSoulsText(int currentValue)
    {
        soulsText.text = currentValue.ToString();
    }

    public void UpdadeLifeText(int currentValue)
    {
        lifeText.text = currentValue.ToString();
    }
}
