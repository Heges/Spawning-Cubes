using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Factory")]
public class Factory : ScriptableObject
{
    public Config cubeConfig;
    [SerializeField] private MovingCube cube;

    public void Reclaim(MovingCube c)
    {
        Destroy(c.gameObject);
    }

    public MovingCube Get()
    {
        var instance = Instantiate(cube);
        instance.factory = this;
        instance.Initialize(cubeConfig);
        return instance;
    }
}
