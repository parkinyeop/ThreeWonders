using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    //�ڽ� ������Ʈ �迭�� �����ϰ� �����Ѵ�
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
        //����� ���� �ֱ⸦ ���� ������ �Ѵ�


        if (spawnTime > spawnInterval)
        {
            //�����ϰ� ����� �����Ѵ�
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
