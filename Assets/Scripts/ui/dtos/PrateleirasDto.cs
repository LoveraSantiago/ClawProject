using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PrateleirasDto 
{
    [SerializeField] private PrateleiraArmarioDto[] prateleiraDto;

    public PrateleiraArmarioDto[] PrateleiraDto { get { return prateleiraDto; } }
}
