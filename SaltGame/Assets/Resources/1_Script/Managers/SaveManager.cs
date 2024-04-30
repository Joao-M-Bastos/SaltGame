using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Xml;

using System.Runtime.Serialization.Formatters.Binary;


public class SaveManager : MonoBehaviour
{
    PlayerScrpt player;
    Save saved;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScrpt>();
    }

    private void OnLevelWasLoaded()
    {
        if (saved == null)
            return;

        //MARKER Enemy position
        for (int i = 0; i < saved.enemyPosition.Count; i++)
        {
            float enemyPos = saved.enemyPosition[i];
            float enemyDirection = saved.enemyDirection[i];

            GameObject enemy = Instantiate(Lists.GetEnemyById(0), new Vector3(enemyPos, 1f, 0), Quaternion.identity);

            enemy.transform.Rotate(new Vector3(0, 90 * enemyDirection, 0));
        }
        saved = null;
    }

    private Save CreateSaveObj() { 
        Save save = new Save();

        save.soulsNum = Wallet.GetWallet().GetSouls();
        save.currencyNum = Wallet.GetWallet().GetCurrency();
        save.tempCurrencyNum = Wallet.GetWallet().GetTempCurrency();

        save.playerPosition = player.transform.position.x;
        save.playerScene = CommomMetods.GetSceneCode();
        save.playerState = player.PlayerMachineControllerinstance.GetStateID();

        save.playerLife = player.CurrentLife;
        save.playerEnergy = (int)player.CurrentEnergy;

        save.numOfWavesDestroyed = GameManager.GetInstance().NumOfWavesDestroyed;

        BaseEnemy[] enemies = FindObjectsOfType<BaseEnemy>();
        
        foreach(BaseEnemy enemy in enemies)
        {
            save.enemyPosition.Add(enemy.transform.position.x);

            int direction = -1;

            if(enemy.transform.rotation.y > 0)
                direction = 1;


            save.enemyDirection.Add(direction);
        }

        return save;
    }

    #region Xml

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

        XmlElement playerStateElement = xmlDocument.CreateElement("StateIDNumber");
        playerStateElement.InnerText = save.playerState.ToString();
        root.AppendChild(playerStateElement);

        XmlElement playerSceneElement = xmlDocument.CreateElement("SceneNumber");
        playerSceneElement.InnerText = save.playerScene.ToString();
        root.AppendChild(playerSceneElement);

        XmlElement energyElement = xmlDocument.CreateElement("EnergyNumber");
        energyElement.InnerText = save.playerEnergy.ToString();
        root.AppendChild(energyElement);

        XmlElement lifeElement = xmlDocument.CreateElement("LifeNumber");
        lifeElement.InnerText = save.playerLife.ToString();
        root.AppendChild(lifeElement);

        XmlElement wavesDestroyedElement = xmlDocument.CreateElement("NumberOfWavesDestroyed");
        wavesDestroyedElement.InnerText = save.numOfWavesDestroyed.ToString();
        root.AppendChild(wavesDestroyedElement);

        XmlElement enemy, enemyPosition, enemyDirection;

        for (int i = 0; i < save.enemyPosition.Count; i++)
        {
            enemy = xmlDocument.CreateElement("Enemy");

            enemyPosition = xmlDocument.CreateElement("EnemyPosition");
            enemyPosition.InnerText = save.enemyPosition[i].ToString();
            enemy.AppendChild(enemyPosition);

            enemyDirection = xmlDocument.CreateElement("EnemyDirection");
            enemyDirection.InnerText = save.enemyDirection[i].ToString();
            enemy.AppendChild(enemyDirection);

            root.AppendChild(enemy);
        }
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
        if (File.Exists(Application.dataPath + "/DataXML.text"))
        {
            //LOAD THE GAME
            Save save = new Save();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/DataXML.text");

            //MARKER Get the SAVE FILE DATA from the FILE
            //XmlNodeList: Represents an ordered collection of nodes.
            XmlNodeList soulsElement = xmlDocument.GetElementsByTagName("SoulsNumber");
            int soulsNumCount = int.Parse(soulsElement[0].InnerText);
            save.soulsNum = soulsNumCount;

            XmlNodeList currencyElement = xmlDocument.GetElementsByTagName("CurrencyNumber");
            int currencyNumCount = int.Parse(currencyElement[0].InnerText);
            save.currencyNum = currencyNumCount;

            XmlNodeList tempCurrencyElement = xmlDocument.GetElementsByTagName("TempCurrencyNumber");
            int tempCurrencyElementCount = int.Parse(tempCurrencyElement[0].InnerText);
            save.tempCurrencyNum = tempCurrencyElementCount;

            XmlNodeList playerPositionElement = xmlDocument.GetElementsByTagName("PlayerPositionNumber");
            float playerPositionElementCount = float.Parse(playerPositionElement[0].InnerText);
            save.playerPosition = playerPositionElementCount;

            XmlNodeList playerStateElement = xmlDocument.GetElementsByTagName("StateIDNumber");
            int playerStateElementCount = int.Parse(playerStateElement[0].InnerText);
            save.playerState = playerStateElementCount;

            XmlNodeList playerSceneElement = xmlDocument.GetElementsByTagName("SceneNumber");
            int playerSceneElementCount = int.Parse(playerSceneElement[0].InnerText);
            save.playerScene = playerSceneElementCount;

            XmlNodeList energyElement = xmlDocument.GetElementsByTagName("EnergyNumber");
            int energyElementCount = int.Parse(energyElement[0].InnerText);
            save.playerEnergy = energyElementCount;

            XmlNodeList lifeElement = xmlDocument.GetElementsByTagName("LifeNumber");
            int lifeElementCount = int.Parse(lifeElement[0].InnerText);
            save.playerLife = lifeElementCount;

            XmlNodeList wavesDestroyedElement = xmlDocument.GetElementsByTagName("NumberOfWavesDestroyed");
            int wavesDestroyedElementCount = int.Parse(wavesDestroyedElement[0].InnerText);
            save.numOfWavesDestroyed = wavesDestroyedElementCount;

            //MARKER ADVANCED LOAD enemies positions and their status
            XmlNodeList enemies = xmlDocument.GetElementsByTagName("EnemyPosition");
            
            if (enemies.Count != 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    XmlNodeList enemyPosition = xmlDocument.GetElementsByTagName("EnemyPosition");
                    float enemyPos = float.Parse(enemyPosition[i].InnerText);
                    save.enemyPosition.Add(enemyPos);

                    XmlNodeList enemyDirection = xmlDocument.GetElementsByTagName("EnemyDirection");
                    int enemyDir = int.Parse(enemyDirection[i].InnerText);
                    save.enemyDirection.Add(enemyDir);
                }
            }

            


            //Load Wallet values
            Wallet.instance.ResetWallet();

            Wallet.instance.AddSoulsValue(save.soulsNum);

            Wallet.instance.AddCurrencyValue(save.currencyNum);
            Wallet.instance.SaveCurrency();

            Wallet.instance.AddCurrencyValue(save.tempCurrencyNum);

            //Game Manager and scene

            CanvasManager.GetInstance().Refade(0.5f);
            CommomMetods.GoToScene(save.playerScene);

            GameManager.GetInstance().SetLoadedInScene(true);
            GameManager.GetInstance().AddDestroyedWave(save.numOfWavesDestroyed);

            //Load Player Values

            player.transform.position = new Vector3(save.playerPosition, 0.6f, 0);            

            player.ReSetValues();

            player.LoseLife(3-save.playerLife);

            player.Tired(100 - save.playerEnergy);

            player.PlayerMachineControllerinstance.ChangeStateByID(save.playerState);

            saved = save;

            Debug.Log("XML Loaded");
        }
        else
        {
            Debug.Log("NOT FOUNDED XML");
        }
    }

    #endregion
    #region Json

    //Make Save Obj into Json
    public void SaveByJson()
    {
        Save save = CreateSaveObj();

        string jsonString = JsonUtility.ToJson(save);

        StreamWriter sw = new StreamWriter(Application.dataPath + "/JsonData.txt");

        sw.WriteLine(jsonString);
        sw.Close();

        Debug.Log("Saved By Json");
    }

    public void LoadByJson()
    {
        if(File.Exists(Application.dataPath + "/JsonData.txt"))
        {
            //Get json
            StreamReader sr = new StreamReader(Application.dataPath + "/JsonData.txt");
            string jsonString = sr.ReadToEnd();
            sr.Close();

            //Json to Save obj

            Save save = JsonUtility.FromJson<Save>(jsonString);

            //Load Wallet values
            Wallet.instance.ResetWallet();

            Wallet.instance.AddSoulsValue(save.soulsNum);

            Wallet.instance.AddCurrencyValue(save.currencyNum);
            Wallet.instance.SaveCurrency();

            Wallet.instance.AddCurrencyValue(save.tempCurrencyNum);

            //Game Manager and scene

            CanvasManager.GetInstance().Refade(0.5f);
            CommomMetods.GoToScene(save.playerScene);

            GameManager.GetInstance().SetLoadedInScene(true);
            GameManager.GetInstance().AddDestroyedWave(save.numOfWavesDestroyed);

            //Load Player Values

            player.transform.position = new Vector3(save.playerPosition, 0.6f, 0);

            player.ReSetValues();

            player.LoseLife(3 - save.playerLife);

            player.Tired(100 - save.playerEnergy);

            player.PlayerMachineControllerinstance.ChangeStateByID(save.playerState);

            saved = save;

            Debug.Log("Loaded By Json");
        }
        else
        {
            Debug.Log("Json not save");
        }
    }

    #endregion
}

