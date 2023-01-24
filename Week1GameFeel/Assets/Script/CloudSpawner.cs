using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public GameObject bubblePrefab;
    public float yIncrement;

    public GameObject currCloudParent;
    public GameObject prevCloudParent;

    void Start()
    {
        StartCoroutine(SpawnClouds(cloudPrefab, true));
    }

    public IEnumerator SpawnClouds(GameObject objectToSpawn, bool isMovingUp) 
    {
        for (int i = 0; i < 12; i++) 
        {
            float spawnX = Random.Range(-9f, 9f);
            float spawnY; 
            if (isMovingUp)
                spawnY = Random.Range(this.gameObject.transform.position.y + 8f, this.gameObject.transform.position.y + yIncrement);
            else 
                spawnY = Random.Range(this.gameObject.transform.position.y - 8f, this.gameObject.transform.position.y - yIncrement);

            Vector2 cloudPos = new Vector2(spawnX, spawnY);
            
            GameObject newCloud = Instantiate(objectToSpawn, cloudPos, Quaternion.identity);
            newCloud.transform.parent = currCloudParent.transform;
        }

        yield return new WaitForSeconds(10f);

        prevCloudParent = currCloudParent;
        currCloudParent = new GameObject();

        Destroy(prevCloudParent);

        StartCoroutine(SpawnClouds(objectToSpawn, isMovingUp));
    }
}
