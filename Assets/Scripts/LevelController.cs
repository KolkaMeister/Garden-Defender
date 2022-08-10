using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int countOfAttackers = 0;
    bool levelTimeIsGone = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    public void AttackerSpawned()
    {
        countOfAttackers++;
    }
    public void AttackerDestroyed()
    {
        countOfAttackers--;
        if (countOfAttackers<=0 && levelTimeIsGone)
        {
            StartCoroutine(OnLevelEnd());
        }
    }
    IEnumerator OnLevelEnd()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoad>().LoadNextScene();
    }
    public void LevelTimerIsFinished()
    {
        levelTimeIsGone = true;
        StopSpawners();
    }
    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
    private void StopSpawners()
    {
        AttakerSpawner[] spawners = FindObjectsOfType<AttakerSpawner>();
        foreach (AttakerSpawner spawner in spawners)
        {
            spawner.StopSpawner();
        }
    }
}
