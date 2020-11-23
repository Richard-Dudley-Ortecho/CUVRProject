using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI poppedText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI levelText;

    int prepoppedNumber;
    int prescoreNumber;
    int precashNumber;
    int prelevelNumber;

    public BallSpawner bs;

    public int popped = 0;
    public int scoreTraker = 0;

    public void Start()
    {
        prepoppedNumber = 0;
        prescoreNumber = 0;
        precashNumber = 0;
        prelevelNumber = 0;
    }

    public void updateText()
    {
        if (
            prepoppedNumber != popped ||
            prescoreNumber != scoreTraker ||
            precashNumber != scoreTraker ||
            prelevelNumber != bs.currentLevel
            )
        {
            prepoppedNumber = popped;
            prescoreNumber = scoreTraker;
            precashNumber = scoreTraker;
            prelevelNumber = bs.currentLevel;

            poppedText.text = "BALLS POPPED: " + prepoppedNumber.ToString();
            scoreText.text = "SCORE: \n" + prescoreNumber.ToString();
            cashText.text = "Current Cash: \n" + precashNumber.ToString();

            if (prelevelNumber < 10)
            {
                levelText.text = "LEVEL: 0" + prelevelNumber.ToString();
            }
            else
            {
                levelText.text = "LEVEL: " + prelevelNumber.ToString();
            }

        }
    }
}
