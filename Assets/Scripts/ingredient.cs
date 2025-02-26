using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType
{
    Taffy, KelpMilk, CowMilk, Pufferfish, Chocolate
}

public class ingredient : MonoBehaviour
{
    public IngredientType type;

    private Vector3 originalPosition;

    private GetDragged getDragged;

    private void Awake()
    {
        originalPosition = transform.position;
        getDragged = GetComponent<GetDragged>();
    }
    public void ResetPosition()
    {
        transform.position = originalPosition;
        getDragged.mouseOver = false;
        getDragged.dragging = false;
    }
}
