using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField]public int stars = 100;
    Text starsText;

    void Start()
    {
        starsText = GetComponent<Text>();
        UpdateDisplay();
    }

    
    private void UpdateDisplay()
    {
        starsText.text = stars.ToString();
    }
    public void SpendStars(int price)
    {
        stars -= price;
        UpdateDisplay();
    }
    public void EarnStars(int price)
    {
        stars += price;
        UpdateDisplay();
    }
}
