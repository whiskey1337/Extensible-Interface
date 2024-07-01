using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField] private CanvasGroup menuCG;
    private bool isOpened = false;

    private void Update()
    {
        if (isOpened && Input.GetKeyDown(KeyCode.Escape))
        {
            menuCG.alpha = 0;
            menuCG.interactable = false;
            menuCG.blocksRaycasts = false;
        }
    }

    private void OnMouseEnter()
    {
        menuCG.alpha = 1;
        menuCG.interactable = true;
        menuCG.blocksRaycasts = true;
        isOpened = true;
    }
}
