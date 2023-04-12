using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject enemyPrefab;
    public int enemiesToSpawn;

    public Transform[] spawnPositions;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesToSpawn == 0)
        {
            CancelInvoke();
        }
    }

    void SpawnEnemy ()
    {
       //Hacespawmn de un enemigo en un punto aleatorio
       //Transform selectedSpawn = spawnPositions[Random.Range(0, spawnPositions.Length)];

        //Instantiate(enemyPrefab, selectedSpawn.position, selectedSpawn.rotation);

        foreach (Transform spawn in spawnPositions) 
        {
            Instantiate(enemyPrefab, spawn.position, spawn.rotation);
        }

        /*for (int i = 0; i < spawnPosition.Length; i++)
        {
            Instantiate(enemyPrefab, spawnPositions[i].position, spawnPositions[i].rotacion);
        }*/

        /*int i = 0
        while(i < spawnPositions.Length)

        {
            Instantiate(enemyPrefab, spawnPositions[i].position, spawnPositions[i].rotacion);
            i++;
        }*/

        /*do 
        {
            Instantiate(enemyPrefab, spawnPositions[i].position, spawnPositions[i].rotacion);
            i++;
        }while(i < spawnPositions.Length);*/

        enemiesToSpawn--;
    }
}
