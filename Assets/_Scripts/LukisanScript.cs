using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukisanScript : MonoBehaviour
{
    private Vector2 mousePosition;
    private Vector2 dragoffset;

    private void OnMouseDown()
    {
        dragoffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition - dragoffset;
    }
}
