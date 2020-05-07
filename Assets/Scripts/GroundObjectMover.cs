using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObjectMover : MonoBehaviour
{
    public float moveSpeed = 0f;

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
        {
            moveSpeed = 4f;
            transform.Translate(-transform.right * Time.deltaTime * moveSpeed);
        }
    }

   
}
