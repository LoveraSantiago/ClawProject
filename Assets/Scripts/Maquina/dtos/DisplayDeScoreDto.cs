using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayDeScoreDto 
{
    [SerializeField] private int qtdBlinks;
    [SerializeField] private float tempoBlink;
    [Space(5)]
    [SerializeField] private GameObject[] gosDisplayScores = new GameObject[3];

    public int QtdBlinks { get { return qtdBlinks; } }
    public float TempoBlink { get { return tempoBlink; } }

    public GameObject[] GosDisplayScores { get { return gosDisplayScores; } }
}
