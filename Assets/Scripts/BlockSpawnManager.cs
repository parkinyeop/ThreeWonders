using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    //�ڽ� ������Ʈ �迭�� �����ϰ� �����Ѵ�
    public GameObject[] blockPrefabs;
    public float spawnInterval = 5f;
    float minSpawnInterval = 5f;
    public float spawnTime = 1f;
    public float difficultyFactor = 0.5f;

    //����� �����Ǵ� ��ġ
    public Vector3 spawnPos = new Vector3(25, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 15;
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
            Instantiate(blockPrefabs[blockIndex], spawnPos, blockPrefabs[blockIndex].transform.rotation);
            spawnTime = 1;
            spawnInterval -= difficultyFactor * Time.deltaTime;
            if (spawnInterval < minSpawnInterval)
            {
                spawnInterval = minSpawnInterval;
            }
        }

    }
}
