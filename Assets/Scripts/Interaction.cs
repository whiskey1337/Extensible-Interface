using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEditor;

public class Interaction : MonoBehaviour
{
    private string[] positions = new string[] { "FRONT", "TOP", "RIGHT" };
    public bool isEntered = false;

    public void PositionCallback(int index, Action<string> callback)
    {
        callback?.Invoke(positions[index]);
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
