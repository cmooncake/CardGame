using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;    
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text attackText;
    public TMP_Text healthText;
    public TMP_Text storyText;
    public TMP_Text effectText;

    public Image backgroundImage;

    public Card card;

    // Start is called before the first frame update
    void Start()
    {
        ShowCard();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCard();
    }

    public void ShowCard()
    {
        if (card is MonsterCard monsterCard)
        {
            nameText.text = monsterCard.Name;
            attackText.text = "Attack: " + monsterCard.Attack.ToString();
            healthText.text = "Health: " + monsterCard.Healthpoint.ToString() + "/" + monsterCard.HealthpointMax.ToString();
            storyText.text = monsterCard.Story;
            effectText.text = "";
        }
        else if (card is SpellCard spellCard)
        {
            nameText.text = spellCard.Name;
            attackText.text = "";
            healthText.text = "";
            storyText.text = spellCard.Story;
            effectText.text = "Effect: " + spellCard.Effect;
        }
    }
}
