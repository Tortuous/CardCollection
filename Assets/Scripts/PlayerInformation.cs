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

    public string collectionString = "";

    public GameObject prefabCard;
    public GameObject packBPrefab;
    public GameObject packSPrefab;
    public GameObject packGPrefab;

    public Transform packArea;

    public Button addToCollection;
    public GameObject collectionParent;
    public List<CardDisplay> collectedCards = new List<CardDisplay>();
    public List<Card> cardList = new List<Card>();
    public CardDisplay[] playerCollection = new CardDisplay[50];
    public GameObject openingArea;

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("coins");
        bronzePacks = PlayerPrefs.GetInt("bronzePacks");
        silverPacks = PlayerPrefs.GetInt("silverPacks");
        goldPacks = PlayerPrefs.GetInt("goldPacks");
        receivedStartCoins = PlayerPrefs.GetInt("receivedStartCoins");
        collectionString = PlayerPrefs.GetString("collectionString");

        GetCollection(collectionString);
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

    public void GetCardsFromPack()
    {
        playerCollection = openingArea.GetComponentsInChildren<CardDisplay>();

        foreach (CardDisplay card in playerCollection)
        {
            collectedCards.Add(card);
        }

        for (int i = 0; i < playerCollection.Length; i++)
        {
            playerCollection[i].transform.SetParent(collectionParent.transform);
        }

        SaveCollection(playerCollection);
    }

    public void AddCollection()
    {
        GetCardsFromPack();

        addToCollection.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void GetCollection(string str)
    {
        string[] splitString = str.Split(new string[] { "#" }, StringSplitOptions.None);

        for(int i = 0; i < splitString.Length; i++)
        {
            int x = 0;

            if(Int32.TryParse(splitString[i], out x))
            {
                GameObject card = Instantiate(prefabCard, transform.position, transform.rotation);
                card.transform.SetParent(collectionParent.transform);
                card.GetComponent<CardDisplay>().card = cardList[x];
                card.gameObject.GetComponentInChildren<Button>().gameObject.SetActive(false);
                card.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void SaveCollection(CardDisplay[] array)
    {
        foreach(CardDisplay Card in array)
        {
            collectionString += '#' + Card.GetComponent<CardDisplay>().card.cardID.ToString();

            PlayerPrefs.SetString("collectionString", collectionString);
        }
    }
}