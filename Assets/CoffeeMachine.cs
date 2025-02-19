using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CoffeeMachine : MonoBehaviour
{
    List<ingredient> ingredients;

    [SerializeField]
    private GameObject BlueCircle;

      public void RecieveObject(GameObject g)
    {
       ingredient i = g.GetComponent<ingredient>();
        if (i != null) 
        {
        ingredients.Add(i);
        i.gameObject.SetActive(false);
            if (ingredients.Count == 2)
            {
                CreateResult();
            }
        }
    }

    void Awake()
    {
        ingredients = new List<ingredient> ();
    }

    public void CreateResult()
    {
        if (ingredients.Any(i => i.type == IngredientType.Red)
            && ingredients.Any(i => i.type == IngredientType.Green)
            )
        {
            Instantiate(BlueCircle);
            ingredients.Clear();
            return;
        }

    }


}
