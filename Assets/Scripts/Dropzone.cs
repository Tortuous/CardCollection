using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;
    public PackOpening packOpening;

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
            if (typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.SHOP)
            {
                d.parentToReturnTo = this.transform;
                StartCoroutine(packOpening.Open());
            }
        }
    }
}