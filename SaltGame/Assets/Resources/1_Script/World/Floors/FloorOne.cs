using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorOne : MonoBehaviour
{
    int currentCorridor = 0;

    Transform playerTransform;

    [SerializeField] int minCorridors, maxCorridors;
    [SerializeField] GameObject[] listOfPossibleCorridors;
    [SerializeField] GameObject secretChestCorridor, safePointCorridor;
    Corridor[] corridors;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        int corridorsAmount = Random.Range(minCorridors, maxCorridors+1);
        corridors = new Corridor[corridorsAmount];

        for (int i = 0; i < corridorsAmount; i++)
        {
            corridors[i] = Instantiate(listOfPossibleCorridors[Random.Range(0, listOfPossibleCorridors.Length)]).GetComponent<Corridor>();
            

            
            corridors[i].GenerateCorridor(i);
        }
        corridors[0].FirstCorridor();
        corridors[corridorsAmount - 1].LastCorridor();

        corridors[Random.Range(0, corridorsAmount)].GenerateExtraCorridor(secretChestCorridor);

        if(!GameManager.GetInstance().IsLoadedInScene())
            playerTransform.position = corridors[0].GetEntrancePosition();
    }
}
