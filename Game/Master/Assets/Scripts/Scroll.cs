﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scroll : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.deltaTime * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
