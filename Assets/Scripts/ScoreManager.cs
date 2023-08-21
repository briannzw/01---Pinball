using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public int Score { get { return score; } }

    private void Start()
    {
        ResetScore();
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
