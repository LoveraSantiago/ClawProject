using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TuboDto 
{
    [SerializeField] private float delayQuedaTubo;
    [SerializeField] private GameObject parentColetavelTubo;
    [SerializeField] private GameObject[] coletaveisParaTubo = new GameObject[3];

    public float DelayQuedaTubo { get { return delayQuedaTubo; } }
    public GameObject ParentColetavelTubo { get { return parentColetavelTubo; } }
    public GameObject[] ColetaveisParaTubo { get { return coletaveisParaTubo; } }
}
