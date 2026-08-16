using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStore : MonoBehaviour
{
    public TextAsset cardData;
    public List<Card> cardList = new List<Card>();
    public PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        LoadCardData();
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
    }

    void LoadCardData()
    {
        string[] data = cardData.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            if (row[0] == "monster")
            {
                MonsterCard monsterCard = new MonsterCard(int.Parse(row[1]), row[2], row[3], int.Parse(row[4]), int.Parse(row[5]));
                cardList.Add(monsterCard);

                Debug.Log($"Loaded Monster Card: {monsterCard.Name}, Attack: {monsterCard.Attack}, Health: {monsterCard.Healthpoint}/{monsterCard.HealthpointMax}");
            }
            else if (row[0] == "spell")
            {
                SpellCard spellCard = new SpellCard(int.Parse(row[1]), row[2], row[3], row[4]);
                cardList.Add(spellCard);

                Debug.Log($"Loaded Spell Card: {spellCard.Name}, Effect: {spellCard.Effect}");
            }
        }
    }

    public void SaveCardData()
    {
        playerData.SavePlayerData();
    }

    Card GetCardById(int id)
    {
        return cardList.Find(card => card.Id == id);
    }

    public Card RandomCard()
    {
        int randomIndex = Random.Range(0, cardList.Count);
        return cardList[randomIndex];
    }
}
