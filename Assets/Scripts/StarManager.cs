using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    [SerializeField]
    private Sprite emptyStar, halfStar, fullStar;

    private Image[] stars;

    private void Awake()
    {
        stars = GetComponentsInChildren<Image>();
    }

    public void UpdateUI(int score)
    {
        foreach (var item in stars)
        {
            item.sprite = emptyStar;
        }
        int HasHalfStar = score % 2;

        int FullStars = (score - HasHalfStar) / 2;
        for (int i = 0; i < FullStars; i++)
        {
            stars[i].sprite = fullStar;
        }
        if (HasHalfStar==1)
        {
            stars[FullStars].sprite = halfStar;
        }
    }
}
