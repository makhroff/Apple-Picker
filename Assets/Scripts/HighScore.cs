
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;
    public Text textHighScore;
    void Awake()
    { 
        if (PlayerPrefs.HasKey("H"))
        { 
            score = PlayerPrefs.GetInt("H");
        }

        PlayerPrefs.SetInt("H", score);
    }

    void Update()
    {
        textHighScore.text = "High Score: " + score;

        if (score > PlayerPrefs.GetInt("H"))
        {
            PlayerPrefs.SetInt("H", score);
        }
    }

}
