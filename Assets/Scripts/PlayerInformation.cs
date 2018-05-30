using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerInformation : MonoBehaviour {
    public Text coinsText;
    public Text packsText;

    public int bronzePacks = 0;
    public int silverPacks = 0;
    public int goldPacks = 0;

    public int receivedStartCoins = 0;

    public int coins = 0;
    public int packs = 0;

    public string collectionString = null;

    public PackOpening packOpening;
    
    public GameObject prefabCard;
    public GameObject packBPrefab;
    public GameObject packSPrefab;
    public GameObject packGPrefab;

    public Transform packArea;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    public AudioClip audioClip3;

    public Button addToCollection;
    public GameObject collectionParent;
    public GameObject openingArea;

    public List<CardDisplay> collectedCards = new List<CardDisplay>();
    public List<Card> cardList = new List<Card>();
    public List<CardDisplay> playerCollection = new List<CardDisplay>();

    public CardDisplay[] playColArray = new CardDisplay[50];

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("coins");
        bronzePacks = PlayerPrefs.GetInt("bronzePacks");
        silverPacks = PlayerPrefs.GetInt("silverPacks");
        goldPacks = PlayerPrefs.GetInt("goldPacks");
        receivedStartCoins = PlayerPrefs.GetInt("receivedStartCoins");
        collectionString = PlayerPrefs.GetString("collectionString");

        if(collectionString != null)
        {
            GetCollection(collectionString);
        }
    }

    private void Start()
    {
        if (receivedStartCoins == 0)
        {
            coins = 400;
            receivedStartCoins = 1;
            PlayerPrefs.SetInt("receivedStartCoins", receivedStartCoins);
            PlayerPrefs.SetInt("coins", coins);
        }

        for(int i = 0; i < bronzePacks; i++)
        {
            GameObject packB = Instantiate(packBPrefab, transform.position, transform.rotation);
            packB.transform.SetParent(packArea);
            packB.transform.localScale = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < silverPacks; i++)
        {
            GameObject packS = Instantiate(packSPrefab, transform.position, transform.rotation);
            packS.transform.SetParent(packArea);
            packS.transform.localScale = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < goldPacks; i++)
        {
            GameObject packG = Instantiate(packGPrefab, transform.position, transform.rotation);
            packG.transform.SetParent(packArea);
            packG.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Update()
    {
        packs = bronzePacks + silverPacks + goldPacks;

        coinsText.text = coins.ToString();
        packsText.text = packs.ToString();
    }

    public void SellCard(CardDisplay cardD)
    {
        if(playerCollection.Count > 1)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            coins += cardD.card.sellValue;
            PlayerPrefs.SetInt("coins", coins);

            playerCollection.Remove(cardD);
            collectedCards.Remove(cardD);
            Destroy(cardD.gameObject);
        }
        SaveCollection(playerCollection);
    }

    public void GetCardsFromPack()
    {
        playColArray = openingArea.GetComponentsInChildren<CardDisplay>();
        foreach(CardDisplay card in playColArray)
        {
            playerCollection.Add(card);
        }

        foreach (CardDisplay card in playerCollection)
        {
            collectedCards.Add(card);
        }

        for (int i = 0; i < playerCollection.Count; i++)
        {
            playerCollection[i].transform.SetParent(collectionParent.transform);
            playerCollection[i].sellPanel.SetActive(true);
            playerCollection[i].sellScript.playerInformation = this;
        }
        SaveCollection(playerCollection);
    }

    public void AddCollection()
    {
        audioSource.clip = audioClip3;
        audioSource.Play();
        GetCardsFromPack();
        addToCollection.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void GetCollection(string str)
    {
        string[] splitString = str.Split(new string[] { "#" }, StringSplitOptions.None);

        playerCollection.Clear();
        for(int i = 0; i < splitString.Length; i++)
        {
            int x = 0;

            if(Int32.TryParse(splitString[i], out x))
            {
                GameObject card = Instantiate(prefabCard, transform.position, transform.rotation);
                card.transform.SetParent(collectionParent.transform);
                card.GetComponent<CardDisplay>().card = cardList[x];
                card.transform.GetComponentInChildren<Button>().gameObject.SetActive(false);
                card.transform.localScale = new Vector3(1, 1, 1);
                card.GetComponent<CardDisplay>().sellPanel.SetActive(true);
                card.GetComponent<CardDisplay>().sellScript.playerInformation = this;
                playerCollection.Add(card.GetComponent<CardDisplay>());
            }
        }
    }

    public void SaveCollection(List<CardDisplay> array)
    {
        if(array.Count > 0)
        {
            collectionString = null;
            foreach (CardDisplay Card in array)
            {
                collectionString += '#' + Card.GetComponent<CardDisplay>().card.cardID.ToString();

                PlayerPrefs.SetString("collectionString", collectionString);
            }
        }
    }
}