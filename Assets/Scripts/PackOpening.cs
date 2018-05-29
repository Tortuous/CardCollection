using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackOpening : MonoBehaviour {
    public PlayerInformation playerInformation;
    public Button addToCollection;
    public GameObject prefabCard;
    public Pack packScript = null;
    Card randomCard;

    public Pack bronze;
    public Pack silver;
    public Pack gold;

    public Dropzone dropzone;
    public Transform[] cardPositions = new Transform[6];
    
    Card RandomizeCardBronze()
    {
        int randomNumber = Random.Range(0, 100);

        if(randomNumber <= 60)
        {
            randomCard = packScript.commons[Random.Range(0, packScript.commons.Count)];
        }
        else if (randomNumber > 61 && randomNumber <= 95)
        {
            randomCard = packScript.rares[Random.Range(0, packScript.rares.Count)];
        }
        else if (randomNumber > 95)
        {
            randomCard = packScript.epics[Random.Range(0, packScript.epics.Count)];
        }
        return randomCard;
    }
    Card RandomizeCardSilver()
    {
        int randomNumber = Random.Range(0, 100);

        if (randomNumber <= 55)
        {
            randomCard = packScript.commons[Random.Range(0, packScript.commons.Count)];
        }
        else if (randomNumber > 55 && randomNumber <= 85)
        {
            randomCard = packScript.rares[Random.Range(0, packScript.rares.Count)];
        }
        else if (randomNumber > 85)
        {
            randomCard = packScript.epics[Random.Range(0, packScript.epics.Count)];
        }
        return randomCard;
    }

    Card RandomizeCardGold()
    {
        int randomNumber = Random.Range(0, 100);

        if (randomNumber <= 50)
        {
            randomCard = packScript.commons[Random.Range(0, packScript.commons.Count)];
        }
        else if (randomNumber > 50 && randomNumber <= 80)
        {
            randomCard = packScript.rares[Random.Range(0, packScript.rares.Count)];
        }
        else if (randomNumber > 80)
        {
            randomCard = packScript.epics[Random.Range(0, packScript.epics.Count)];
        }
        return randomCard;
    }

    public IEnumerator Open()
    {
        yield return new WaitForSeconds(1f);
        Destroy(dropzone.d.gameObject);
        if (dropzone.d.gameObject.GetComponent<PackDisplay>().pack == bronze)
        {
            playerInformation.bronzePacks--;
            PlayerPrefs.SetInt("bronzePacks", playerInformation.bronzePacks);

            for (int i = 0; i < packScript.cardsContained; i++)
            {
                RandomizeCardBronze();

                GameObject packCard = Instantiate(prefabCard, transform.position, transform.rotation);
                packCard.transform.SetParent(transform);
                packCard.GetComponent<CardDisplay>().card = randomCard;
                packCard.transform.localScale = new Vector3(1, 1, 1);
                packCard.transform.position = cardPositions[i].position;
            }
        }
        else if (dropzone.d.gameObject.GetComponent<PackDisplay>().pack == silver)
        {
            playerInformation.silverPacks--;
            PlayerPrefs.SetInt("silverPacks", playerInformation.silverPacks);

            for (int i = 0; i < packScript.cardsContained; i++)
            {
                RandomizeCardSilver();

                GameObject packCard = Instantiate(prefabCard, transform.position, transform.rotation);
                packCard.transform.SetParent(transform);
                packCard.GetComponent<CardDisplay>().card = randomCard;
                packCard.transform.localScale = new Vector3(1, 1, 1);
                packCard.transform.position = cardPositions[i].position;
            }
        }
        else if (dropzone.d.gameObject.GetComponent<PackDisplay>().pack == gold)
        {
            playerInformation.goldPacks--;
            PlayerPrefs.SetInt("goldPacks", playerInformation.goldPacks);

            for (int i = 0; i < packScript.cardsContained; i++)
            {
                RandomizeCardGold();

                GameObject packCard = Instantiate(prefabCard, transform.position, transform.rotation);
                packCard.transform.SetParent(transform);
                packCard.GetComponent<CardDisplay>().card = randomCard;
                packCard.transform.localScale = new Vector3(1, 1, 1);
                packCard.transform.position = cardPositions[i].position;
            }
        }
        PlayerPrefs.Save();
        yield return new WaitForSeconds(0.5f);
        addToCollection.gameObject.SetActive(true);
        yield return null;
    }
}