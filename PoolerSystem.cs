using System.Collections.Generic;
using UnityEngine;

public class PoolerSystem : MonoBehaviour
{
    public static PoolerSystem SINGLETON;
    // el numero minimo del Pool
    public int initPoolnum = 10;
    // lista de objectos inactivos
    public List<GameObject> Pool = new List<GameObject>();
    // prefab de la pull
    public GameObject Prefab;
    private void Awake()
    {
        SINGLETON = this;
    }
    private void Start()
    {
        initPool();
    }
    void initPool()
    {
        for (int i = initPoolnum; i > 0; i--)
        {

            GameObject obj = Instantiate(Prefab); // creo un objeto del prefab
            obj.SetActive(false); // desactivo el objeto
            Pool.Add(obj); // añado a la lista 
        }
    }
    // crea un objeto inactivo
    GameObject createobject()
    {
        GameObject obj = Instantiate(Prefab);
        obj.SetActive(false);
        return obj;
    }
    // obtiene un objeto inactivo del pool
    public GameObject getFromPool()
    {
        GameObject obj;
        if(Pool.Count < 1)
        {
            obj = createobject();
        }
        else 
        { 
            obj = Pool[0];
            Pool.Remove(obj);
        }
        
        return obj;
    }

    public void addToPool(GameObject obj)
    {
        Pool.Add(obj);

    }

}
