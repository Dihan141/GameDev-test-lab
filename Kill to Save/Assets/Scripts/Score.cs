using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int adder = 0;

    public void UpdateScore(int score)
    {
        adder += score;
        scoreText.text = adder.ToString();
    }
}
