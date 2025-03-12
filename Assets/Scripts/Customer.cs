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
    private bool isHuman;

    [SerializeField]
    private ResultType Order;

    public TextMeshProUGUI dialogueBox;

    public GameManager gameManager;

    private SpriteRenderer spriteRenderer;
    public void RecieveObject(GameObject g)
    {
        Result r = g.GetComponent<Result>();
        if (r != null)
        {
            r.gameObject.SetActive(false);
            gameManager.ResetIngredients();
            int scoredifference = 0;

            if (r.type == Order)
            {
                spriteRenderer.sprite = Happy;
                dialogueBox.text = HappySuccessLine;
                scoredifference = 1;
            }
            else
            {
                spriteRenderer.sprite = Sad;
                dialogueBox.text = SadFailLine;
                scoredifference = -1;
                if (isHuman == true)
                {
                    if (r.type == ResultType.PufferTeaCowMilk
                        || r.type == ResultType.PufferTeaKelpMilk)
                    {
                        spriteRenderer.sprite = Dead;
                        dialogueBox.text = DeadPoisonLine;
                        scoredifference = -10;
                    }
                }
                else
                {
                    if (r.type == ResultType.TaffyCocoa
                        || r.type == ResultType.HotCocoaKelpMilk
                        || r.type == ResultType.HotCocoaCowMilk)
                    {
                        spriteRenderer.sprite = Dead;
                        dialogueBox.text = DeadPoisonLine;
                        scoredifference = -10;
                    }

                }
            }
            gameManager.OrderReceived(scoredifference);
        }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogueBox.text = NeutralOrderLine;
    }
    
   
}
