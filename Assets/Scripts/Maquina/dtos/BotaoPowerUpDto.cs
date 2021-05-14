using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoPowerUpDto 
{
    [SerializeField] private SpriteRenderer sprAreaBotao;

    public SpriteRenderer SprAreaBotao { get { return sprAreaBotao; } }
}
