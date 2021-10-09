using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class GarraVelocidadesDto 
{
    [SerializeField] private float movHorizontal;
    [SerializeField] private float movCima;
    [SerializeField] private float movBaixo;
    [Space(3)]
    [SerializeField] private float movAnguloIdle;

    public float MovHorizontal { get { return movHorizontal; } }
    public float MovCima { get { return movCima; } }
    public float MovBaixo { get { return movBaixo * -1; } }

    public float MovAnguloIdle { get { return movAnguloIdle; } }
}
