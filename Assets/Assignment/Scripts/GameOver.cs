using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


    public void EndGame()
    {
        SceneManager.LoadScene(4);
    }
}
