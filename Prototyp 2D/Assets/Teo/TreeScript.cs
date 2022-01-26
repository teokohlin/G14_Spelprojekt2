using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeScript : MonoBehaviour
{
    [SerializeField]
    private RectTransform health;

    public Transform stubbespawner;
    public GameObject stubbe;
    public GameObject TreeHealth;
    public GameObject Buttons;
    private float originalSize;
    private bool clickedyes = false;
    void Start()
    {
        Time.timeScale = 1f;
        originalSize = health.sizeDelta.x;
    }

    void Update()
    {
        if (clickedyes)
        {
            if (health.sizeDelta.x > 0)
            {
                health.sizeDelta += new Vector2(-0.01f/4, 0);
            }
            else
            {
                TreeHealth.SetActive(false);
                
                health.sizeDelta = new Vector2(originalSize, health.sizeDelta.y);
                Instantiate(stubbe, stubbespawner.position, transform.rotation);
                gameObject.SetActive(false);
                clickedyes = false;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Buttons.SetActive(true);
            Debug.Log("enter");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Buttons.gameObject.SetActive(false);
            Debug.Log("exit");

        }
    }

    public void Yes()
    {
        Buttons.SetActive(false);
        TreeHealth.SetActive(true);
        clickedyes = true;
    }

    public void No()
    {
        Buttons.SetActive(false);
    }
}
