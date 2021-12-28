using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text score;

    public void Start()
    {
        score.text = Score.adder.ToString();
        Score.adder = 0;
    }
}
