using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaquinaDto
{
    [Space(5)]
    [SerializeField] float tempoResetDisplayColetados;
    [SerializeField] float velocidade;
    [Space(5)]
    [SerializeField] private SpriteRenderer[] spritesDisplayColetados = new SpriteRenderer[3]; //3
    [SerializeField] private GameObject[] gosDisplayScores = new GameObject[3];
    [SerializeField] private Transform hasteJoystick;

    public float Velocidade { get { return velocidade;  } }
    public float TempoResetDisplayColetados { get { return tempoResetDisplayColetados; } }
    public SpriteRenderer[] SpritesDisplayColetados { get { return spritesDisplayColetados; }}
    public GameObject[] GosDisplayScores { get { return gosDisplayScores; } }
    public Transform HasteJoystick { get { return hasteJoystick;  } }

}
