using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class RuchScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tf;
    public float speed;
    Vector2 ruch;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ruch.x = Input.GetAxisRaw("Horizontal");
        ruch.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + ruch * speed * Time.fixedDeltaTime * 10 * 1.5f);
        }
        else
        {
            rb.MovePosition(rb.position + ruch * speed * Time.fixedDeltaTime * 10);
        }
    }
}
