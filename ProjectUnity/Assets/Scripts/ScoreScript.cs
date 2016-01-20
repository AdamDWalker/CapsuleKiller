using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour{

    private static double score;

    private static Text waveDisplay;
    private static int waveCount;

    /// <summary>
    /// Get the score
    /// </summary>
    /// <returns>The score value</returns>
	public static double getScore()
    {
        return score;
    }

    void Start()
    {
        waveCount = 0;
        waveDisplay = GetComponent<Text>();
    }

    public static void updateWaveCount(int waveNum)
    {
        waveCount = waveNum;
    }

    void Update()
    {
        waveDisplay.text = "Wave: " + waveCount;
    }

    /// <summary>
    /// Increases the score by a certain value
    /// </summary>
    /// <param name="scoreValue">Score to increase by</param>
    public static void increaseScore(double scoreValue)
    {
        score += scoreValue;
        Debug.Log("Score increased to: " + score);
    }
}
