﻿using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float fallDelay;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb2d.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        
        yield return 0;
    }

}
