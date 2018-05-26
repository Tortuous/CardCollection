using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour {

    public Text coinsText;
    public Text packsText;

    public int bronzePacks = 0;
    public int silverPacks = 0;
    public int goldPacks = 0;

    public Button addToCollection;
    public GameObject collectionParent;

    public int receivedStartCoins = 0;

    public int coins = 0;
    public int packs = 0;

    public List<Draggable> collectedCards = new List<Draggable>();

    public Draggable[] playerCollection = new Draggable[50];
    public GameObject openingArea;

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("coins");
        bronzePacks = PlayerPrefs.GetInt("bronzePacks");
        silverPacks = PlayerPrefs.GetInt("silverPacks");
        silverPacks = PlayerPrefs.GetInt("bronzePacks");
        receivedStartCoins = PlayerPrefs.GetInt("receivedStartCoins");
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
    }

    private void Update()
    {
        packs = bronzePacks + silverPacks + goldPacks;

        coinsText.text = coins.ToString();
        packsText.text = packs.ToString();
    }

    public void GetCardsFromPack()
    {
        playerCollection = openingArea.GetComponentsInChildren<Draggable>();

        foreach (Draggable card in playerCollection)
        {
            collectedCards.Add(card);
        }

        for (int i = 0; i < playerCollection.Length; i++)
        {
            playerCollection[i].transform.SetParent(collectionParent.transform);
        }
    }

    public void AddCollection()
    {
        GetCardsFromPack();

        addToCollection.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }
}