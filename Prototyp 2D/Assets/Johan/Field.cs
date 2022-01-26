using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField]
    private int farmState; //0 = ej plogad, 1 = plogad, 2 = sådd, 3 = grown
    public Canvas canvas;
    private bool playerInRange = false;

    private SpriteRenderer spriteRenderer;
    
    public Sprite[] sprites;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            canvas.gameObject.SetActive(false);

        }
    }
    private void OnMouseDown()
    {
        if (playerInRange)
        {
            canvas.gameObject.SetActive(true);
            canvas.GetComponent<CanvasButtons>().UpdateButtons(farmState, this);
            
            canvas.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                canvas.transform.position.z); //kamera grejen blev lustig
                
            
            /* Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            canvas.transform.position = mousePos; */
        }

    }

    public void ActionButtonPressed(int buttonIndex)
    {

        farmState++;
        if (farmState > 3)
        {
            farmState = 0;
        }
        ChangeImage(buttonIndex);
        canvas.GetComponent<CanvasButtons>().UpdateButtons(farmState, this);
    }

    private void ChangeImage(int index)
    {
        spriteRenderer.sprite = sprites[index];
    }
}
