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
    public float spawnrateF = 3.5f;
    public float spawnrateS = 5.5f;


    // Start is called before the first frame update
    void Start()
    {
        
        spawnFish = SpawnFish();

        StartCoroutine(spawnFish);

        spawnSharks = SpawnSharks();


        
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


            this.Wait(5.0f, () =>
       {
           StopCoroutine(spawnFish);
           canspawnS = true;
           StartCoroutine(spawnSharks);
           Debug.Log("Bruh2");
       });

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
                StopAllCoroutines();
                StartCoroutine(spawnFish);
                canspawnF = true;
                Debug.Log("Bruh");
            });



        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (canspawnF)
        {
            canspawnS = false;
            StopCoroutine(spawnSharks);
        }

        if (canspawnS)
        {
            canspawnF = false;
            StopCoroutine(spawnFish);

        }
    }

    public void startGame()
    {
    }

}
