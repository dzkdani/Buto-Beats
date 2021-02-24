using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{

    [SerializeField]
    Transform[] pos;

    [SerializeField]
    GameObject[] enemyPrefs;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    float cooldown = 1f;
    public float currCD;
    void Update()
    {
        if (LevelManager.Instance.isPlaying)
        {
            currCD -= Time.deltaTime;
            if (currCD <= 0)
            {
                if (Random.Range(0f, 1f) <= LevelManager.Instance.currLevel.enemy1_rate)
                    SpawnEnemy(0, Random.Range(0, 4));
                if (Random.Range(0f, 1f) <= LevelManager.Instance.currLevel.enemy2_rate)
                    SpawnEnemy(1, Random.Range(0, 4));
                if (Random.Range(0f, 1f) <= LevelManager.Instance.currLevel.enemy3_rate)
                    SpawnEnemy(2, Random.Range(0, 4));
                currCD += cooldown;
            }
        }

    }

    void SpawnEnemy(int enemyIdx, int laneIdx)
    {
        Instantiate(enemyPrefs[enemyIdx], pos[laneIdx].position, new Quaternion(), null);
    }

}
