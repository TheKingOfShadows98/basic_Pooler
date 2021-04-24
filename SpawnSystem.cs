using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnSystem: MonoBehaviour
{
    public static SpawnSystem SINGLETON;
    public bool Stop;
    public GameObject Target;


    void Awake()
    {
        SINGLETON = this;
    }

    private void Start()
    {

        StartCoroutine(debugSpawn());
    }


    public void SpawnAllyUnit(Vector3 position, GameObject destination)
    {
        GameObject unit = PoolerSystem.SINGLETON.getFromPool();
        unit.transform.position = position;
        unit.GetComponent<NpcController>().Destino = destination;
        /* 
         * Comportamiento
         */
        unit.SetActive(true);
    }
    public IEnumerator debugSpawn()
    {
        yield return new WaitForSeconds(2);
        SpawnAllyUnit(Vector3.zero, Target);
        if (!Stop)
        {
            StartCoroutine(debugSpawn());
        }
    }
}
