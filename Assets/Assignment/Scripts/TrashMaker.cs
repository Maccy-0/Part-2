using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMaker : MonoBehaviour
{
    public GameObject Trash;
    float time;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Trash);
        Instantiate(Trash);
        time = 0;
        timer = 4;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            Instantiate(Trash);
            time = 0;
            timer = timer - 0.1f;
            if (timer < 0.2){ timer = 0.2f; }
        }
    }
}
