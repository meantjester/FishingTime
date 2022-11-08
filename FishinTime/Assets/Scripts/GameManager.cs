using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public GameObject SharkPrefab;
    public GameObject FishPrefab;
    public GameObject enemyContainer;

    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;
    
    public IEnumerator spawnFish;

    public GameManager gm;

    public IEnumerator spawnSharks;

    public SpriteRenderer BottomImage;
    public SpriteRenderer TopImage;

    public bool canspawnF;
    public bool canspawnS;

    public int maxFish = 4;
    public int fishWaveSpawns = 50;
    public int maxShark = 3;
    public int sharkWaveSpawns = 3;

    public float spawnrateF = 3.5f;
    public float spawnrateS = 5.5f;
    public float fishCountdown = 0;
    public float sharkCountdown = 0;

    public GameObject[] FishArray;



    // Start is called before the first frame update
    void Start()
    {
       
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(canspawnF)
        {
            TopImage.color = Color.white;
            BottomImage.color = Color.white;

            if (fishCountdown >= spawnrateF)
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
                GameObject newEnemy = Instantiate(FishArray[Random.Range (0, FishArray.Length)], randomPos, Quaternion.identity);
                fishCountdown = 0;
            }

            else
                fishCountdown += Time.deltaTime;
        }

        if (canspawnS)
        {
            TopImage.color = Color.red;
            BottomImage.color = Color.red;
            Debug.Log ("Bruh");

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
