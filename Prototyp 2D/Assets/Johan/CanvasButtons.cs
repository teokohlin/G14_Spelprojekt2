using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CanvasButtons : MonoBehaviour
{
    private int farmingState; //0 = ej plogad, 1 = plogad, 2 = sådd, 3 = grown
    private Field currentField;
    public Button[] buttons;
    public UnityAction Useenergi;
    private PlayerScript player;
    private void Start()
    {
         player = GameObject.FindObjectOfType<PlayerScript>();
    }

    public void UpdateButtons(int farmState, Field field)
    {
        farmingState = farmState;
        currentField = field;
        
        foreach (var t in buttons)
        {
            t.interactable = false;
        }

        buttons[farmingState].interactable = true;
    }

    public void CanvasButtonPressed(int buttonIndex)
    {
        if (player.energi <= 0)
        {
            Debug.Log("No energi left");
        }
        else
        {
            Useenergi?.Invoke();
            currentField.ActionButtonPressed(buttonIndex); 
        }
        
    }
}
