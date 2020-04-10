using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler SharedInstance;

    public List<GameObject> roomPool;
    public List<GameObject> indicatorPool;
    public GameObject[] roomsToPool;
    public GameObject roomIndicatorPrefab;
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
        roomPool = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(roomsToPool[Random.Range(0, roomsToPool.Length)]);
            obj.SetActive(false);
            roomPool.Add(obj);
        }

        indicatorPool = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(roomIndicatorPrefab);
            obj.SetActive(false);
            indicatorPool.Add(obj);
        }
    }

    public GameObject GetPooledRoom()
    {
        //1
        while(!inActiveObjectFound)
        {
            randomRoom = Random.Range(0, amountToPool);
            //2
            if (!roomPool[randomRoom].activeInHierarchy)
            {
                return roomPool[randomRoom];
            }
        }
        //3   
        return null;
    }

    public GameObject GetPooledIndicator()
    {
        //1
        for (int i = 0; i < indicatorPool.Count; i++)
        {
            //2
            if (!indicatorPool[i].activeInHierarchy)
            {
                return indicatorPool[i];
            }
        }
        //3   
        return null;
    }

}
