using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour

{
    [SerializeField] GameObject playerPrefab;
    private GameObject lastPlayerSpawned;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPoint = new Vector3(0,4,0);
        lastPlayerSpawned=Instantiate(playerPrefab,spawnPoint,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(lastPlayerSpawned.transform.position.y<-10)
        lastPlayerSpawned=Instantiate(playerPrefab);    
    }
}
