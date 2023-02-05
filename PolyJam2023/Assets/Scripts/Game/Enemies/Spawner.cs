using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private List<Transform> SpawnPoints;
    [SerializeField] private float TimeBetweenWaves;
    [SerializeField] private int FirstWaveEnemyCount;
    [SerializeField] private int AdditionalEnemiesPerWave;
    [SerializeField] private float MinTimeForNewEnemy;
    [SerializeField] private float MaxTimeForNewEnemy;

    private int enemiesCount;
    [HideInInspector] public List<Enemy> enemiesSpawned = new List<Enemy>();

    void Start()
    {
        enemiesCount = FirstWaveEnemyCount;
        StartCoroutine(Cycle());
    }


    IEnumerator Cycle()
    {
        while (true)
        {
            int spawned = 0;
            while(spawned < enemiesCount)
            {
                var tmp = Instantiate(EnemyPrefab, SpawnPoints[Random.Range(0, SpawnPoints.Count)].position, Quaternion.identity)
                    .GetComponent<Enemy>();
                tmp.Spawner = this;
                enemiesSpawned.Add(tmp);
                spawned++;
                yield return new WaitForSeconds(Random.Range(MinTimeForNewEnemy, MaxTimeForNewEnemy));
            }

            yield return new WaitUntil(()=>enemiesSpawned.Count == 0);

            yield return new WaitForSeconds(TimeBetweenWaves);

            enemiesCount += AdditionalEnemiesPerWave;
        }
    }

}
