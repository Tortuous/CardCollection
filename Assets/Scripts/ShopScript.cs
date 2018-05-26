using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {
    public PlayerInformation playerInformation;
    public GameObject packArea;

    public GameObject bronzePackPrefab;
    public GameObject silverPackPrefab;
    public GameObject goldPackPrefab;
    public GameObject bronze;
    public GameObject silver;
    public GameObject gold;

    public void Bronze()
    {
        bronze.gameObject.SetActive(true);
        silver.gameObject.SetActive(false);
        gold.gameObject.SetActive(false);
    }

    public void Silver()
    {
        bronze.gameObject.SetActive(false);
        silver.gameObject.SetActive(true);
        gold.gameObject.SetActive(false);
    }

    public void Gold()
    {
        bronze.gameObject.SetActive(false);
        silver.gameObject.SetActive(false);
        gold.gameObject.SetActive(true);
    }

    public void BuyBronze()
    {
        if (playerInformation.coins >= 100)
        {
            playerInformation.coins -= 100;
            playerInformation.bronzePacks++;
            GameObject packInst = Instantiate(bronzePackPrefab, transform.position, transform.rotation);
            packInst.transform.SetParent(packArea.transform);
        }
    }

    public void BuySilver()
    {
        if(playerInformation.coins >= 200)
        {
            playerInformation.coins -= 200;
            playerInformation.silverPacks++;
            GameObject packInst = Instantiate(silverPackPrefab, transform.position, transform.rotation);
            packInst.transform.SetParent(packArea.transform);
        }
    }

    public void BuyGold()
    {
        if (playerInformation.coins >= 300)
        {
            playerInformation.coins -= 300;
            playerInformation.goldPacks++;
            GameObject packInst = Instantiate(goldPackPrefab, transform.position, transform.rotation);
            packInst.transform.SetParent(packArea.transform);
            packInst.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}