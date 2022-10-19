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

        /*  this.Wait(5.5f, () =>
          {
              StopCoroutine(SpawnFish());
              Debug.Log("Bruh2");
          });

          this.Wait(10.5f, () =>
          {
              StartCoroutine(SpawnSharks());
              Debug.Log("Bruh3");
          });

          this.Wait(20.5f, () =>
          {
              StopAllCoroutines();
              Debug.Log("Bruh4");
          });
          */


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
                gm.StartCoroutine("SpawnSharks");
                Debug.Log("Bruh");
            }
        );


    }
    }

    IEnumerator SpawnSharks()
    {
        //infinite loop
        while (i <= 0)
        {

            Vector3 randomPos = new Vector3(Random.Range(10f, 10f), Random.Range(-2.0f, -8.0f));


            //transfer enemy to 'EnemyContainer' gameobject.
            GameObject newEnemy = Instantiate(SharkPrefab, randomPos, Quaternion.identity);

            //wait __ seconds 
            yield return new WaitForSeconds(5f);

            this.Wait(10.0f, () =>
            {
                StopCoroutine(spawnSharks);
                gm.StartCoroutine(spawnFish);
                Debug.Log("Bruh2");
            });

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
