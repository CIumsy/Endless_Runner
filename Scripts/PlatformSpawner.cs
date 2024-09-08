using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform refPoint;
    [SerializeField] float spaceBetweenPlatforms=2;
    [SerializeField] private GameObject lastCreatedPlatform;
    float lastPlatformWidth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lastCreatedPlatform.transform.position.x<refPoint.position.x)
        {
            Vector3 targetPosition = new Vector3(refPoint.position.x + lastPlatformWidth + spaceBetweenPlatforms,refPoint.position.y,0);
            lastCreatedPlatform=Instantiate(platformPrefab[UnityEngine.Random.Range(0,platformPrefab.Length)],targetPosition, Quaternion.identity);
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }
    }
}
