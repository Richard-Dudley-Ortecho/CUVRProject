using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    private bool playingAnimation = false;
    private float timer = 0.0f;

    public bool inLevel = false;

    public float animationSpeed =1.0f;
    public BallSpawner bs;

    public void startLevel()
    {
        if (!inLevel)
        {
            inLevel = true;
            playingAnimation = true;
            bs.startLevel();
        }
        
    }

    private void Start()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    private void Update()
    {
       
        if (playingAnimation)
        {
            timer = Time.deltaTime;
            float blowUp = timer * animationSpeed;
            Vector3 checkScale = new Vector3(1.0f, 1.0f, 1.0f);

            Vector3 switchSmallBy = new Vector3(blowUp, blowUp, blowUp);

            if (transform.localScale == checkScale)
            {
                transform.localScale -= switchSmallBy;
            }
            else
            {
                transform.localScale += switchSmallBy;
            }

            if (transform.localScale.x >= checkScale.x)
            {
                playingAnimation = false;
            }
        }
        else if (timer != 0)
        {
            timer = 0;
        }
    }
}
