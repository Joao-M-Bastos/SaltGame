using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CanvasStates
{
    InGame,
    PauseMenu
}

public class CanvasManager : MonoBehaviour
{

    [SerializeField] GameObject canvasInGame, canvasPauseMenu;
    [SerializeField] Text soulsText, currencyText, lifeText;

    CanvasStates currenteCanvasState;

    public CanvasStates CurrentCanvasState => currenteCanvasState;

    public void UpdadeSoulsText(int currentValue)
    {
        soulsText.text = currentValue.ToString();
    }

    public void UpdateCurrencyText(int currentValue, int tempValue)
    {
        currencyText.text = currentValue.ToString() + " : " + tempValue.ToString();
    }

    public void UpdadeLifeText(int currentValue)
    {
        lifeText.text = currentValue.ToString();
    }

    public void ChangeCanvas(CanvasStates state)
    {
        currenteCanvasState = state;

        canvasPauseMenu.SetActive( state == CanvasStates.InGame);
        canvasInGame.SetActive(state == CanvasStates.InGame || state == CanvasStates.PauseMenu);
    }
}
