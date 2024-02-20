using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public SpriteRenderer sr;
    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void Colour()
    {
        sr.color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), 1);
        Debug.Log(sr.color);
    }
}
