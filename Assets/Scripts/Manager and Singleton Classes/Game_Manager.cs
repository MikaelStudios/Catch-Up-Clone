using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] float FirstObstacleDistance;
    [SerializeField] float ObstacleDistance;
    [SerializeField] GameObject GemPrefab;
    public bool ShouldSpawnGem;
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
                CoinSpawner();
            }
        }
    }

    private void ObstacleGenerator()
    {
        Instantiate(Obstacles[RandomNumber], new Vector3(Obstacles[RandomNumber].transform.position.x, Obstacles[RandomNumber].transform.position.y, (player.transform.position.z + ObstacleDistance)), Obstacles[RandomNumber].transform.rotation);
        //Obstacles[RandomNumber].transform.position = new Vector3(transform.position.x, transform.position.y, ObstacleDistance*2);
        Obstacles[RandomNumber].SetActive(true);
        FirstObstacleDistance += ObstacleDistance;
    }

    private void CoinSpawner() 
    {
        ShouldSpawnGem = (Random.value < 0.19);
        if (ShouldSpawnGem == true) 
        {
            int No_Of_Gems = Random.Range(0, 4);
            int Distance = Random.Range(5, 10);
            for (int i = 0; i < No_Of_Gems; i++)
            {
                Instantiate(GemPrefab, new Vector3(Random.Range(1.3f, 5.3f), GemPrefab.transform.position.y, player.transform.position.z + Distance + ObstacleDistance), Quaternion.identity);
                Distance += Distance;
            }
        }
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
