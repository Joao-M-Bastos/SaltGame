using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class SaveManager : MonoBehaviour
{
    PlayerScrpt player;

    private void Start()
    {
        player = GetComponent<PlayerScrpt>();
    }

    private Save CreateSaveObj() { 
        Save save = new Save();

        save.soulsNum = Wallet.GetWallet().GetSouls();
        save.currencyNum = Wallet.GetWallet().GetCurrency();
        save.tempCurrencyNum = Wallet.GetWallet().GetTempCurrency();

        save.playerPosition = player.transform.position.x;
        save.playerScene = CommomMetods.GetScene();

        save.playerLife = player.CurrentLife;
        save.playerTiredness = (int)player.CurrentEnergy;

        BaseEnemy[] enemies = FindObjectsOfType<BaseEnemy>();
        
        foreach(BaseEnemy enemy in enemies)
        {
            save.enemyPosition.Add(enemy.transform.position.x);
        }

        return save;
    }

    private void SaveByXLM()
    {
        Save save = CreateSaveObj();

        XmlDocument xmlDocument = new XmlDocument();

        #region Xml Elements

        XmlElement root = xmlDocument.CreateElement("Save");
        root.SetAttribute("File Name", "File_01");

        XmlElement soulsElement = xmlDocument.CreateElement("SoulsNumber");
        soulsElement.InnerText = save.soulsNum.ToString();
        root.AppendChild(soulsElement);

        #endregion

        xmlDocument.Save(Application.dataPath + "/DataXML.text");
        if(File.Exists(Application.dataPath + "/DataXML.text"))
        {
            Debug.Log("XML Saved");
        }
    }

    public void LoadByXLM()
    {

    }
}
