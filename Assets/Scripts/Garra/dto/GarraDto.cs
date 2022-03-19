using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class GarraDto 
{       
    [SerializeField] private float posCacaNiquel;    
    [SerializeField] private GarraVelocidadesDto velocidades;
    [Space(3)]
    [SerializeField] private GarraAngulosDto angulos;    
    [Space(5)]
    [SerializeField] private CaboGarraDto caboDto;       
    [Space(5)]               
    [SerializeField] private CorpoGarraDto corpo;
    [Space(3)]
    [SerializeField] private ParticleSystem efeitoTrail;

    public GarraVelocidadesDto Velocidades { get { return velocidades; } }
    public GarraAngulosDto Angulos { get { return angulos; } }    

    public float PosCacaNiquel { get { return posCacaNiquel; } }

    public CorpoGarraDto Corpo { get { return corpo; } }
    
    public ParticleSystem EfeitoTrail { get { return efeitoTrail; } }

    public CaboGarraDto CaboDaGarraDto { get { return caboDto; } }
}
