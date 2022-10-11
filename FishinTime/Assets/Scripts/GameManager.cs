using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject FishPrefab;
    public GameObject enemyContainer;

    public GameObject SharkPrefab;

    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;

    public bool SharkManager;
    

    // Start is called before the first frame update
    void Start()
    {


        /* this.Wait(2.5f, () =>
         {
             StartCoroutine(SpawnFish());
             Debug.Log("Bruh");
         });

         this.Wait(5.5f, () =>
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
        //infinite loop
        while (true)
        {

            Vector3 randomPos = new Vector3(Random.Range(10f, 10f), Random.Range(-2.0f, -8.0f));
           

            //transfer enemy to 'EnemyContainer' gameobject.
            GameObject newEnemy = Instantiate(FishPrefab, randomPos, Quaternion.identity);

            //wait __ seconds 
            yield return new WaitForSeconds(2f);

           
        }
    }

   /* IEnumerator SpawnSharks()
    {
        //infinite loop
        while (true)
        {

            Vector3 randomPos = new Vector3(Random.Range(10f, 10f), Random.Range(-2.0f, -8.0f));


            //transfer enemy to 'EnemyContainer' gameobject.
            GameObject newEnemy = Instantiate(SharkPrefab, randomPos, Quaternion.identity);

            //wait __ seconds 
            yield return new WaitForSeconds(5f);


        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        //if (Coroutine.(SpawnSharks))
       
    }    
}
