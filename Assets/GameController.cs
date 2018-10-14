using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public Text maxScoreText;

    private int score = 0;
    private int maxScore = 0;
    private string saveFilename = "scores";

	// Use this for initialization
	void Start () {
        LoadScore();
        UpdateScoreText();
        UpdateMaxScoreText();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncScore()
    {
        score += 1;
        UpdateScoreText();

        if (score > maxScore)
        {
            maxScore = score;
            UpdateMaxScoreText();
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Player Max Score", maxScore);
        StreamWriter scores = File.CreateText(saveFilename);
        scores.WriteLine(maxScore);
        scores.Close();
    }

     public void LoadScore()
    {
        maxScore = 0;
        if (File.Exists(saveFilename)) {
            StreamReader scores = File.OpenText(saveFilename);
            int.TryParse(scores.ReadLine(), out maxScore);
            scores.Close();
            Debug.Log("Loaded max score: " + maxScore.ToString());
        } else {
            Debug.Log("Score file not found.");
            maxScore = PlayerPrefs.GetInt("Player Max Score");
        }

    }

    void UpdateScoreText()
    {
        scoreText.text = string.Format("SCORE: {0}", score);
        Debug.Log("ScoreText updated with " + score.ToString());
    }

    void UpdateMaxScoreText()
    {
        maxScoreText.text = string.Format("MAX: {0}", maxScore);
        Debug.Log("MaxScoreText updated with " + maxScore.ToString());
        Debug.Log("Max score text: " + maxScoreText.text);
    }
}
