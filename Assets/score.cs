using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    [SerializeField] int scoreQ;
    [SerializeField] TMP_Text scoreQUI;
    [SerializeField] int scoreP;
    [SerializeField] TMP_Text scorePUI;
    [SerializeField] int increasedFontSize = 100;
    [SerializeField] int normalFontSize = 70;
    [SerializeField] int highestScore;
    [SerializeField] TMP_Text recordUI;

    void Start()
    {
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        recordUI.text = "Record: " + highestScore.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            scoreQ++;
            scoreQUI.text = scoreQ.ToString();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            scoreP++;
            scorePUI.text = scoreP.ToString();
        }

        ActualizarUI();

        if (scoreQ > highestScore)
        {
            highestScore = scoreQ;
            PlayerPrefs.SetInt("HighestScore", highestScore);  
        }
        else if (scoreP > highestScore)
        {
            highestScore = scoreP;
            PlayerPrefs.SetInt("HighestScore", highestScore);  
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    void ActualizarUI()
    {

        if (scoreQ > scoreP)
        {
            scoreQUI.color = Color.green;
            scoreQUI.fontSize = increasedFontSize;
            scorePUI.color = Color.white;
            scorePUI.fontSize = normalFontSize;
        }

        else if (scoreP > scoreQ)
        {
            scorePUI.color = Color.green;
            scorePUI.fontSize = increasedFontSize;
            scoreQUI.color = Color.white;
            scoreQUI.fontSize = normalFontSize;
        }

        else
        {

            scoreQUI.color = Color.white;
            scoreQUI.fontSize = normalFontSize;

            scorePUI.color = Color.white;
            scorePUI.fontSize = normalFontSize;
        }

        recordUI.text = "Record: " + highestScore.ToString();

    }

    public void RestartGame()
    {
        scoreQ = 0;
        scoreP = 0;
        scoreQUI.text = scoreQ.ToString();
        scorePUI.text = scoreP.ToString();
    }
}
