using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource battleSound, saltExplosionSFDX, hitEnemySFDX;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayBattleSound();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            battleSound.volume += 0.1f;
        }
    }

    public void PlayBattleSound()
    {
        battleSound.Play();
    }

    public void StopBattleSound()
    {
        battleSound.Stop();
    }

    public void SaltExplosionSFDX()
    {
        saltExplosionSFDX.Play();
    }

    public void HitEnemySFDX()
    {
        hitEnemySFDX.Play();
    }
}
