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

    public void PositionCallback(int index, Action<string> callback)
    {
        callback?.Invoke(positions[index]);
    }
}
