using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<ingredient> ingredients;

    public void ResetIngredients()
    {
        foreach (var item in ingredients)
        {
            item.ResetPosition();
            item.gameObject.SetActive(true);
        }
    }


}
