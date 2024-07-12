using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour  /*, IPointerEnterHandler, IPointerExitHandler */
{
    [Header("Elements")]
    [SerializeField] private Ring data;
    [SerializeField] private MenuElement menuElementPrefab;
    //[SerializeField] private CanvasGroup menuCG;
    //[SerializeField] private Interaction interactionObject; // ?
    protected MenuElement[] menuElements;

    [Header("Settings")]
    [SerializeField] private float gapWidthDegree = 1f;

    //private bool isOpened = false;
    public int activeElement;
    public string content;
    public string header;

    private void Awake()
    {
        CreateMenu();
    }

    private void Update()
    {
        /* if (interactionObject.isEntered)
        {
            ShowMenu();
        }

        if (isOpened)
        {
            TooltipManager.ShowTooltip(content, header);
        }
        else
        {
            TooltipManager.HideTooltip();
        } */

        /* if (Input.GetMouseButtonDown(1) && isOpened)
        {
            interactionObject.isEntered = false;
            HideMenu();
        } */

        SelectMenuOption();

        /* if (Input.GetMouseButtonUp(0) && isOpened)
        {
            interactionObject.PositionCallback(activeElement, CallbackOnOptionClicked);
            interactionObject.isEntered = false;
            HideMenu();
        } */
        
    }

    private void CreateMenu()
    {
        var stepLength = 360f / data.elements.Length;
        var iconDistance = Vector3.Distance(menuElementPrefab.icon.transform.position, menuElementPrefab.menuElement.transform.position);

        menuElements = new MenuElement[data.elements.Length];

        for (int i = 0; i < data.elements.Length; i++)
        {
            menuElements[i] = Instantiate(menuElementPrefab, transform);

            //Корневой элемент
            menuElements[i].transform.localPosition = Vector3.zero;
            menuElements[i].transform.localRotation = Quaternion.identity;

            //Секторы
            menuElements[i].menuElement.fillAmount = 1f / data.elements.Length - gapWidthDegree / 360f;
            menuElements[i].menuElement.transform.localPosition = Vector3.zero;
            menuElements[i].menuElement.transform.localRotation = Quaternion.Euler(0, 0, stepLength / 2f + gapWidthDegree / 2f + i * stepLength);
            menuElements[i].menuElement.color = new Color(1f, 1f, 1f, 0.65f);

            //Иконка сектора
            menuElements[i].icon.transform.localPosition = menuElements[i].menuElement.transform.localPosition + Quaternion.AngleAxis(i * stepLength, Vector3.forward) * Vector3.up * iconDistance;
            menuElements[i].icon.sprite = data.elements[i].Icon;
            menuElements[i].header = data.elements[i].Header;
            menuElements[i].content = data.elements[i].Content;
        }
    }

    private void SelectMenuOption()
    {
        var stepLength = 360f / data.elements.Length;
        var mouseAngle = NormalizedAngle(Vector3.SignedAngle(Vector3.up, Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2), Vector3.forward) + stepLength / 2f);
        activeElement = (int)(mouseAngle / stepLength);

        for (int i = 0; i < data.elements.Length; i++)
        {
            if (i == activeElement)
            {
                menuElements[i].menuElement.color = new Color(1f, 1f, 1f, 0.8f);
                content = menuElements[i].content;
                header = menuElements[i].header;
                
            }
            else
            {
                menuElements[i].menuElement.color = new Color(1f, 1f, 1f, 0.65f);
            }
        }
    }

    private float NormalizedAngle(float a) => (a + 360f) % 360f;

    /* static void CallbackOnOptionClicked(string message)
    {
        Debug.Log("Object attached to the " + message + " position");
    } */

    /* private void HideMenu()
    {
        isOpened = false;
        menuCG.alpha = 0;
        menuCG.interactable = false;
        menuCG.blocksRaycasts = false;
    }

    private void ShowMenu()
    {
        isOpened = true;
        menuCG.alpha = 1;
        menuCG.interactable = true;
        menuCG.blocksRaycasts = true;
    } */

    /* public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.ShowTooltip(content, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.HideTooltip();
    } */
}
