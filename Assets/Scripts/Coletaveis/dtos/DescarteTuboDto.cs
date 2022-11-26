using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DescarteTuboDto 
{
    [SerializeField] private float torque;    
    [SerializeField] private float gravidade;
    [Space(3)]
    [SerializeField] private float delayDescarte;
    [SerializeField] private float delaySomQueda;
    [SerializeField] private float delaySomTubo;
    [Space(3)]
    [SerializeField] private GameObject parentColetavelTubo;    
    [SerializeField] private ColetavelTuboDeSaidaDto[] coletavelTuboDeSaida = new ColetavelTuboDeSaidaDto[3];

    public float Torque { get { return torque; } }    
    public float Gravidade { get { return gravidade; } }
    public float DelayDescarte { get { return delayDescarte; } }
    public float DelaySomQueda { get { return delaySomQueda; } }
    public float DelaySomTubo { get { return delaySomTubo; } }

    public GameObject ParentColetavelTubo { get { return parentColetavelTubo; } }    
    public ColetavelTuboDeSaidaDto[] ColetavelTuboDeSaida { get { return coletavelTuboDeSaida; } }
}
