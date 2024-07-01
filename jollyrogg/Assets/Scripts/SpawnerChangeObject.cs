using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChangeObject : MonoBehaviour
{
    public float startTime;
    public float endTime;
    public List<GameObject> changeObjectPrefabs;
    public Vector3 spawnReferencePosition;
    public int amountChangeObject;
    public float timeCadence;
    public float initialWaitTime;

    // Update is called once per frame


    private IEnumerator ChangeObjectSpawnerCoroutine()
    {
        if (FindObjectOfType<Spawner>() != null)
        {
            startTime = 0;
        }
        else
        {
            startTime += Time.deltaTime;
            if (startTime >= endTime)
            {

                {
                    yield return new WaitForSeconds(initialWaitTime);
                    for (int i = 0; i < amountChangeObject; i++)
                    {
                        Vector3 randomPosition = new Vector3(-spawnReferencePosition.x, Random.Range(-spawnReferencePosition.y, spawnReferencePosition.y), spawnReferencePosition.z);  // x,y,z
                        SpawnChangeObject(randomPosition);
                    }
                    }
                }
            }
        }

    public void SpawnChangeObject(Vector3 changeObjectPosition)
    {
        int randomIndex = Random.Range(0, changeObjectPrefabs.Count);
        Instantiate(changeObjectPrefabs[randomIndex], changeObjectPosition, Quaternion.identity);
    }
}
