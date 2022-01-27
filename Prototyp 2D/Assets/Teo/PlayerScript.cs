using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    public int energi = 3;
    private Vector2 movement;
    public TreeScript[] träd;
    public CanvasButtons canvas;
    private Rigidbody2D rb;
    public float speed = 10f;

    public UnityAction RefillEnergy;
    void Start()
    {
        Bedscript bed = GameObject.FindObjectOfType<Bedscript>();
        bed.Slept += AddEnergy;
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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void AddEnergy()
    {
        energi = 3;
        RefillEnergy?.Invoke();
    }
    void RemoveEnergi()
    {
        energi--;
    }
}
