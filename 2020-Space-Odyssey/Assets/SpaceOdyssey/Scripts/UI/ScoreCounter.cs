using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    //sets the default score value to zero
    public static int ScoreValue = 0;

    //sets a public Text to represent the score value
    public Text Score;

    //sets score as a given "text" UI 
    void Start()
    {
        Score = GetComponent<Text>();
    }

    //the text displayed on the score board is equal to the "Scores" function plus ScoreValue
    void Update()
    {
        Score.text = "" + ScoreValue;
    }
}
