using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class JoystickDto 
{
    [SerializeField] private Transform joystickTransform;
    [SerializeField] private SpriteRenderer parteCima;
    [SerializeField] private SpriteRenderer parteBaixo;
    [SerializeField] private SpriteRenderer furoHaste;
    [SerializeField] private SpriteRenderer haste;
    [SerializeField] private SpriteRenderer bola;
    [SerializeField] private SpriteRenderer furoBotao;
    [SerializeField] private SpriteRenderer botao;

    public Transform JoystickTransform { get { return joystickTransform; } }
    public SpriteRenderer ParteCima { get { return parteCima; } }
    public SpriteRenderer ParteBaixo { get { return parteBaixo; } }
    public SpriteRenderer FuroHaste { get { return furoHaste; } }
    public SpriteRenderer Haste { get { return haste; } }
    public SpriteRenderer Bola { get { return bola; } }
    public SpriteRenderer FuroBotao { get { return furoBotao; } }
    public SpriteRenderer JoystickBotao { get { return botao; } }


}
