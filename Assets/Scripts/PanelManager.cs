using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    public GameObject shop;
    public GameObject pack;

    public void CloseShop()
    {
        shop.SetActive(false);
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }

    public void OpenPackOpening()
    {
        pack.SetActive(true);
    }

    public void ClosePackOpening()
    {
        pack.SetActive(false);
    }
}