using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaquinaDto
{
    [Space(5)]
    [SerializeField] DisplayDeColetadoDto displayDeColetadoDto;
    [Space(5)]
    [SerializeField] DisplayDeScoreDto displayDeScoreDto;
    [SerializeField] private int qtdBlinks;
    [SerializeField] private float tempoBlink;
    [SerializeField] private GameObject[] gosDisplayScores = new GameObject[3];
    [SerializeField] private Transform hasteJoystick;

    public DisplayDeColetadoDto DisplayDeColetadoDto { get { return displayDeColetadoDto; } }
    public DisplayDeScoreDto DisplayDeScoreDto { get { return displayDeScoreDto; } }

    public int QtdBlinks { get { return qtdBlinks; } }
    public float TempoBlink { get { return tempoBlink; } }
    public GameObject[] GosDisplayScores { get { return gosDisplayScores; } }
    public Transform HasteJoystick { get { return hasteJoystick;  } }

}
