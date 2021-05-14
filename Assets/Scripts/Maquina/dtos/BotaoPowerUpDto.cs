using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoPowerUpDto 
{
    [SerializeField] private SpriteRenderer sprAreaBotao;
    [SerializeField] private GameObject goParteDentro;

    public SpriteRenderer SprAreaBotao { get { return sprAreaBotao; } }
    public GameObject GoParteDentro { get { return goParteDentro; } }
}
