using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject blockPrefabs;
    private PlayerController playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", 0.1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControlScript.GameOver == false)
        {
            Vector3 spawnPos = new Vector3(25, 0, 0);
            Instantiate(blockPrefabs, spawnPos, blockPrefabs.transform.rotation);
        }
    }
}
