using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public RectTransform energiIcon;
    private float originalS;
    public TreeScript[] träd;
    public CanvasButtons canvas;
    void Start()
    {
        originalS = energiIcon.sizeDelta.x;
        canvas.Useenergi += RemoveEnergiIcon;
        foreach (var t in träd)
        {
            t.UseEnergi += RemoveEnergiIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveEnergiIcon()
    {
        energiIcon.sizeDelta -= new Vector2(originalS / 3, 0);
    }
}
