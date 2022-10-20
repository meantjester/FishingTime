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


    // Start is called before the first frame update
    void Start()
    {
        spawnFish = SpawnFish();

        StartCoroutine(spawnFish);

        spawnSharks = SpawnSharks();


        this.Wait(30.0f, () =>
        {
            StopAllCoroutines();
            StartCoroutine(spawnFish);
            Debug.Log("Bruh");
        });
    }

    IEnumerator SpawnFish()
    {
        int i = 0;

        //infinite loop
        while (i <= 10)
        {

            Vector3 randomPos = new Vector3(Random.Range(10f, 10f), Random.Range(-2.0f, -8.0f));


            //transfer enemy to 'EnemyContainer' gameobject.
            GameObject newEnemy = Instantiate(FishPrefab, randomPos, Quaternion.identity);

            i++;

            //wait __ seconds 
            yield return new WaitForSeconds(2f);

            


    }
    }

    IEnumerator SpawnSharks()
    {
        int i = 0;

        //infinite loop
        while (i <= 5)
        {

            Vector3 randomPos = new Vector3(Random.Range(10f, 10f), Random.Range(-2.0f, -8.0f));

            i++;

            //transfer enemy to 'EnemyContainer' gameobject.
            GameObject newEnemy = Instantiate(SharkPrefab, randomPos, Quaternion.identity);

            //wait __ seconds 
            yield return new WaitForSeconds(5f);


            this.Wait(15.0f, () =>
            {
                StopCoroutine(spawnFish);
                StartCoroutine(spawnSharks);
                Debug.Log("Bruh2");
            }
        );


        }
    }
    

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
    }

}
