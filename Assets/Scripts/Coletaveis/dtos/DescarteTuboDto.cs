using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DescarteTuboDto 
{
    [SerializeField] private float torque;    
    [SerializeField] private float gravidade;
    [Space(5)]
    [SerializeField] private GameObject parentColetavelTubo;    
    [SerializeField] private ColetavelTuboDeSaidaDto[] coletavelTuboDeSaida = new ColetavelTuboDeSaidaDto[3];

    public float Torque { get { return torque; } }    
    public float Gravidade { get { return gravidade; } }

    public GameObject ParentColetavelTubo { get { return parentColetavelTubo; } }    
    public ColetavelTuboDeSaidaDto[] ColetavelTuboDeSaida { get { return coletavelTuboDeSaida; } }
}
