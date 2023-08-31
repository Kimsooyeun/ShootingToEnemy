using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : PoolObject
{
    public GameObject originalPrefab;
    public int poolSize = 64;
    T[] pool;
    Queue<T> readyQueue; //��� ���� ������Ʈ�� ����ִ� ť, ���Լ��� �����ϵ��� ť�� �ۼ�

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

    //������Ʈ ���� & �迭�� �߰�
    void GenerateObject(int start , int end, T[] newArray)
    {
        for (int i = start; i < end; i++)    // start���� end���� �ݺ�
        {
            GameObject obj = Instantiate(originalPrefab, transform);    // ������ �����ϰ� Ǯ�� �ڽ����� ����
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
