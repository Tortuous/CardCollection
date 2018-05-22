using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackOpening : MonoBehaviour {

    public Pack packScript;

    public Card randomPrefabCard;

    Card RandomizeCard(List<Card> cards)
    {
        randomPrefabCard = cards[Random.Range(0, cards.Count)];

        Debug.Log(randomPrefabCard);
        return randomPrefabCard;
    }

    public IEnumerator Open()
    {
        for(int i = 0; i < packScript.cardsContained; i++)
        {
            RandomizeCard(packScript.cards);
            Card packCard = Instantiate(randomPrefabCard, transform.position, transform.rotation);
        }
        yield return null;
    }
}