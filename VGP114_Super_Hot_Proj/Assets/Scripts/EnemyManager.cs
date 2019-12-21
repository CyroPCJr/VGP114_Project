using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private WaitForSeconds waitingEnemy;
    private Dictionary<int, GameObject> EnemyPool;
    private List<int> keyList;
    private int spawnTime = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        waitingEnemy = new WaitForSeconds(5f); // Timer for spawn enemies.
        EnemyPool = new Dictionary<int, GameObject>();
        keyList = new List<int>();
        FindAllEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnEnemy());
    }

    void FindAllEnemy()
    {
        int count = 0;
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.CompareTag("Enemy"))
            {
                gameObj.SetActive(false);
                EnemyPool.Add(count, gameObj);
                count++;
            }
        }
    }

    public IEnumerator SpawnEnemy()
    {
        yield return waitingEnemy;
        if (EnemyPool.Count > 0)
        {
            keyList.Clear();
            foreach (var keyValue in EnemyPool)
            {
                keyList.Add(keyValue.Key);
            }
            spawnTime = Random.Range(0, keyList.Count);
            EnemyPool[keyList[spawnTime]].SetActive(true);
            EnemyPool.Remove(keyList[spawnTime]);
        }
    }
}
