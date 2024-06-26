using System;
using System.Collections;
using System.Collections.Generic;
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

            //�������� �������
            menuElements[i].transform.localPosition = Vector3.zero;
            menuElements[i].transform.localRotation = Quaternion.identity;

            //�������
            menuElements[i].menuElement.fillAmount = 1f / data.elements.Length - GapWidthDegree / 360f;
            menuElements[i].menuElement.transform.localPosition = Vector3.zero;
            menuElements[i].menuElement.transform.localRotation = Quaternion.Euler(0, 0, -stepLength / 2f + GapWidthDegree / 2f + i * stepLength);
            menuElements[i].menuElement.color = new Color(1f, 1f, 1f, 0.5f);

            //������ �������
            menuElements[i].icon.transform.localPosition = menuElements[i].menuElement.transform.localPosition + Quaternion.AngleAxis(i * stepLength, Vector3.forward) * Vector3.up * iconDistance;
            menuElements[i].icon.sprite = data.elements[i].Icon;
        }
    }
}