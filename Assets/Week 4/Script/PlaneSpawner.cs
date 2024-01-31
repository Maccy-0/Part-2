using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject Plane;
    float time;
    float gate;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        gate = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > gate)
        {
            Instantiate(Plane);
            time = 0;
            gate = Random.Range(1, 5);
        }
    }
}
