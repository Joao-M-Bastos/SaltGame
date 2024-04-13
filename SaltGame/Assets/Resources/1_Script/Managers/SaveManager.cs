using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class SaveManager : MonoBehaviour
{
    [SerializeField]PlayerScrpt player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScrpt>();
    }

    private Save CreateSaveObj() { 
        Save save = new Save();

        save.soulsNum = Wallet.GetWallet().GetSouls();
        save.currencyNum = Wallet.GetWallet().GetCurrency();
        save.tempCurrencyNum = Wallet.GetWallet().GetTempCurrency();

        save.playerPosition = player.transform.position.x;
        save.playerScene = CommomMetods.GetScene();

        save.playerLife = player.CurrentLife;
        save.playerEnergy = (int)player.CurrentEnergy;

        BaseEnemy[] enemies = FindObjectsOfType<BaseEnemy>();
        
        foreach(BaseEnemy enemy in enemies)
        {
            save.enemyPosition.Add(enemy.transform.position.x);
        }

        return save;
    }

    public void SaveByXLM()
    {
        Save save = CreateSaveObj();

        XmlDocument xmlDocument = new XmlDocument();

        #region Xml Elements

        XmlElement root = xmlDocument.CreateElement("Save");
        root.SetAttribute("FileName", "File_01");

        XmlElement soulsElement = xmlDocument.CreateElement("SoulsNumber");
        soulsElement.InnerText = save.soulsNum.ToString();
        root.AppendChild(soulsElement);

        XmlElement currencyElement = xmlDocument.CreateElement("CurrencyNumber");
        currencyElement.InnerText = save.currencyNum.ToString();
        root.AppendChild(currencyElement);

        XmlElement tempCurrencyElement = xmlDocument.CreateElement("TempCurrencyNumber");
        tempCurrencyElement.InnerText = save.tempCurrencyNum.ToString();
        root.AppendChild(tempCurrencyElement);

        XmlElement playerPositionElement = xmlDocument.CreateElement("PlayerPositionNumber");
        playerPositionElement.InnerText = save.playerPosition.ToString();
        root.AppendChild(playerPositionElement);

        XmlElement playerSceneElement = xmlDocument.CreateElement("SceneNumber");
        playerSceneElement.InnerText = save.playerScene.ToString();
        root.AppendChild(playerSceneElement);

        XmlElement energyElement = xmlDocument.CreateElement("EnergyNumber");
        energyElement.InnerText = save.playerEnergy.ToString();
        root.AppendChild(energyElement);

        XmlElement lifeElement = xmlDocument.CreateElement("LifeNumber");
        lifeElement.InnerText = save.playerLife.ToString();
        root.AppendChild(lifeElement);

        #endregion

        xmlDocument.AppendChild(root);

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
