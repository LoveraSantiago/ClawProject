using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class GarraVelocidadesDto 
{
    [SerializeField] private float movHorizontal;
    [SerializeField] private float movCima;

    public float MovHorizontal { get { return movHorizontal; } }
    public float MovCima { get { return movCima; } }
}
