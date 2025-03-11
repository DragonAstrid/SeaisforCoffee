using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CoffeeMachine : MonoBehaviour
{
    List<ingredient> ingredients;

    [SerializeField]
    private GameObject TaffyLatteCowMilk, TaffyLatteKelpMilk;
    [SerializeField]
    private GameObject PufferTeaCowMilk, PufferTeaKelpMilk;
    [SerializeField]
    private GameObject HotCocoaCowMilk, HotCocoaKelpMilk;
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
            Instantiate(TaffyLatteKelpMilk);
            ingredients.Clear();
            return;
        }
        if (ingredients.Any(i => i.type == IngredientType.Taffy)
           && ingredients.Any(i => i.type == IngredientType.CowMilk)
           )
        {
            Instantiate(TaffyLatteCowMilk);
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
            Instantiate(PufferTeaKelpMilk);
            ingredients.Clear();
            return;

        }
        if (ingredients.Any(i => i.type == IngredientType.Pufferfish)
           && ingredients.Any(i => i.type == IngredientType.CowMilk)
           )
        {
            Instantiate(PufferTeaCowMilk);
            ingredients.Clear();
            return;
        }
        if (ingredients.Any(i => i.type == IngredientType.Chocolate)
           && ingredients.Any(i => i.type == IngredientType.KelpMilk)
           )
        {
            Instantiate(HotCocoaKelpMilk);
            ingredients.Clear();
            return;
        }
        if (ingredients.Any(i => i.type == IngredientType.Chocolate)
           && ingredients.Any(i => i.type == IngredientType.CowMilk)
           )
        {
            Instantiate(HotCocoaCowMilk);
            ingredients.Clear();
            return;
        }
        ingredients.Clear();
        gameManager.ResetIngredients();
    }



}
