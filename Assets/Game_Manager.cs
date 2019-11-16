using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] float ObstacleDistance;
    int PreNumber;
    int RandomNumber;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartIfObjectPool();
        PreNumber = RandomNumber;
    }

    private void StartIfObjectPool()
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

    // Update is called once per frame
    void Update()
    {
        if (Obstacles != null) 
        {
            if (player.transform.position.z > ObstacleDistance)
            {
                for (int i = 0; i < Obstacles.Length+5; i++)
                {
                    RandomNumber = Random.Range(0, Obstacles.Length);
                    if (RandomNumber != PreNumber) 
                    {
                        break;
                    }
                }
                PreNumber = RandomNumber;
                Instantiate(Obstacles[RandomNumber], new Vector3(Obstacles[RandomNumber].transform.position.x, Obstacles[RandomNumber].transform.position.y, (player.transform.position.z + ObstacleDistance)), Quaternion.identity);
                //Obstacles[RandomNumber].transform.position = new Vector3(transform.position.x, transform.position.y, ObstacleDistance*2);
                Obstacles[RandomNumber].SetActive(true);
                ObstacleDistance += 10;
            }


        }
       
    }
}
