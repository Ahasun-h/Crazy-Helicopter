using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyObjectGenerator : MonoBehaviour
{
    public GameObject[] skyObjects;

    void Start()
    {
        InvokeRepeating("GenerateSkyObjects", 1f, 3f);
    }

    void Update()
    {

    }

    public void GenerateSkyObjects()
    {
        if (GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying) {
            int randomNumber = Random.Range(0, 3);

            if (randomNumber == 0)
            {
                Instantiate(skyObjects[Random.Range(0, skyObjects.Length)], new Vector3(4.83f, 1.05f, -0.2f), Quaternion.identity);
            }
            else if (randomNumber == 1)
            {
                Instantiate(skyObjects[Random.Range(0, skyObjects.Length)], new Vector3(4.83f, 2.76f, -0.2f), Quaternion.identity);
            }
            else
            {
                Instantiate(skyObjects[Random.Range(0, skyObjects.Length)], new Vector3(4.83f, 3.83f, -0.2f), Quaternion.identity);
            }
        }
    }

           
}
