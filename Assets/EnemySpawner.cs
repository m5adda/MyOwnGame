using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject mechantPrefab;
    [SerializeField]
    private GameObject GrandmechantPrefab;
    [SerializeField]
    private float mechantInterval = 3.5f;
    [SerializeField]
    private float GrandmechantInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(mechantInterval, mechantPrefab));
        StartCoroutine(spawnEnemy(GrandmechantInterval, GrandmechantPrefab));
    }

    private IEnumerator spawnEnemy(float interval , GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-8f, 8f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
