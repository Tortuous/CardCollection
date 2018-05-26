using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour {

    public RectTransform collection;
    private Animator animator;

    private List<Card> allCards = new List<Card>();
    private List<Card> collectedCards = new List<Card>();

    bool isCollectionOpen = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CollectionOpenAndClose()
    {
        if (!isCollectionOpen)
        {
            isCollectionOpen = true;
            animator.SetBool("IsOpen", isCollectionOpen);
        }
        else
        {
            isCollectionOpen = false;
            animator.SetBool("IsOpen", isCollectionOpen);

            PlayerPrefs.Save();
        }
    }
}