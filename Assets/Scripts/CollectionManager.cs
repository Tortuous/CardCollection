using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour {

    public RectTransform collection;

    private List<Card> allCards = new List<Card>();
    private List<Card> collectedCards = new List<Card>();

    bool isCollectionOpen = false;

    public void CollectionOpenAndClose()
    {
        if (!isCollectionOpen)
        {
            isCollectionOpen = true;
            collection.anchoredPosition = new Vector2(0, 0);
        }
        else
        {
            isCollectionOpen = false;

            collection.anchoredPosition = new Vector2(0, -1005);
        }
    }
}