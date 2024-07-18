using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public Menu menu;

    private bool isOpened = false;
    private int activeElement;
    private string content;
    private string header;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        instance.menu.gameObject.SetActive(false);
    }

    private void Update()
    {
        content = menu.GetContent();
        header = menu.GetHeader();
        activeElement = menu.GetActiveElement();
    }
    
    public void ShowMenu()
    {
        isOpened = true;
        instance.menu.gameObject.SetActive(true);
    }

    public void HideMenu()
    {
        isOpened = false;
        instance.menu.gameObject.SetActive(false);
    }

    public bool IsOpened()
    {
        return isOpened;
    }

    public void Opened(bool value)
    {
        isOpened = value;
    }

    public int GetActiveElement()
    {
        return activeElement;
    }

    public string GetHeader()
    {
        return header;
    }

    public string GetContent()
    {
        return content;
    }
}
