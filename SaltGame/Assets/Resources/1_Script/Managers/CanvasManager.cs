using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CanvasStates
{
    InGame,
    PauseMenu,
    FadeOut,
    FadeIn
}

public class CanvasManager : MonoBehaviour
{

    [SerializeField] GameObject canvasInGame, canvasPauseMenu;
    [SerializeField] Text soulsText, currencyText, lifeText;

    Animator cameraAnimator;
    float fadeCooldown;

    CanvasStates currentCanvasState;

    public CanvasStates CurrentCanvasState => currentCanvasState;

    static CanvasManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            cameraAnimator = Camera.main.GetComponent<Animator>();
        }

    }

    public static CanvasManager GetInstance()
    {
        return instance;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentCanvasState == CanvasStates.InGame)
            {
                ChangeCanvas(CanvasStates.PauseMenu);
            }
            else
            {
                ChangeCanvas(CanvasStates.InGame);
            }
        }
        WaitToFadeIn();
    }

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
        currentCanvasState = state;

        canvasPauseMenu.SetActive(currentCanvasState == CanvasStates.PauseMenu);
        Debug.Log(currentCanvasState == CanvasStates.PauseMenu);
        canvasInGame.SetActive(currentCanvasState == CanvasStates.InGame || currentCanvasState == CanvasStates.PauseMenu);

        if(currentCanvasState == CanvasStates.FadeIn)
            cameraAnimator.SetInteger("Fade", 0);

        if (currentCanvasState == CanvasStates.FadeOut)
            cameraAnimator.SetInteger("Fade", 1);
    }

    public void Refade(float time)
    {
        ChangeCanvas(CanvasStates.FadeOut);
        fadeCooldown = time;
    }

    private void WaitToFadeIn()
    {
        if (currentCanvasState != CanvasStates.FadeOut)
            return;

        if (fadeCooldown < 0)
        {
            ChangeCanvas(CanvasStates.FadeIn);
        }

        fadeCooldown -= Time.deltaTime;
    }
}
