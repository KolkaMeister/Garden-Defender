using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile,gun;
    AttakerSpawner mySpawn;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "projectiles";
    void Start()
    {
        CreateProjectileParent();
        GetAttackLine();
        animator = FindObjectOfType<Animator>();
    }
    void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }
    void Update()
    {
         if (IsAttakerInLane())
        {
           animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
    public void Fire()
    {
       GameObject newProjectile =Instantiate(projectile, gun.transform.position, transform.rotation)as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
    private void GetAttackLine()
    {
        AttakerSpawner[] spawns = FindObjectsOfType<AttakerSpawner>();
        foreach (AttakerSpawner spawn in spawns)
        {
            if (transform.position.y == spawn.transform.position.y)
            {
                mySpawn = spawn;
            }
        }
    }
    private bool IsAttakerInLane()
    {
        return mySpawn.transform.childCount > 0;
    }
}
