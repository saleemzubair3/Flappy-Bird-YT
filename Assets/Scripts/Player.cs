using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float strength;
    private Rigidbody2D directionRb;
    private Vector3 direction;
    //private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        strength = 5f;
        directionRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }
    }
}