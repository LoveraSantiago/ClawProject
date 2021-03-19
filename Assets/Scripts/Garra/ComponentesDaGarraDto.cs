using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ComponentesDaGarraDto 
{
    [SerializeField] private float velocidadeMovimento;
    [SerializeField] private float gravidadePos;
    [SerializeField] private float gravidadeNeg;
    [Space(5)]
    [SerializeField] private Rigidbody2D rigidBody;
    [Space(5)]
    [SerializeField] private Transform pincaEsquerda;
    [SerializeField] private Transform pincaDireita;

    public float VelocidadeMovimento { get { return velocidadeMovimento; } }   
    public float GravidadePos { get { return gravidadePos; } }   
    public float GravidadeNeg { get { return gravidadeNeg * -1; } }   

    public Rigidbody2D RigidBody { get { return rigidBody; } }

    public Transform PincaEsquerda { get { return pincaEsquerda; } }
    public Transform PincaDireita { get { return pincaDireita; } }


}
