using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoneyHandler : MonoBehaviour
{
    public float money = 100;
    public int score = 0;

    public GameObject ScoreText;
    public GameObject MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();

        MoneyText.gameObject.GetComponent<TextMeshProUGUI>().text = "Money: " + money.ToString();

        if (money < 0) money = 0;
    }
}
