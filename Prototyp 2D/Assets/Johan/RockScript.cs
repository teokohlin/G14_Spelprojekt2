using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockScript : MonoBehaviour
{
    [SerializeField]
    private RectTransform health;
    
    private PlayerScript player;
    public GameObject rockHealth;
    public GameObject buttons;
    
    private float originalSize;
    private bool clickedYes = false;
    private bool energydepleted;
    
    public UnityAction UseEnergy;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerScript>();
        originalSize = health.sizeDelta.x;
    }

    void Update()
    {
        if (clickedYes)
        {
            if (health.sizeDelta.x > 0)
            {
                health.sizeDelta += new Vector2(-0.01f/4, 0);
            }
            else
            {
                rockHealth.SetActive(false);
                
                health.sizeDelta = new Vector2(originalSize, health.sizeDelta.y);
                gameObject.SetActive(false);
                clickedYes = false;
            }
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttons.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttons.gameObject.SetActive(false);

        }
    }
    
    public void Yes()
    {
        if (player.energi <= 0)
        {
            Debug.Log("No energy left");
        }
        else
        {
            UseEnergy?.Invoke();
            buttons.SetActive(false);
            rockHealth.SetActive(true);
            clickedYes = true; 
        }
    }

    public void No()
    {
        buttons.SetActive(false);
    }
    
}
