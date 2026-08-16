using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPackage : MonoBehaviour
{
    public GameObject cardPrefab;

    CardStore cardStore;
    GameObject cardPool;
    List<GameObject> cardList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        cardStore = GetComponent<CardStore>();
        cardPool = GameObject.Find("CardPool");
        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardPool.transform);
            cardList.Add(card);
            //card.GetComponent<CardDisplay>().card = cardStore.RandomCard();
        }
        cardPool.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickOpen()
    {
        cardPool.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            //GameObject card = Instantiate(cardPrefab, cardPool.transform);
            cardList[i].GetComponent<CardDisplay>().card = cardStore.RandomCard();
            if (!cardStore.playerData.playerCards.ContainsKey(cardList[i].GetComponent<CardDisplay>().card.Id))
            {
                cardStore.playerData.playerCards.Add(cardList[i].GetComponent<CardDisplay>().card.Id, 1);
            }
            else
            {
                cardStore.playerData.playerCards[cardList[i].GetComponent<CardDisplay>().card.Id] += 1;
            }
        }
        cardPool.SetActive(true);
        cardStore.SaveCardData();
        
    }
}
