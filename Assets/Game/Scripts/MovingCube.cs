using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour, IMoveable
{
    public Factory factory { get; set; }
    private Vector3 direction;
    private Config config;

    public void Initialize(Config c)
    {
        config = c;
        direction = new Vector3(Random.Range(-1, 1.1f), Random.Range(-1, 1.1f), Random.Range(-1, 1.1f));
        ActiveUnactive();
    }

    public void ActiveUnactive()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void Resycle()
    {
        factory.Reclaim(this);
    }

    public void Move()
    {
        transform.Translate(direction * config.movingSpeed * Time.deltaTime);
        if (transform.position.magnitude > config.distToDesapear)
            ActiveUnactive();
    }

    private void Update()
    {
        Move();
    }
}
