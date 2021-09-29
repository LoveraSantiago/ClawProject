using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayDeScoreDto 
{
    [SerializeField] private int qtdBlinks;
    [SerializeField] private float tempoBlink;    
    [Space(5)]
    [SerializeField] private SingleDisplayScoreDto[] singleDisplayScoreDto = new SingleDisplayScoreDto[3];

    public int QtdBlinks { get { return qtdBlinks; } }
    public float TempoBlink { get { return tempoBlink; } }    

    public SingleDisplayScoreDto[] SingleDisplayScoreDto { get { return singleDisplayScoreDto;  } }
}
