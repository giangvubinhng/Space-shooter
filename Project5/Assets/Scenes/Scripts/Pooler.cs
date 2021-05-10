using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size = 3;

        public void increasePool(int capacity)
        {
            size = capacity;
        }
    }

    public static Pooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;
    // Start is called before the first frame update
    void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject gameObj = Instantiate(pool.prefab);
                gameObj.SetActive(false);
                objectPool.Enqueue(gameObj);
            }
            poolDict.Add(pool.tag, objectPool);
        }
    }
    public void destroyObject(GameObject obj, string tag)
    {
        poolDict[tag].Enqueue(obj);
        obj.SetActive(false);
    }
    public GameObject Spawn(string tag)
    {
        GameObject obj = null;
        if (poolDict.ContainsKey(tag))
        {
            if (poolDict[tag].Count == 0)
            {
                foreach (Pool pool in pools)
                {
                    if (pool.tag.Equals(tag))
                    {
                        pool.increasePool(pool.size++);
                        obj = Instantiate(pool.prefab);
                    }
                }
                poolDict[tag].Enqueue(obj);
            }
            GameObject spawnedObject = poolDict[tag].Dequeue();
            spawnedObject.SetActive(true);
            IObjects pooledObj = spawnedObject.GetComponent<IObjects>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }
            return spawnedObject;
        }
        else
        {
            return null;
        }
        
    }
}
