using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetDragged : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public bool mouseOver;
    public bool dragging;

    private Vector2 offset;
    private bool getOffset;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         
            if (mouseOver)
            {
                dragging = true;
                getOffset = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //if (dragging == true) { }
            dragging = false;
        }
    }

    private void Start()
    {
        dragging = false;
        mouseOver = false;
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (getOffset)
            {
                offset = mousePos - rb.position;
                getOffset = false;
            }
            rb.MovePosition(mousePos - offset);
        }
    }

    private void OnTriggerEnter2D(Collider2D collission)
    {
        mouseOver = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        mouseOver = false;
    }



}
