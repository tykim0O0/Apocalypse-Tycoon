using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTextColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text targetText;
    public Color hoverColor = Color.white;
    public Color defaultColor = Color.black;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetText != null)
        {
            targetText.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetText != null)
        {
            targetText.color = defaultColor;
        }
    }
}