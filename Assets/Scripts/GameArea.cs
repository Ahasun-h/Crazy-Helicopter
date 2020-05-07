using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    public GameObject plane;
    public Renderer planeRenderer;
    public float speed;
    public Vector2 offset;

    void Start()
    {
        planeRenderer = plane.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
        {
            speed = 0.5f;
            offset.x += -speed * Time.deltaTime;
            planeRenderer.material.SetTextureOffset("_MainTex", offset);
        }


    }

}
