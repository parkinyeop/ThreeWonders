using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    //자식 오브젝트 배열을 랜덤하게 생성한다
    public GameObject[] blockPrefabs;
    public float spawnInterval = 5f;
    float minSpawnInterval = 3f;
    public float spawnTime = 1f;
    public float difficultyFactor = 0.5f;
    float spawnPosX = 10f;
    public Vector3 spawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
       // spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
        spawnTime = 15;
        RunPlayerController player = FindObjectOfType<RunPlayerController>();
        player.PlayerDie += StopSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += spawnTime * Time.deltaTime;
        //블록의 생성 주기를 점점 빠르게 한다


        if (spawnTime > spawnInterval)
        {
            //랜덤하게 블록을 생성한다
            int blockIndex = Random.Range(0, blockPrefabs.Length);
            Instantiate(blockPrefabs[blockIndex], new Vector3(spawnPosX, blockPrefabs[blockIndex].transform.position.y, 0), blockPrefabs[blockIndex].transform.rotation);
            spawnTime = 1;
            spawnInterval -= difficultyFactor * Time.deltaTime;
            if (spawnInterval < minSpawnInterval)
            {
                spawnInterval = minSpawnInterval;
            }
        }

    }

    private void StopSpawn()
    {
        spawnTime = 0;
    }
}
