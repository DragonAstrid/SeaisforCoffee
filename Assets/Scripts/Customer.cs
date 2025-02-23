using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public void RecieveObject(GameObject g)
    {
        Result r = g.GetComponent<Result>();
        if (r != null)
        {
            r.gameObject.SetActive(false);
        }
    }

}
