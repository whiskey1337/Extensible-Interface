using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        if (MenuManager.instance.IsOpened())
        {
            TooltipManager.ShowTooltip(MenuManager.instance.GetContent(), MenuManager.instance.GetHeader());
        }
        else
        {
            TooltipManager.HideTooltip();
        }

        if (!MenuManager.instance.IsOpened())
        {
            objectTrigger.Entered(false);
            MenuManager.instance.HideMenu();
        }

        if (Input.GetMouseButtonUp(0) && MenuManager.instance.IsOpened())
        {
            interactionObject.PositionCallback(MenuManager.instance.GetActiveElement(), CallbackOnOptionClicked);
            objectTrigger.Entered(false);
            MenuManager.instance.HideMenu();
            TooltipManager.HideTooltip();
        }
    }
    public void OnPointerEnter(PointerEventData eventData) 
    {
        MenuManager.instance.Opened(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MenuManager.instance.Opened(false);
    }

    static void CallbackOnOptionClicked(string message)
    {
        Debug.Log("Object attached to the " + message + " position");
    }
}
