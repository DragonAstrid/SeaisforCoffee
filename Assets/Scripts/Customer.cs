using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    private Sprite Neutral;
    [SerializeField]
    private Sprite Happy;
    [SerializeField]
    private Sprite Sad;
    [SerializeField]
    private Sprite Dead;

    [SerializeField]
    private ResultType Order;

    [SerializeField]
    private TextMeshProUGUI dialogueBox;

    [SerializeField]
    private GameManager gameManager;

    private SpriteRenderer spriteRenderer;
    public void RecieveObject(GameObject g)
    {
        Result r = g.GetComponent<Result>();
        if (r != null)
        {
            r.gameObject.SetActive(false);
            gameManager.ResetIngredients();

            if (r.type == Order)
            {
                spriteRenderer.sprite = Happy;
                dialogueBox.text = "BEST PUFFERFISH TEA IN THE OCEAN!!!!";
            }
            else
            {
                spriteRenderer.sprite = Sad;
                dialogueBox.text = "Day ruined.";
                if (r.type == ResultType.HotCocoa)
                {
                    spriteRenderer.sprite = Dead;
                    dialogueBox.text = "UEGHHHH";
                }
            }
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogueBox.text = "Pufferfish with kelp milk please.";
    }
    
   
}
