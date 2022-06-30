using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public float xSpawn = 0;
    public float zSpawn = 1;
    public float ySpawn = 0;
    private bool startPrefab = true;
    public float roadLength = 8;
    public int numberOfRoad = 4;
    private List<GameObject> activeRoad = new List<GameObject>();


    public Transform PlayerTransform;
    void Start()
    {
        SpawnRoad(Random.Range(1, roadPrefabs.Length));
    }

    void Update()
    {
        if (PlayerTransform.position.x - 166 > xSpawn - (numberOfRoad * roadLength))
        {
            SpawnRoad(Random.Range(1, roadPrefabs.Length));
            DeleteRoad();
        }
    }

    public void SpawnRoad(int roadIndex)
    {
        if (startPrefab){
        GameObject go = Instantiate(roadPrefabs[0], transform.right * xSpawn + transform.forward * zSpawn + transform.up * ySpawn, transform.rotation);
        activeRoad.Add(go);
        xSpawn += roadLength;
        startPrefab = false;
        }
        else
        {
            GameObject go = Instantiate(roadPrefabs[roadIndex], transform.right * xSpawn + transform.forward * zSpawn + transform.up * ySpawn, transform.rotation);
            activeRoad.Add(go);
            xSpawn += roadLength;    
        }
    }

    private void DeleteRoad()
    {
        if (activeRoad.Count == 4)
        {
            activeRoad[0].SetActive(false);
            activeRoad.RemoveAt(0);
        }
    }
    
}
