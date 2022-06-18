using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpPrefabDto 
{
    [SerializeField] private int indice;
    [SerializeField] private Sprite sprGO;

    public int Indice { get { return indice; } }
    public Sprite SprGO { get { return sprGO; } }
}
