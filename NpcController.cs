using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public Equipos Team;
    public float speed  = 5f;
    public GameObject Destino ;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Destino != null)
        {
            Vector3 direction = Destino.transform.position - transform.position;
            direction = direction.normalized;
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(Vector3.forward* (speed * Time.deltaTime));
        }

    }

    void Die()
    {
        gameObject.SetActive(false);
        PoolerSystem.SINGLETON.addToPool(gameObject);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }
}

public enum Equipos
{
    Azul,
    Rojo,
    Verde,
    Naranja
}