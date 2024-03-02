using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCaller : MonoBehaviour
{
    [SerializeField] Wave[] possibleWaves;
    [SerializeField] int waveIndexValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMachineController>().ChangeState(other.GetComponent<PlayerMachineController>().combatState);
            
            if(waveIndexValue < 0)
                waveIndexValue = Random.Range(0, possibleWaves.Length);


            possibleWaves[waveIndexValue].StartWave();
        }
        Destroy(this);
    }
}
