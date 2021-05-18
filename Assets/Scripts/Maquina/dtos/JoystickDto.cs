using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class JoystickDto 
{
    [SerializeField] private Transform joystickTransform;
    [SerializeField] private SpriteRenderer sprRendererParteCima;
    [SerializeField] private SpriteRenderer sprRendererparteBaixo;
    [SerializeField] private SpriteRenderer sprRendererFuroHaste;
    [SerializeField] private SpriteRenderer sprRendererHaste;
    [SerializeField] private SpriteRenderer sprRendererBola;
    [SerializeField] private SpriteRenderer sprRendererFuroBotao;
    [SerializeField] private SpriteRenderer sprRendererJoystickBotao;

    public Transform JoystickTransform { get { return joystickTransform; } }
    public SpriteRenderer SprRendererParteCima { get { return sprRendererParteCima; } }
    public SpriteRenderer SprRendererParteBaixo { get { return sprRendererparteBaixo; } }
    public SpriteRenderer SprRendererFuroHaste { get { return sprRendererFuroHaste; } }
    public SpriteRenderer SprRendererHaste { get { return sprRendererHaste; } }
    public SpriteRenderer SprRendererBola { get { return sprRendererBola; } }
    public SpriteRenderer SprRendererFuroBotao { get { return sprRendererFuroBotao; } }
    public SpriteRenderer SprRendererJoystickBotao { get { return sprRendererJoystickBotao; } }


}
