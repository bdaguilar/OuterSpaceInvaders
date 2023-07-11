using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Data
{
    public string Dato1;
    public int Dato2;

    public Data(string dato1, int dato2)
    {
        Dato1 = dato1;
        Dato2 = dato2;
    }
}
