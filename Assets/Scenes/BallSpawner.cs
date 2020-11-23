using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//put on spawner game object

public class BallSpawner : MonoBehaviour
{
    public shinyBall BallToClone;
    public int amount_of_objects = 4;
    public int currentLevel = 0;

    public float cumlativeTime = 0;

    public levelManager lm;
    public TextManager tm;

    List<GameObject> ballSpawned = new List<GameObject>();
    public List<Vector3> locateSpawn = new List<Vector3>();

    //List<Vector3> redOgPosition = new List<Vector3>();

    void Start()
    {
        foreach (Transform child in transform)
        {
            locateSpawn.Add(child.position);
        }
        
    }

    public void startLevel()
    {
        currentLevel++;
        amount_of_objects = currentLevel * 4;
        for(int i=0; i< amount_of_objects; i++)
        {
            spawnBall();
        }
        lm.inLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        tm.updateText();
    }

    void spawnBall()
    {
        int randomSpawnerIndex = Random.Range(0, locateSpawn.Count - 1);
        Vector3 spawnLocation = locateSpawn[randomSpawnerIndex];

        spawnLocation.y += 0.01f;

        shinyBall newBall = Instantiate(BallToClone, spawnLocation, Quaternion.identity);

        float randSca = Random.Range(4.0f, 15.0f);
        newBall.onCreation(randSca);

    }

}