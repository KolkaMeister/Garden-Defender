using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time of level in seconds!!!")]
    [SerializeField] float levelTime = 10f;
    private Slider slider;
    private LevelController levelController;
    private bool triggeredLevelFinished=false;
    void Start()
    {
        slider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
        var attackTime = levelTime * PlayerPrefsController.GetDifficulty()+ Time.timeSinceLevelLoad;
        StartCoroutine(StartLevelTimer(attackTime));
    }
    //void Update()
    //{

    //    slider.value = Time.timeSinceLevelLoad / levelTime;
    //    bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
    //    if (timerFinished)
    //    {
    //        levelController.LevelTimerIsFinished();
    //        triggeredLevelFinished = true;
    //    }
    //}

    private IEnumerator StartLevelTimer(float _levelTime)
    {
        var levelTime = _levelTime;
        while (!triggeredLevelFinished)
        {
        slider.value = Time.timeSinceLevelLoad / levelTime;
        var timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            levelController.LevelTimerIsFinished();
            triggeredLevelFinished = true;
        }
            yield return null;
        }
    }
}
