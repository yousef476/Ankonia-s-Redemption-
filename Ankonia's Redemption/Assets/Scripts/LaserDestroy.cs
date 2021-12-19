using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroy : MonoBehaviour
{
    public float timeTilDestroy;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeTilDestroy);
    }
}
