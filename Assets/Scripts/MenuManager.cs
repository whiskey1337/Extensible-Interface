using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public Menu menu;
    public bool isOpened = false;
    [SerializeField] private CanvasGroup menuCG;

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
        menuCG.alpha = 0;
        menuCG.interactable = false;
        menuCG.blocksRaycasts = false;
    }

    public void HideMenu()
    {
        isOpened = false;
        menuCG.alpha = 1;
        menuCG.interactable = true;
        menuCG.blocksRaycasts = true;
    }
}
