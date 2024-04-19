using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScene : MonoBehaviour, InteractiveEntrance
{
    //ID da cena a carregar
    [SerializeField] int sceneCode;
    [SerializeField] int nextPositionCode;

    public int GetNextPositionCode()
    {
        return nextPositionCode;
    }

    public void SetNextPositionCode(int value)
    {
        nextPositionCode = value;
    }

    public void SetSceneCode(int value)
    {
        sceneCode = value;
    }

    public bool GoToNextPlace()
    {
        if (CommomMetods.GetSceneCode() != sceneCode)
        {
            StartCoroutine(ChangeScene());
            return true;
        }
        return false;
    }
    public IEnumerator ChangeScene()
    {
        CanvasManager.GetInstance().Refade(1f);
        yield return new WaitForSeconds(1f);
        GoToNextScene();
    }

    public void GoToNextScene()
    {
        Wallet.instance.SaveCurrency();
        Wallet.instance.ResetSouls();
        CommomMetods.GoToScene(sceneCode);
    }
}
