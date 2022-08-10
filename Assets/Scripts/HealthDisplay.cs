using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] public int health = 100;
    Text healthText;

    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }


    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }
    public void GetDamage()
    {
        health--;
        UpdateDisplay();
        IfLose();
    }
    private void IfLose()
    {
        if (health<=0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
