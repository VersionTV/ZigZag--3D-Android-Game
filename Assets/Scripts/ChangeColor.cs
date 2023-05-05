using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color[] colors;
    Color ilkRenk, ikinciRenk;
    int birincirenk;
    public Material zeminMat;
    private void Start()
    {
        birincirenk = Random.Range(0, colors.Length);
        zeminMat.color = colors[birincirenk];
        Camera.main.backgroundColor = colors[birincirenk];
    }

}
