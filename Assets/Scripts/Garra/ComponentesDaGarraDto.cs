using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ComponentesDaGarraDto 
{
    [SerializeField] private float velocidadeMovimento;    

    public float VelocidadeMovimento { get { return velocidadeMovimento; } }   

}
