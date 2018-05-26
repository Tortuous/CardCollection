using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackOpening : MonoBehaviour {
    public Button addToCollection;
    public GameObject prefabCard;
    public Pack packScript = null;
    Card randomCard;

    public Dropzone dropzone;
    public Transform[] cardPositions;
    
    Card RandomizeCard(List<Card> cards)
    {
        randomCard = cards[Random.Range(0, cards.Count)];

        Debug.Log(randomCard);
        return randomCard;
    }

    public IEnumerator Open()
    {

        yield return new WaitForSeconds(1f);
        Destroy(dropzone.d.gameObject);
        dropzone.stop = 0;

        for (int i = 0; i < packScript.cardsContained; i++)
        {
            Debug.Log(RandomizeCard(packScript.cards));
            RandomizeCard(packScript.cards);
            GameObject packCard = Instantiate(prefabCard, transform.position, transform.rotation);
            packCard.transform.SetParent(transform);
            packCard.GetComponent<CardDisplay>().card = randomCard;
            packCard.transform.localScale = new Vector3(1, 1, 1);
        }
        PlayerPrefs.Save();
        yield return null;
    }
}