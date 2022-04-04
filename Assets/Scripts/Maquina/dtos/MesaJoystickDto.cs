using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MesaJoystickDto
{
    [SerializeField] private float velocidade;
    [Space(2)]
    [SerializeField] private SpriteRenderer sprRendererMesaCima;
    [SerializeField] private SpriteRenderer sprRendererMesaBaixo;
    [Space(2)]
    [SerializeField] private SpriteRenderer sprRendererBaseJoystick;
    [SerializeField] private SpriteRenderer sprRendererHaste;
    [SerializeField] private SpriteRenderer sprRendererBolaJoystick;
    [Space(2)]
    [SerializeField] private SpriteRenderer sprRendererBaseBotao;
    [SerializeField] private SpriteRenderer sprRendererBotao;
    [Space(2)]
    [SerializeField] private SpriteRenderer sprRendererFicha;
    [SerializeField] private SpriteRenderer sprRendererCard;
    [SerializeField] private SpriteRenderer sprRendererSetaCard;

    public float Velocidade { get { return velocidade; } }

    public SpriteRenderer SprRendererMesaCima { get { return sprRendererMesaCima; } }
    public SpriteRenderer SprRendererMesaBaixo { get { return sprRendererMesaBaixo; } }

    public SpriteRenderer SprRendererBaseJoystick { get { return sprRendererBaseJoystick; } }
    public SpriteRenderer SprRendererHaste { get { return sprRendererHaste; } }
    public SpriteRenderer SprRendererBolaJoystick { get { return sprRendererBolaJoystick; } }

    public Transform HasteTransform { get { return SprRendererHaste.transform; } }

    public SpriteRenderer SprRendererBaseBotao { get { return sprRendererBaseBotao; } }
    public SpriteRenderer SprRendererBotao { get { return sprRendererBotao; } }

    public SpriteRenderer SprRendererFicha { get { return sprRendererFicha; } }
    public SpriteRenderer SprRendererCard { get { return sprRendererCard; } }
    public SpriteRenderer SprRendererSetaCard { get { return sprRendererSetaCard; } }
}
