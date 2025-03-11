using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<ingredient> ingredients;

    [SerializeField]
    private GameObject CustomerRoot;

    [SerializeField]
    private List<Customer> customerPrefabs;

    [SerializeField]
    private TextMeshProUGUI dialogueBox;

    [SerializeField]
    private StarManager starManager;

    [SerializeField]
    private GameObject loseScreen, winScreen;

    private Customer currentCustomer;

    private int customerIndex;

    private int score;

    public void ResetIngredients()
    {
        foreach (var item in ingredients)
        {
            item.ResetPosition();
            item.gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        customerIndex = 0;
        SpawnNewCustomer();
        score = 5;
        starManager.UpdateUI(score);
        Time.timeScale = 1;
    }

    public void OrderReceived(int scoredifference)
    {
        StartCoroutine(ResetGameCoroutine());
        score += scoredifference;
        starManager.UpdateUI(score);
        if (score <= 0)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        if (score >= 10)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private IEnumerator ResetGameCoroutine()
    {
        yield return new WaitForSeconds(5);
        Destroy(currentCustomer.gameObject);
        yield return new WaitForSeconds(5);
        customerIndex += 1;
        SpawnNewCustomer();

    }

    private void SpawnNewCustomer()
    {
        if (customerIndex>customerPrefabs.Count-1)
        {
            customerIndex = 0;
        }
        Customer C = Instantiate<Customer>(customerPrefabs[customerIndex], CustomerRoot.transform);
        C.gameManager = this;
        C.dialogueBox = dialogueBox;
        currentCustomer = C;
    }
}
