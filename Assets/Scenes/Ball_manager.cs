using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_manager : MonoBehaviour
{
    public GameObject ballRed;
    public GameObject ballBlue;
    public int amount_of_objects = 5;
    public float speed = 40.0f;
    public float wobble = 8.0f;

    private float timer = 0.0f;
    private float deTimer = 0.0f;

    public int redPopped = 0;
    public int bluePopped = 0;

    List<GameObject> reds = new List<GameObject>();
    List<GameObject> blues = new List<GameObject>();
    List<Vector3> redOgPosition = new List<Vector3>();
    List<Vector3> blueOgPosition = new List<Vector3>();
    
    void Start()
    {
        
        // ()
        Vector3 offset = new Vector3(0,40,0);
        for (var i=0; i<amount_of_objects; i++) {
            reds.Add(Instantiate(ballRed, transform.position - offset, Quaternion.identity));
            blues.Add(Instantiate(ballBlue, transform.position - offset, Quaternion.identity));
        }
        Debug.Log("Yeet");
        Debug.Log(reds[0].transform.localScale);
        for (var i=0; i<amount_of_objects; i++) 
        {
            
            float randSca = Random.Range(4.0f, 20.0f);
            Vector3 randScale = new Vector3(randSca, randSca, randSca);
            redOgPosition.Add(resetBall(reds[i] , -40.0f*(float)(amount_of_objects) + (float)(i+1)*40.0f,randScale));
            randSca = Random.Range(4.0f, 20.0f);
            randScale = new Vector3(randSca, randSca, randSca);
            blueOgPosition.Add(resetBall(blues[i], -40.0f*(float)(amount_of_objects) + (float)(i+1)*40.0f,randScale));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //timer = 1;
        float deltaY = (timer * speed);
        float wobbleX = Mathf.Sin(deTimer) * wobble;
        float wobbleZ = Mathf.Sin(deTimer) * wobble * 0.5f;
        Vector3 deltaBallMov = new Vector3(0, deltaY, 0);
        timer = Time.deltaTime;
        deTimer += Time.deltaTime;
        for (var i=0; i<amount_of_objects; i++) {

            reds[i].transform.position = new Vector3(redOgPosition[i].x + wobbleX, reds[i].transform.position.y, redOgPosition[i].z + wobbleZ);
            blues[i].transform.position = new Vector3(blueOgPosition[i].x + wobbleX, blues[i].transform.position.y, blueOgPosition[i].z + wobbleZ);
            
            reds[i].transform.position += deltaBallMov;
            blues[i].transform.position += deltaBallMov;

            if(reds[i].transform.position.y >= 80) {
                float randSca = Random.Range(4.0f, 20.0f);
                Vector3 randScale = new Vector3(randSca, randSca, randSca);
                redOgPosition[i] = resetBall(reds[i], Random.Range(-90.0f, -20.0f),randScale);
            }
            if(blues[i].transform.position.y >= 80) {
                float randSca = Random.Range(4.0f, 20.0f);
                Vector3 randScale = new Vector3(randSca, randSca, randSca);
                blueOgPosition[i] = resetBall(blues[i], Random.Range(-90.0f, -20.0f),randScale);
            }
            
        }
    }

    Vector3 resetBall(GameObject ball, float height, Vector3 scale) 
    {
        Vector3 randPosition = new Vector3(Random.Range(-20.0f, 25.0f), height, Random.Range(-25.0f, 0.0f));
        ball.transform.position = randPosition;

        ball.transform.localScale = scale;

        return ball.transform.position;
    }

    public int increaseBluePopped()
    {
        bluePopped += 1;
        return bluePopped;
    }

    public int increaseRedPopped()
    {
        redPopped += 1;
        return redPopped;
    }
}
