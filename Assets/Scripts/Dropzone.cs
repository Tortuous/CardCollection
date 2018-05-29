using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;

    public Draggable d = null;

    public GameObject openingArea;
    public PlayerInformation playerInformation;

    public int children = 0;

    public int stop = 0;

    public void Start()
    {
        if (openingArea != null)
            children = openingArea.transform.childCount;
    }
    public void Update()
    {
        if (gameObject.tag == "OpeningArea")
            if(transform.childCount == 0)
                stop = 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY)
            {
                d.placeholderParent = this.transform;
            }
        }

        if (eventData.pointerEnter.GetComponent<Draggable>().tag == "Card")
        {
            if(Input.GetKeyDown(KeyCode.S)){
                playerInformation.coins += d.GetComponent<CardDisplay>().card.sellValue;
                PlayerPrefs.SetInt("coins", playerInformation.coins);
                Destroy(d.gameObject);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == transform)
        {
            if (typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY)
            {
                d.placeholderParent = d.parentToReturnTo;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "Dropped on " + gameObject.name);
        Debug.Log(transform.childCount);

        d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (stop == 0)
            {
                if (typeOfItem == d.typeOfItem)
                {
                    stop++;
                    d.parentToReturnTo = this.transform;
                    openingArea.GetComponent<PackOpening>().packScript = eventData.pointerDrag.gameObject.GetComponent<PackDisplay>().pack;
                    StartCoroutine(gameObject.GetComponent<PackOpening>().Open());
                }
            }
        }
    }
}