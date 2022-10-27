using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public GameObject FishPrefab;
    public GameObject enemyContainer;

    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;
    
    public IEnumerator spawnFish;

    public GameObject SharkPrefab;
    

    public GameManager gm;

    public IEnumerator spawnSharks;

    public bool canspawnF;
    public bool canspawnS;

    public int maxFish = 4;
    public int fishWaveSpawns = 4;
    public int maxShark = 3;
    public int sharkWaveSpawns = 3;

    public float spawnrateF = 3.5f;
    public float spawnrateS = 5.5f;
    public float fishCountdown = 0;
    public float sharkCountdown = 0;



    // Start is called before the first frame update
    void Start()
    {
       
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(canspawnF)
        {
            if(fishCountdown >= spawnrateF)
            {
                if (fishWaveSpawns <= 0)
                {
                    canspawnS = true;

                    maxFish++;
                    fishWaveSpawns = maxFish;

                    canspawnF = false;
                }

                fishWaveSpawns--;
                Vector3 randomPos = new Vector3(Random.Range(10f, 10f), Random.Range(-2.0f, -8.0f));

                //transfer enemy to 'EnemyContainer' gameobject.
                GameObject newEnemy = Instantiate(FishPrefab, randomPos, Quaternion.identity);
                fishCountdown = 0;
            }

            else
                fishCountdown += Time.deltaTime;
        }

        if (canspawnS)
        {
            if (sharkCountdown >= spawnrateS)
            {
                if (sharkWaveSpawns <= 0)
                {
                    canspawnF = true;
                    
                    sharkWaveSpawns = maxShark;

                    canspawnS = false;
                }

                sharkWaveSpawns--;
                Vector3 randomPos = new Vector3(Random.Range(10f, 10f), Random.Range(-2.0f, -8.0f));

                //transfer enemy to 'EnemyContainer' gameobject.
                GameObject newEnemy = Instantiate(SharkPrefab, randomPos, Quaternion.identity);
                sharkCountdown = 0;
            }

            else
                sharkCountdown += Time.deltaTime;
        }

      
    }

    public void startGame()
    {
    }

}
