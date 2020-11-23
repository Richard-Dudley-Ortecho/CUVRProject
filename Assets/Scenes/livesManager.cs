using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesManager : MonoBehaviour
{
    public int lives = 3;

    public Image heartOne;
    public Image heartTwo;
    public Image heartThree;

    // Start is called before the first frame update
    public void loseLife()
    {
        lives--;
        updateLife();
    }

    public void gainLife()
    {
        lives++;
        if (lives > 3)
        {
            lives--;
        }
        else
        {
            updateLife();
        }
        
    }

    private void updateLife()
    {
        if(lives == 3)
        {
            heartThree.enabled = true;
            heartTwo.enabled = true;
            heartOne.enabled = true;
        }
        else if (lives == 2)
        {
            heartThree.enabled = false;
            heartTwo.enabled = true;
            heartOne.enabled = true;
        }
        else if (lives == 1)
        {
            heartThree.enabled = false;
            heartTwo.enabled = false;
            heartOne.enabled = true;
        }
        else if (lives == 0)
        {
            heartThree.enabled = false;
            heartTwo.enabled = false;
            heartOne.enabled = false;
        }
    }

}
