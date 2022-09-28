using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject FishPrefab;
    public GameObject enemyContainer;

    private GameManager _gameManager;
    
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        _gameManager = GameObject.Find("SpawnManager").GetComponent<GameManager>();

        //Null check
        if (_gameManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL!");
        }

    }

    IEnumerator SpawnEnemies()
    {
        //infinite loop
        while (true)
        {
            //int yRandom = Random.Range(-8, 0);
            Vector3 randomPos = new Vector3(Random.Range(0f, 0f), Random.Range(-2.0f, -8.0f));
            //Instantiate feesh
            //Instantiate(FishPrefab, randomPos, Quaternion.identity);

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
