using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float maSpawnerTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SpawnEnemy), maSpawnerTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector3 min = transform.position; 
        Vector3 max = transform.position; 

        GameObject anEnemy = (GameObject)Instantiate(Enemy);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }

    void ReprogramSpawnEnmy()
    {
        float newSpawn;

        if (maSpawnerTime > 1f)
        {
            newSpawn = Random.Range(1f, maSpawnerTime);
        }
        else
        {
            newSpawn = 1f;
        }

        Invoke(nameof(SpawnEnemy), newSpawn);
    }
}
