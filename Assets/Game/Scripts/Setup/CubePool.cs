using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool
{
    private List<MovingCube> pool;
    private bool canGrow;
    private Factory factory;
    private int maxCapacity;
    public CubePool(int amountOfPool, bool growUP, Factory f)
    {
        factory = f;
        maxCapacity = amountOfPool;
        pool = new List<MovingCube>(maxCapacity);
        canGrow = growUP;
        GetPool();
    }

    private void GetPool()
    {
        for(int i = 0; i < maxCapacity; i++)
        {
            pool.Add(factory.Get());
        }
    }

    private MovingCube GetFree()
    {
        for(int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                return pool[i];
            }
        }

        if (canGrow)
        {
            pool.Add(factory.Get());
            return pool[pool.Count - 1];
        }

        return null;
    }

    public MovingCube Proccess()
    {
        return GetFree();
    }
}
