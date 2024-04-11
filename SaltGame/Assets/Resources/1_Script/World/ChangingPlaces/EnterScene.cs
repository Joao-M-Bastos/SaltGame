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
        if (CommomMetods.GetScene() != sceneCode)
        {
            StartCoroutine(ChangeScene());
            return true;
        }
        return false;
    }
    public IEnumerator ChangeScene()
    {
        Camera.main.GetComponent<Animator>().SetInteger("Fade", 1);
        yield return new WaitForSeconds(1f);
        Camera.main.GetComponent<Animator>().SetInteger("Fade", 0);
        GoToNextScene();
    }

    public void GoToNextScene()
    {
        Wallet.instance.SaveCurrency();
        Wallet.instance.ResetSouls();
        CommomMetods.GoToScene(sceneCode);
    }
}
