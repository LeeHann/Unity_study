using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    Image imgItem;

    public void UpdateSlot(Sprite item)
    {
        imgItem = GetComponent<Image>();
        imgItem.sprite = item;

        //RectTransform rect = GetComponent<RectTransform>(); 
        RectTransform rect = imgItem.rectTransform; //UI 요소라 이미 rectTransform을 가지고 있음

        rect.sizeDelta = item.textureRect.size; //Vector2 width, height //rectangle : 직사각형

    }
}
