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
    private string NeutralOrderLine;
    [SerializeField]
    private string HappySuccessLine;
    [SerializeField]
    private string SadFailLine;
    [SerializeField]
    private string DeadPoisonLine;

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
                dialogueBox.text = HappySuccessLine;
            }
            else
            {
                spriteRenderer.sprite = Sad;
                dialogueBox.text = SadFailLine;
                if (r.type == ResultType.HotCocoa)
                {
                    spriteRenderer.sprite = Dead;
                    dialogueBox.text = DeadPoisonLine;
                }
            }
        }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogueBox.text = NeutralOrderLine;
    }
    
   
}
