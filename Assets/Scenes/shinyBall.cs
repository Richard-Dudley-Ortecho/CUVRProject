using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shinyBall : MonoBehaviour
{

    public Material BlueMat;
    public Material RedMat;
    public Material greyMat;

    public BallSpawner bs;
    public livesManager lm;
    public TextManager tm;

    public float blowUpSpeed = 1;
    public float goUpSpeed = 1;

    private bool colorChange = false;
    private bool lostLife = false;

    Material originalMat;
    AudioSource audioData;

    public float sizeBlowUp = -1;

    public void onCreation(float growInto)
    {
        audioData = GetComponent<AudioSource>();
        sizeBlowUp = growInto;

        int randomColor = Random.Range(1, 30);

        if (randomColor%2 == 0)
        {
            originalMat = BlueMat;
            
        }
        else
        {
            originalMat = RedMat;
        }

        GetComponent<Renderer>().material = greyMat;

        Vector3 ballSpawnSize = new Vector3(0.01f, 0.01f, 0.01f);

        transform.localScale = ballSpawnSize;
    }

    void Update()
    {
        //gotta blow up the balloon first
        float timer = Time.deltaTime;
        
        if (sizeBlowUp != -1)
        {
            if (transform.localScale.x < sizeBlowUp)
            {
                float blowUp = timer * blowUpSpeed;
                Vector3 ballGrowBy = new Vector3(blowUp * 2.0f, blowUp * 2.0f, blowUp * 2.0f);
                transform.localScale += ballGrowBy;

                Vector3 ballMoveBy = new Vector3(0, blowUp, 0);
                transform.position += ballMoveBy;
            }
            else
            {
                if (!colorChange)
                {
                    GetComponent<Renderer>().material = originalMat;
                }
                
                float deltaY = timer * goUpSpeed;
                Vector3 deltaBallMov = new Vector3(0, deltaY, 0);
                transform.position += deltaBallMov;
            }

            if (transform.position.y >= 40)
            {
                if(!lostLife)
                {
                    lm.loseLife();
                }
                lostLife = true;
                Destroy(this.gameObject);
            }
        }
        

        
        //if it goes to far up

    }

    public void hoverOverColorChange()
    {
        colorChange = true;
        GetComponent<Renderer>().material = greyMat;
    }

    public void changeBackColorChange()
    {
        colorChange = false;
        GetComponent<Renderer>().material = originalMat;
    }

    public void popBall()
    {
        audioData.Play(0);
        //will it play even after it died?
        GetComponent<Renderer>().material = greyMat;
        

        tm.popped += 1;

        float score;

        if (transform.localScale.x + 1.0f >= sizeBlowUp)
        {
            score = (int)transform.localScale.x;
            score = (1 / score) * 10000;
        }
        else
        {
            score = 0;
            //you get nothing if it isnt blown up
        }

        //4 would be .25* 10000 = 2500
        //20 would be .05*10000 = 500

        tm.scoreTraker += (int) score;

        Destroy(this.gameObject);
    }

}
