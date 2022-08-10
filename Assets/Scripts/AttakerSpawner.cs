using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakerSpawner : MonoBehaviour
{
    private bool spawn = true;
    [SerializeField] private Attaker[] enemies;
    [SerializeField] private float minDelay=1f;
    [SerializeField] private float maxDelay=5f;
    

    private IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            SpawnEnemy();
        }
    }
    public void StopSpawner()
    {
        spawn = false;
    }
    private void SpawnEnemy()
    {
        Attaker newAttaker= Instantiate(enemies[Random.Range(0,enemies.Length)], transform.position, transform.rotation);
        newAttaker.transform.parent = transform;
    }
}
