using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;
    
   private void Start()
    {
    
    }

   
    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(mousePos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
