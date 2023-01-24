using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float yIncrement;

    public GameObject currCloudParent;
    public GameObject prevCloudParent;

    void Start() 
    {
        StartCoroutine(SpawnClouds());
    }

    private IEnumerator SpawnClouds() 
    {
        for (int i = 0; i < 12; i++) 
        {
            float spawnX = Random.Range(-8f, 8f);
            float spawnY = Random.Range(this.gameObject.transform.position.y + 5f, this.gameObject.transform.position.y + yIncrement);

            Vector2 cloudPos = new Vector2(spawnX, spawnY);
            
            GameObject newCloud = Instantiate(cloudPrefab, cloudPos, Quaternion.identity);
            newCloud.transform.parent = currCloudParent.transform;
        }
        yield return new WaitForSeconds(10f);

        prevCloudParent = currCloudParent;
        currCloudParent = new GameObject();

        Destroy(prevCloudParent);

        StartCoroutine(SpawnClouds());
    }
}
