using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public Text nameText;
    public Text descriptionText;

    public Image rarityImage;
    public Image artworkImage;
    public Image cardBackImage;

    public Text costText;
    public Text attackText;
    public Text healthText;
    
    PlayerInformation playerInformation;

	void Start () {

        nameText.text = card.name;
        descriptionText.text = card.description;

        rarityImage.sprite = card.raritySprite;
        artworkImage.sprite = card.artwork;
        cardBackImage.sprite = card.cardBack;

        costText.text = card.cost.ToString();
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();

        if (card.rarity == Card.Rarity.Rare)
        {
            rarityImage.color = Color.blue;
        }
        else if (card.rarity == Card.Rarity.Basic)
        {
            rarityImage.color = Color.white;
        }
        else if (card.rarity == Card.Rarity.Epic)
        {
            rarityImage.color = Color.magenta;
        }
    }

    public void TurnCard()
    {
       transform.Find("Back").gameObject.SetActive(false);
    }
}