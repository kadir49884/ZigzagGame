using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public Color[] colors;

    private Color ilkRenk, ikinciRenk;
    private int birinciRenk;

    public Material zeminMat;

    private void Start()
    {
        birinciRenk = Random.Range(0, colors.Length);
        zeminMat.color = colors[birinciRenk];
        Camera.main.backgroundColor = colors[birinciRenk];
    }



}//class
