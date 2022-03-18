using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField spawnRateInputField;
    [SerializeField] private TMP_InputField movingSpeedInputField;
    [SerializeField] private TMP_InputField distanceDesapearInputField;
    [SerializeField] private EventStringProvider changeMovingSpeed;
    [SerializeField] private EventStringProvider changeDistanceDesapear;
    [SerializeField] private EventStringProvider changeSpawnRate;

    public void ChangeValueMoveSpeed()
    {
        changeMovingSpeed.RaiseEvent(movingSpeedInputField.text);
    }

    public void ChangeValueDistanceDesapear()
    {
        changeDistanceDesapear.RaiseEvent(distanceDesapearInputField.text);
    }

    public void ChangeValueSpawnRate()
    {
        changeSpawnRate.RaiseEvent(spawnRateInputField.text);
    }
}
