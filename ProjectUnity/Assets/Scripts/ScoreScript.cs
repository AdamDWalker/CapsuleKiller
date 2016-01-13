using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    private static double score;

    /// <summary>
    /// Get the score
    /// </summary>
    /// <returns>The score value</returns>
	public static double getScore()
    {
        return score;
    }

    /// <summary>
    /// Increases the score by a certain value
    /// </summary>
    /// <param name="scoreValue">Score to increase by</param>
    public static void increaseScore(double scoreValue)
    {
        score += scoreValue;
        Debug.Log("Score increased. Score is now" + score);
    }
}
