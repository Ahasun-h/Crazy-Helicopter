﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backround : MonoBehaviour
{
    public GameObject plane;
    public Renderer planeRenderer;
    public float speed = 1f;
    public Vector2 offset;

    void Start()
    {
        planeRenderer = plane.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += -speed * Time.deltaTime;
        planeRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
