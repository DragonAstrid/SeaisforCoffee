using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CoffeeMachine : MonoBehaviour
{
    List<ingredient> ingredients;

    [SerializeField]
    private GameObject TaffyLatte;
    [SerializeField]
    private GameObject PufferTea;
    [SerializeField]
    private GameObject HotCocoa;
    [SerializeField]
    private GameObject TaffyCocoa;

    [SerializeField]
    private GameManager gameManager;

    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
    }

    public void CreateResult()
    {
        audioSource.Play();

        if (ingredients.Any(i => i.type == IngredientType.Taffy)
            && ingredients.Any(i => i.type == IngredientType.KelpMilk)
            )
        {
            Instantiate(TaffyLatte);
            ingredients.Clear();
            return;
        }
        if (ingredients.Any(i => i.type == IngredientType.Taffy)
           && ingredients.Any(i => i.type == IngredientType.CowMilk)
           )
        {
            Instantiate(TaffyLatte);
            ingredients.Clear();
            return;
        }
        if (ingredients.Any(i => i.type == IngredientType.Taffy)
           && ingredients.Any(i => i.type == IngredientType.Chocolate)
           )
        {
            Instantiate(TaffyCocoa);
            ingredients.Clear();
            return;
        }
        if (ingredients.Any(i => i.type == IngredientType.Pufferfish)
           && ingredients.Any(i => i.type == IngredientType.KelpMilk)
           )
        {
            Instantiate(PufferTea);
            ingredients.Clear();
            return;

        }
        if (ingredients.Any(i => i.type == IngredientType.Pufferfish)
           && ingredients.Any(i => i.type == IngredientType.CowMilk)
           )
        {
            Instantiate(PufferTea);
            ingredients.Clear();
            return;
        }
        if (ingredients.Any(i => i.type == IngredientType.Chocolate)
           && ingredients.Any(i => i.type == IngredientType.KelpMilk)
           )
        {
            Instantiate(HotCocoa);
            ingredients.Clear();
            return;
        }
        if (ingredients.Any(i => i.type == IngredientType.Chocolate)
           && ingredients.Any(i => i.type == IngredientType.CowMilk)
           )
        {
            Instantiate(HotCocoa);
            ingredients.Clear();
            return;
        }
        ingredients.Clear();
        gameManager.ResetIngredients();
    }



}
