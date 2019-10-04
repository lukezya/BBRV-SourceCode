// Controls the movement of the instructions.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;
    public Transform placeHolderParent = null;

    GameObject placeHolder = null;
    GameObject test = null;
    public GameObject copy = null;

    public Transform originalSpot;
    bool isInsZone = false;
    public bool isDestroyZone = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        test = this.gameObject;
        //see if instruction zone
        ///if (this.transform.parent.name == "Instruction List Zone")
        if (this.transform.parent.gameObject.tag == "Instruction List Zone")
        {
            Debug.Log("THIS READ THE TAG");
            copy = Instantiate(this.gameObject, this.transform);
            isInsZone = true;
        }
        else
        {
            copy = this.gameObject;

            //create the placeholder
            placeHolder = new GameObject();
            placeHolder.transform.SetParent(this.transform.parent);
            LayoutElement le = placeHolder.AddComponent<LayoutElement>();
            le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            le.flexibleWidth = 0;
            le.flexibleHeight = 0;
            placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            //save the parent so can return to it if it is dropped in an invalid zone
            parentToReturnTo = this.transform.parent;

            placeHolderParent = parentToReturnTo;
        }
        //removes the instruction from the parent (instruction zone initially)
        copy.transform.SetParent(copy.transform.parent.parent);

        // makes it so that on pick up the instruction stops blocking the raycasting of the mouse so it can be detected by the alternative zones
        copy.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //moves instruction
        copy.transform.position = eventData.position;
        //test.transform.position = eventData.position;

        if (!isInsZone)
        {
            if (placeHolder.transform.parent != placeHolderParent)
                placeHolder.transform.SetParent(placeHolderParent);

            if (placeHolder.transform.parent.gameObject.tag != "Instruction List Zone") //only move if not the instruction zone
            {
                //move instruction between the other instructions
                int newSiblingIndex = placeHolderParent.childCount;

                for (int i = 0; i < placeHolderParent.childCount; i++)
                {
                    if (copy.transform.position.x < placeHolderParent.GetChild(i).position.x)
                    {
                        newSiblingIndex = i;

                        if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                            newSiblingIndex--;

                        break; //cant go further left
                    }
                }

                placeHolder.transform.SetSiblingIndex(newSiblingIndex);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //turn raycast blocking on again
        copy.GetComponent<CanvasGroup>().blocksRaycasts = true;
        test.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //sets card to saved parent
        copy.transform.SetParent(parentToReturnTo);

        copy.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());



        Destroy(placeHolder);
        copy = null;
        isInsZone = false;

        if (isDestroyZone == true)
        {
            Destroy(this.gameObject);
        }

    }



}
