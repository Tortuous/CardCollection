using UnityEngine;

public class PanelManager : MonoBehaviour {

    public GameObject shop;
    public GameObject pack;
    public Animator animatorShop;
    public Animator animatorPack;
    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;

    bool isShopOpen = false;
    bool isOpeningOpen = false;

    public void ShopOpenAndClose()
    {
        if (!isShopOpen)
        {
            isShopOpen = true;
            animatorShop.SetBool("IsShopOpen", isShopOpen);
        }
        else
        {
            isShopOpen = false;
            animatorShop.SetBool("IsShopOpen", isShopOpen);
        }

        PlayerPrefs.Save();
    }

    public void OpeningOpenAndClose()
    {
        if (!isOpeningOpen)
        {
            isOpeningOpen = true;
            animatorPack.SetBool("IsOpeningOpen", isOpeningOpen);
        }
        else
        {
            isOpeningOpen = false;
            animatorPack.SetBool("IsOpeningOpen", isOpeningOpen);
        }

        PlayerPrefs.Save();
    }

    public void CloseShop()
    {
        ShopOpenAndClose();
        audioSource.clip = audioClip2;
        audioSource.Play();
    }

    public void OpenShop()
    {
        ShopOpenAndClose();
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    public void OpenPackOpening()
    {
        OpeningOpenAndClose();
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    public void ClosePackOpening()
    {
        OpeningOpenAndClose();
        audioSource.clip = audioClip2;
        audioSource.Play();
    }

    public void CloseGame()
    {
        audioSource.clip = audioClip2;
        audioSource.Play();
        PlayerPrefs.Save();
        Application.Quit();
    }
}