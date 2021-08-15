using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class RollbackDto 
{
    [SerializeField] private float delayReset;

    public float DelayReset { get { return delayReset; } }
}
