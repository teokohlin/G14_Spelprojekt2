using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasButtons : MonoBehaviour
{
    private int farmingState; //0 = ej plogad, 1 = plogad, 2 = sådd, 3 = grown
    private Field currentField;
    public Button[] buttons;

    private void Start()
    {
        
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
        currentField.ActionButtonPressed(buttonIndex);
    }
}
