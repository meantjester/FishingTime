/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkManager : MonoBehaviour
{
    public GameObject SharkPrefab;

    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;

    public GameManager gm;
  
    public IEnumerator spawnSharks;


    // Start is called before the first frame update
    void Start()
    {
        spawnSharks = SpawnSharks();

        StartCoroutine(spawnSharks);
    }

    IEnumerator SpawnSharks()
    {
        int i = 0;

        //infinite loop
        while (i <= 5)
        {

            Vector3 randomPos = new Vector3(Random.Range(10f, 10f), Random.Range(-2.0f, -8.0f));


            //transfer enemy to 'EnemyContainer' gameobject.
            GameObject newEnemy = Instantiate(SharkPrefab, randomPos, Quaternion.identity);
            i++;

            //wait __ seconds 
            yield return new WaitForSeconds(7.8f);

            this.Wait(10.0f, () =>
            {
                StopCoroutine(spawnSharks);
                gm.StartCoroutine("SpawnFish");
                Debug.Log("Bruh2");
            });

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
*/