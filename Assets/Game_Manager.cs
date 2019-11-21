using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] float FirstObstacleDistance;
    [SerializeField] float ObstacleDistance;
    // Variables for the random number generation
    int PreNumber; // stores the previous number
    int RandomNumber; // stores the Random Number

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartIfObjectPool();
        PreNumber = RandomNumber;
    }


    // Update is called once per frame
    void Update()
    {
        if (Obstacles != null) 
        {
            if (player.transform.position.z > FirstObstacleDistance)
            {
                RandomNumberGenerator();
                ObstacleGenerator();
            }


        }
       
    }

    private void ObstacleGenerator()
    {
        Instantiate(Obstacles[RandomNumber], new Vector3(Obstacles[RandomNumber].transform.position.x, Obstacles[RandomNumber].transform.position.y, (player.transform.position.z + ObstacleDistance)), Quaternion.identity);
        //Obstacles[RandomNumber].transform.position = new Vector3(transform.position.x, transform.position.y, ObstacleDistance*2);
        Obstacles[RandomNumber].SetActive(true);
        FirstObstacleDistance += ObstacleDistance;
    }

    private void RandomNumberGenerator()
    {
        for (int i = 0; i < Obstacles.Length + 5; i++)
        {
            RandomNumber = Random.Range(0, Obstacles.Length);
            if (RandomNumber != PreNumber)
            {
                break;
            }
        }
        PreNumber = RandomNumber;
    }
    private void StartIfObjectPool() // Just in Case i want to go back to object pool, which i should
    {
        if (Obstacles != null)
        {
            for (int i = 0; i < Obstacles.Length; i++)
            {
                GameObject Obs = Instantiate(Obstacles[i], transform.position, Quaternion.identity);
                Obstacles[i] = Obs;
                Obstacles[i].SetActive(false);
            }
        }
    }

}
