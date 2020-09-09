using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Color touchColor;
    Color originColor;
    Renderer render;

    private void Start() {
        render = GetComponent<Renderer>();
        originColor = render.material.color;
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log(other.gameObject.name + "에 부딪힘");
        if(other.tag == "Goal")
        {
            render.material.color = touchColor;
        }
    }

    private void OnTriggerStay(Collider other) {
        SetTouchColor(other.tag);
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Goal")
        {
            render.material.color = originColor;
        }
    }

    void SetTouchColor(string tag)
    {
        if(tag == "Goal")
        {
            render.material.color = touchColor;
        }
    }
}
