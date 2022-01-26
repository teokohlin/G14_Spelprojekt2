using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int energi = 3;
    private Vector2 movement;
    public TreeScript[] träd;
    public CanvasButtons canvas;
    private Rigidbody2D rb;
    public float speed = 10f;
    void Start()
    {
         rb = this.GetComponent<Rigidbody2D>();
         canvas.Useenergi += RemoveEnergi;
         foreach (var t in träd)
         {
             t.UseEnergi += RemoveEnergi;
         }
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Debug.Log(energi);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void RemoveEnergi()
    {
        energi--;
    }
}
