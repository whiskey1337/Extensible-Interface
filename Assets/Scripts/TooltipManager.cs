using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    private static TooltipManager instance;

    public Tooltip tooltip;

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

    public static void ShowTooltip(string content, string header = "")
    {
        instance.tooltip.SetText(content, header);
        instance.tooltip.gameObject.SetActive(true);
    }

    public static void HideTooltip()
    {
        instance.tooltip.gameObject.SetActive(false);
    }
}
