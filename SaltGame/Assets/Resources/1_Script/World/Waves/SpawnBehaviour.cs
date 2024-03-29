using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public int amountToSpawn;
    [SerializeField] private Transform[] spawnPointTransforms;

    public void GerarRound(GameObject enemy, int amount, float inteval, float cooldown)
    {
        this.amountToSpawn += amount;
        StartCoroutine(WaitToSpawn(enemy, amount, inteval, cooldown));
    }

    public IEnumerator WaitToSpawn(GameObject enemy, int amount, float inteval, float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(Spawnar(enemy, amount, inteval));
    }

    private IEnumerator Spawnar(GameObject enemy, int amount, float inteval)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(inteval);
            NumOfEnemiesAlive.Add();
            this.amountToSpawn--;
            
            int r = Random.Range(0, 2);
            GameObject instance = Instantiate(enemy, spawnPointTransforms[r].position, spawnPointTransforms[r].rotation);
            instance.GetComponent<BaseEnemy>().SetPlayerPosition(this.transform);
        }
    }
}
