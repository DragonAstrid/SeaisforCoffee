using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeObject : MonoBehaviour
{
    public UnityEvent<GameObject> OnTakeObject;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Triggered");
        if(collision.gameObject.CompareTag("Object") && !Input.GetMouseButton(0))
        {
            //collision.gameObject.SetActive(false);
            OnTakeObject?.Invoke(collision.gameObject);
        }
    }



}
