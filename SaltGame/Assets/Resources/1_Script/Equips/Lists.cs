using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lists : MonoBehaviour
{
    [SerializeField] GameObject[] nonStaticSwords;
    private static GameObject[] swords;

    [SerializeField] GameObject[] nonStaticItens;
    private static GameObject[] itens;

    [SerializeField] GameObject[] nonStaticEnemies;
    private static GameObject[] enemies;

    private void Awake()
    {
        swords = nonStaticSwords;
        itens = nonStaticItens;
        enemies = nonStaticEnemies;
    }


    #region Get Sword
    public static GameObject GetSwordByName(string swordName)
    {
        foreach (GameObject go in swords)
        {
            if(go.name == swordName)
                return go;
        }

        return swords[0];
    }

    public static GameObject GetSwordById(int id)
    {
        return swords[id];
    }

    #endregion

    #region Get Item
    public static GameObject GetItemByName(string itemName)
    {
        foreach (GameObject go in itens)
        {
            if (go.name == itemName)
                return go;
        }

        return itens[0];
    }

    public static GameObject GetItemById(int id)
    {
        return itens[id];
    }
    #endregion

    #region Get Enemy
    public static GameObject GetEnemyByName(string enemyName)
    {
        foreach (GameObject go in enemies)
        {
            if (go.name == enemyName)
                return go;
        }

        return enemies[0];
    }

    public static GameObject GetEnemyById(int id)
    {
        return enemies[id];
    }
    #endregion
}
