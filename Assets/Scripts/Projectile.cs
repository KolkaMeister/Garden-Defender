using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.right* speed* Time.deltaTime);

    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var attaker = collision.GetComponent<Attaker>();
        if (attaker)
        {
            attaker.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
