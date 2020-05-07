using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObjectGenerator : MonoBehaviour
{
    public GameObject[] GroundObjects;

    void Start()
    {
        InvokeRepeating("GroundObjectsGenerator", 0.5f, 1.6f);
    }

    void Update()
    {

    }

    public void GroundObjectsGenerator()
    {
        if (GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
        {
            Instantiate(GroundObjects[Random.Range(0, GroundObjects.Length)], new Vector3(4.83f, -2.66f, -0.3f), Quaternion.identity);
        }      
    }
}
