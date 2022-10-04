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
    
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        //infinite loop
        while (true)
        {

            Vector3 randomPos = new Vector3(Random.Range(10f, 10f), Random.Range(-2.0f, -8.0f));
           

            //transfer enemy to 'EnemyContainer' gameobject.
            GameObject newEnemy = Instantiate(FishPrefab, randomPos, Quaternion.identity);

            //wait __ seconds 
            yield return new WaitForSeconds(5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }    
}
