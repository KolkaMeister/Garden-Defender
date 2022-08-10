using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] public int cost=40;
    [SerializeField] int earnAmount=20;
    [SerializeField] int HealthPoints=200;
    public void AddStars()
    {
        FindObjectOfType<StarsDisplay>().EarnStars(earnAmount);
    }
    public void GetDamage(int damage)
    {
        HealthPoints -= damage;
        if (HealthPoints<=0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
