using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Instructions that are dropped here get destroyed.

public class DestroyZone : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData)
    {
             Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
             d.isDestroyZone = true;
         }
    }

