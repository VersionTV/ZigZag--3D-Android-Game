using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color[] colors;
    Color ikinciRenk;
    int birincirenk;
    public Material zeminMat;
    private void Start()
    {
        birincirenk = Random.Range(0, colors.Length);
        ikinciRenk = colors[ikinciRenksec()];
        zeminMat.color = colors[birincirenk];
      
        Camera.main.backgroundColor = colors[birincirenk];
    }
    int ikinciRenksec()
    {
        int ikinciRenkIndex;
        ikinciRenkIndex = Random.Range(0, colors.Length);
        while (ikinciRenkIndex==birincirenk)
        {
            ikinciRenkIndex = Random.Range(0, colors.Length);
        }
        return ikinciRenkIndex;
    }
    private void Update()
    {
        Color fark = zeminMat.color - ikinciRenk;
        if (Mathf.Abs(fark.r) + Mathf.Abs(fark.g) + Mathf.Abs(fark.b) < 0.2f)
        {
            ikinciRenk = colors[ikinciRenksec()];
        }
        zeminMat.color = Color.Lerp(zeminMat.color,ikinciRenk,0.0003f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, ikinciRenk, 0.0007f);
    }

}
