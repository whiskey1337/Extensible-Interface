using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    public bool isEntered = false;

    private void Update()
    {
        if (isEntered)
        {
            MenuManager.instance.ShowMenu();
        }
    }

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            isEntered = true;
        }
    }

    private void OnMouseExit()
    {
        isEntered = false;
    }
}
