using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject go;
    private Interaction interactionObject;
    private ObjectTrigger objectTrigger;

    private void Awake()
    {
        go = GameObject.FindGameObjectWithTag("Object");
        interactionObject = go.GetComponent<Interaction>();
        objectTrigger = go.GetComponent<ObjectTrigger>();
    }

    private void Update()
    {
        if (MenuManager.instance.isOpened)
        {
            TooltipManager.ShowTooltip(MenuManager.instance.content, MenuManager.instance.header);
        }
        else
        {
            TooltipManager.HideTooltip();
        }

        if (!MenuManager.instance.isOpened)
        {
            objectTrigger.isEntered = false;
            MenuManager.instance.HideMenu();
        }

        if (Input.GetMouseButtonUp(0) && MenuManager.instance.isOpened)
        {
            interactionObject.PositionCallback(MenuManager.instance.activeElement, CallbackOnOptionClicked);
            objectTrigger.isEntered = false;
            MenuManager.instance.HideMenu();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MenuManager.instance.isOpened = false;
    }

    static void CallbackOnOptionClicked(string message)
    {
        Debug.Log("Object attached to the " + message + " position");
    }
}
