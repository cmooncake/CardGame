using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class PlayerData : MonoBehaviour
{
    public string playerName;
    public CardStore cardStore;
    public int playerCoins;
    public  Dictionary<int,int> playerCards = new Dictionary<int, int>();

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayerData()
    {
        string path = Application.dataPath + "/Datas/playerData.csv";
        string[] data = File.ReadAllLines(path);

        for(int i = 0; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            if(row[0] == "coins")
            {
                playerCoins = int.Parse(row[1]);
            }
            else if(row[0] == "card")
            {
                int cardId = int.Parse(row[1]);
                int number = int.Parse(row[2]);
                if(playerCards.ContainsKey(cardId))
                {
                    playerCards[cardId] += number;
                }
                else
                {
                    playerCards.Add(cardId, number);
                }
            }
        }
    }


    public void SavePlayerData()
    {
        List<string> datas = new List<string>();
        datas.Add("coins,"+playerCoins.ToString());
        foreach(var kvp in playerCards)
        {
            datas.Add("card,"+kvp.Key.ToString() + "," + kvp.Value.ToString());
        }
        string path = Application.dataPath + "/Datas/playerData.csv";
        File.WriteAllLines(path, datas);
    }
}
