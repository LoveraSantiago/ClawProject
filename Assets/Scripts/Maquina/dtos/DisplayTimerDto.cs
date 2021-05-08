using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayTimerDto 
{
    [SerializeField] private GameObject[] gosDisplayTimers = new GameObject[4];
    [SerializeField] private GameObject goDisplayTimer2Pontos;

    public GameObject[] GosDisplayTimers { get { return gosDisplayTimers; } }
    public GameObject GoDisplayTimer2Pontos { get { return goDisplayTimer2Pontos; } }
}
