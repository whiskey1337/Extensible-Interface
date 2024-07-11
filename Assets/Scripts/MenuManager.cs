using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField] private CanvasGroup menuCG;
    public Menu menu;
    public bool isOpened = false;
    public int activeElement;
    public string content;
    public string header;

    private void Update()
    {
        content = menu.content;
        header = menu.header;
        activeElement = menu.activeElement;
    }

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
    }

    public void ShowMenu()
    {
        isOpened = true;
        menuCG.alpha = 1;
        menuCG.interactable = true;
        menuCG.blocksRaycasts = true;
    }

    public void HideMenu()
    {
        isOpened = false;
        menuCG.alpha = 0;
        menuCG.interactable = false;
        menuCG.blocksRaycasts = false;
    }
}
