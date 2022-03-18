using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Factory factory;
    [SerializeField] private float countDownSpawn;
    [SerializeField] private EventStringProvider changeMovingSpeed;
    [SerializeField] private EventStringProvider changeDistanceDesapear;
    [SerializeField] private EventStringProvider changeSpawnRate;

    private CubePool pool;
    private float likeTimerCoroutine;

    private void Start()
    {
        countDownSpawn = 1f;
        pool = new CubePool(5, true, factory);
        changeMovingSpeed.OnAction += ChangeMovingSpeed;
        changeDistanceDesapear.OnAction += ChangeDistanceToDesapear;
        changeSpawnRate.OnAction += ChangSpawnRate;
    }

    private void ChangSpawnRate(string text)
    {
        countDownSpawn = ParseString(text);
    }

    private void ChangeMovingSpeed(string text)
    {
        factory.cubeConfig.movingSpeed = ParseString(text);
    }

    private void ChangeDistanceToDesapear(string text)
    {
        factory.cubeConfig.distToDesapear = ParseString(text);
    }

    private float ParseString(string text)
    {
        float value;
        try
        {
            value = float.Parse(text, CultureInfo.CurrentCulture);
            return value;
        }
        catch (System.FormatException)
        {
            try
            {
                value = float.Parse(text, CultureInfo.InvariantCulture);
                return value;
            }
            catch (System.FormatException)
            {
                Debug.LogWarning("You were pass wrong value try to float");
                throw;
            }
        }
    }

    private void Update()
    {
        likeTimerCoroutine += Time.deltaTime;

        if(likeTimerCoroutine > countDownSpawn)
        {
            likeTimerCoroutine = 0;
            var obj = pool.Proccess();
            obj.transform.position = transform.position;
            obj.transform.parent = transform;
            obj.ActiveUnactive();
        }
    }
}
