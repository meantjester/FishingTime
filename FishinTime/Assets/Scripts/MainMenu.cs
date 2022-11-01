using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text ScoreText;

    public static MainMenu instance;

    int score = 0;


    private void Awake()
    {
        instance = this;
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {
        ScoreText.text = score.ToString() + "Score: ";
    }

    public void AddPoint()
    {
        score += 1;
        ScoreText.text = score.ToString() + "Score: ";
    }
}
