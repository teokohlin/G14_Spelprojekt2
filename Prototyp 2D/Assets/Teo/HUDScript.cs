using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public RectTransform energiIcon;
    public GameObject infotext;
    private float originalSx;
    private float originalSy;
    public TreeScript[] träd;
    public CanvasButtons canvas;
    public PlayerScript player;
    private float timer;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerScript>();
        player.RefillEnergy += AddenergiIcon;
        originalSx = energiIcon.sizeDelta.x;
        originalSy = energiIcon.sizeDelta.y;
        canvas.Useenergi += RemoveEnergiIcon;
        foreach (var t in träd)
        {
            t.UseEnergi += RemoveEnergiIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.energi <= 0)
        {
            infotext.SetActive(true);
        }
        else if (player.energi > 0)
            infotext.SetActive(false); 
        
    }

    public void AddenergiIcon()
    {
        energiIcon.sizeDelta = new Vector2(originalSx, originalSy);
    }
    public void RemoveEnergiIcon()
    {
        energiIcon.sizeDelta -= new Vector2(originalSx / 3, 0);
    }
}
