using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;
    public PackOpening packOpening = null;

    public GameObject openingArea;

    public int children = 0;

    public int stop = 0;

    public void Start()
    {
        if (openingArea != null)
            children = openingArea.transform.childCount;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY)
            {
                d.placeholderParent = this.transform;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
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

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if(stop == 0)
            {
                if (typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.SHOP)
                {
                    stop++;
                    d.parentToReturnTo = this.transform;
                    StartCoroutine(gameObject.GetComponent<PackOpening>().Open());
                    //StartCoroutine(packOpening.Open());

                    Destroy(d.gameObject);
                    stop = 0;
                }
            }
        }
    }
}