using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaker : MonoBehaviour
{
    [Range(0f,3f)] float moveSpeed=0f;
    [SerializeField] int healthPoints = 200;
    [SerializeField] GameObject deathVFX;
    [SerializeField] int damage = 50;
    Defender currentTarger;
    void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }
    void OnDestroy()
    {
        if(FindObjectOfType<LevelController>()) FindObjectOfType<LevelController>().AttackerDestroyed();
    }


    void Update()
    {
        transform.Translate(Vector2.left*moveSpeed * Time.deltaTime);
        if (!currentTarger)
        {
            GetComponent<Animator>().SetBool("Attack", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void DealDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints<=0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }
    private void TriggerDeathVFX()
    {
        if (deathVFX==null)
        {
            return;
        }
        GameObject effect = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(effect, 1f);
    }
    public void Attack(Defender target)
    {
        GetComponent<Animator>().SetBool("Attack", true);
        currentTarger = target;
        
    }
    public void StrikeCurrentTarget()
    {
        if (!currentTarger)
        {
            return;
        }
        currentTarger.GetDamage(damage);

    }
    
}
