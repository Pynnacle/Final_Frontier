using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledObjects;
    public GameObject[] objectToPool;
    public int amountToPool;
    bool inActiveObjectFound = false;
    int randomRoom;

    // Start is called before the first frame update
    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool[Random.Range(0, objectToPool.Length)]);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        //1
        while(!inActiveObjectFound)
        {
            randomRoom = Random.Range(0, amountToPool);
            //2
            if (!pooledObjects[randomRoom].activeInHierarchy)
            {
                return pooledObjects[randomRoom];
            }
        }
        //3   
        return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
