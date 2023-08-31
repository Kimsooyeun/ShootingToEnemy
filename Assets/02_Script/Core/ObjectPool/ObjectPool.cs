using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : PoolObject
{
    public GameObject originalPrefab;
    public int poolSize = 64;
    T[] pool;
    Queue<T> readyQueue; //사용 가능 오브젝트가 들어있는 큐, 선입선출 용이하도록 큐로 작성

    public void Initialize()
    {
        if(pool == null)
        {
            pool = new T[poolSize];
            readyQueue = new Queue<T>(poolSize);
            GenerateObject(0, poolSize, pool);
        }
        else
        {
            foreach(var obj in pool) 
            {
                obj.gameObject.SetActive(false);
            }
        }
    }

    //오브젝트 생성 & 배열에 추가
    void GenerateObject(int start , int end, T[] newArray)
    {
        for (int i = start; i < end; i++)    // start부터 end까지 반복
        {
            GameObject obj = Instantiate(originalPrefab, transform);    // 프리팹 생성하고 풀의 자식으로 설정
            obj.gameObject.name = $"{originalPrefab.name}_{i}";
            T comp = obj.GetComponent<T>();

            comp.onDisable += () => readyQueue.Enqueue(comp);

            newArray[i] = comp;
            obj.SetActive(false);
        }
    }

    public T GetObject()
    {
        if (readyQueue.Count > 0)
        {
            T obj = readyQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            ExpandPool();
            return GetObject();
        }
    }

    public T GetObject(Transform spawnTransForm)
    {
        if(readyQueue.Count > 0) 
        {
            T obj = readyQueue.Dequeue();
            obj.transform.position = spawnTransForm.position;
            obj.transform.rotation = spawnTransForm.rotation;
            obj.transform.localScale = spawnTransForm.localScale;
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            ExpandPool();
            return GetObject();
        }
    }

    public void ExpandPool()
    {
        int newSize = poolSize * 2;
        T[] newPool = new T[newSize];

        for(int i = 0; i < poolSize; i++)
        {
            newPool[i] = pool[i];
        }
        GenerateObject(poolSize,newSize,newPool);
        pool = newPool;
        poolSize = newSize;
    }
}
