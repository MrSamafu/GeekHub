using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float forceJump;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rb.velocity = new Vector3(0f, 0f, 1f * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.velocity = new Vector3(-1f * speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(0f, 0f, -1f * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(1f * speed * Time.deltaTime, 0f, 0f);
        }

    }
}
