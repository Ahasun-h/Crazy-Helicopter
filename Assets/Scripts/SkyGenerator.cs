using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyGenerator : MonoBehaviour
{
    public GameObject sky;
    public GameObject[] Skys;

    void Start()
    {
        InvokeRepeating("GenerateSky", 0.9f, 1.3f);
    }

    void Update()
    {
       
    }

    public void GenerateSky()
    {

        if (GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
        {
            int randomNumber = Random.Range(0, 2);

            if (randomNumber == 0)
            {
                Instantiate(Skys[Random.Range(0, Skys.Length)], new Vector3(4.83f, 3.15f, -0.1f), Quaternion.identity);
            }
            else
            {
                Instantiate(Skys[Random.Range(0, Skys.Length)], new Vector3(4.83f, 2.92f, -0.1f), Quaternion.identity);
            }
        }

            
    }
}
