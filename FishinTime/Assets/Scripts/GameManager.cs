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
            int xRandom = Random.Range(-5, 5);
            Vector3 randomPos = new Vector3(xRandom, -5, 0);
            //Instantiate feesh
            Instantiate(FishPrefab, randomPos, Quaternion.identity);

            //transfer enemy to 'EnemyContainer' gameobject.
            GameObject newEnemy = Instantiate(FishPrefab, randomPos, Quaternion.identity);

            //wait __ seconds 
            yield return new WaitForSeconds(3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
