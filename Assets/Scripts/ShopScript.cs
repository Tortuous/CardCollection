using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {
    public PlayerInformation playerInformation;
    public GameObject packArea;

    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip ffClip;

    public GameObject bronzePackPrefab;
    public GameObject silverPackPrefab;
    public GameObject goldPackPrefab;
    public GameObject bronze;
    public GameObject silver;
    public GameObject gold;

    public void Bronze()
    {
        audioSource.clip = audioClip1;
        audioSource.Play();
        bronze.gameObject.SetActive(true);
        silver.gameObject.SetActive(false);
        gold.gameObject.SetActive(false);
    }

    public void Silver()
    {
        audioSource.clip = audioClip1;
        audioSource.Play();
        bronze.gameObject.SetActive(false);
        silver.gameObject.SetActive(true);
        gold.gameObject.SetActive(false);
    }

    public void Gold()
    {
        audioSource.clip = audioClip1;
        audioSource.Play();
        bronze.gameObject.SetActive(false);
        silver.gameObject.SetActive(false);
        gold.gameObject.SetActive(true);
    }

    public void BuyBronze()
    {
        audioSource.clip = ffClip;
        audioSource.Play();
        if (playerInformation.coins >= 100)
        {
            playerInformation.coins -= 100;
            PlayerPrefs.SetInt("coins", playerInformation.coins);
            playerInformation.bronzePacks++;
            PlayerPrefs.SetInt("bronzePacks", playerInformation.bronzePacks);

            GameObject packInst = Instantiate(bronzePackPrefab, transform.position, transform.rotation);
            packInst.transform.SetParent(packArea.transform);
            packInst.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void BuySilver()
    {
        audioSource.clip = ffClip;
        audioSource.Play();
        if (playerInformation.coins >= 200)
        {
            playerInformation.coins -= 200;
            PlayerPrefs.SetInt("coins", playerInformation.coins);
            playerInformation.silverPacks++;
            PlayerPrefs.SetInt("silverPacks", playerInformation.silverPacks);

            GameObject packInst = Instantiate(silverPackPrefab, transform.position, transform.rotation);
            packInst.transform.SetParent(packArea.transform);
            packInst.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void BuyGold()
    {
        audioSource.clip = ffClip;
        audioSource.Play();
        if (playerInformation.coins >= 300)
        {
            playerInformation.coins -= 300;
            PlayerPrefs.SetInt("coins", playerInformation.coins);
            playerInformation.goldPacks++;
            PlayerPrefs.SetInt("goldPacks", playerInformation.goldPacks);

            GameObject packInst = Instantiate(goldPackPrefab, transform.position, transform.rotation);
            packInst.transform.SetParent(packArea.transform);
            packInst.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}