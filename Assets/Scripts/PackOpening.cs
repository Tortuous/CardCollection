using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackOpening : MonoBehaviour {

    public Button addToCollection;

    public Pack packScript;

    public GameObject randomPrefabCard;

    public void Start()
    {
        Debug.Log(packScript.cardsContained + " this is card amount");
    }

    GameObject RandomizeCard(List<GameObject> cards)
    {
        randomPrefabCard = cards[Random.Range(0, cards.Count)];

        Debug.Log(randomPrefabCard);
        return randomPrefabCard;
    }

    public IEnumerator Open()
    {

        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < packScript.cardsContained; i++)
        {
            Debug.Log(RandomizeCard(packScript.cards));
            RandomizeCard(packScript.cards);
            GameObject packCard = Instantiate(randomPrefabCard, transform.position, transform.rotation);
            packCard.transform.SetParent(transform);
        }

        yield return null;
    }
}