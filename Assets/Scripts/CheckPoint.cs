using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameController GC;

    private void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GC").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GC.lastCheckPoint = transform.position;
            Destroy(gameObject);
        }
    }

}
