using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMove : MonoBehaviour
{
    public float moveSpeed = 0f;



    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
        {
            moveSpeed = 5f;
            transform.Translate(-transform.right * Time.deltaTime * moveSpeed);
        }        
    }
}
