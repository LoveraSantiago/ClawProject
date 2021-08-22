using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TuboDto 
{
    [SerializeField] private float torque;    
    [SerializeField] private float gravidade;
    [Space(5)]
    [SerializeField] private GameObject parentColetavelTubo;
    [SerializeField] private GameObject[] coletaveisParaTubo = new GameObject[3];

    public float Torque { get { return torque; } }    
    public float Gravidade { get { return gravidade; } }

    public GameObject ParentColetavelTubo { get { return parentColetavelTubo; } }
    public GameObject[] ColetaveisParaTubo { get { return coletaveisParaTubo; } }
}
