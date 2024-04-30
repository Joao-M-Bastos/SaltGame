using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource battleSound;

    static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static SoundManager GetInstance()
    {
        return instance;
    }


    public void PlayBattleSound()
    {
        battleSound.Play();
    }
}
