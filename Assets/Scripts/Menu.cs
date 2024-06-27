using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Elements")]
    public Ring data;
    public MenuElement menuElementPrefab;
    protected MenuElement[] menuElements;
    protected Menu parent;

    [Header("Settings")]
    public float GapWidthDegree = 1f;
    public string path;

    [Header("Events")]
    public Action<string> callback;

    private void Start()
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
            menuElements[i].menuElement.fillAmount = 1f / data.elements.Length - GapWidthDegree / 360f;
            menuElements[i].menuElement.transform.localPosition = Vector3.zero;
            menuElements[i].menuElement.transform.localRotation = Quaternion.Euler(0, 0, stepLength / 2f + GapWidthDegree / 2f + i * stepLength);
            menuElements[i].menuElement.color = new Color(1f, 1f, 1f, 0.5f);

            //Иконка сектора
            menuElements[i].icon.transform.localPosition = menuElements[i].menuElement.transform.localPosition + Quaternion.AngleAxis(i * stepLength, Vector3.forward) * Vector3.up * iconDistance;
            menuElements[i].icon.sprite = data.elements[i].Icon;
        }
    }

    private void Update()
    {
        var stepLength = 360f / data.elements.Length;
        var mouseAngle = NormalizedAngle(Vector3.SignedAngle(Vector3.up, Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2), Vector3.forward) + stepLength / 2f);
        var activeElement = (int)(mouseAngle / stepLength);
        

        for (int i = 0; i < data.elements.Length; i++) 
        {
            if (i == activeElement)
            {
                menuElements[i].menuElement.color = new Color(1f, 1f, 1f, 0.75f);
            }
            else
            {
                menuElements[i].menuElement.color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
    }

    private float NormalizedAngle(float a) => (a + 360f) % 360f;
}
