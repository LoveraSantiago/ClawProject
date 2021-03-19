using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ComponentesDaGarraDto 
{
    [SerializeField] private float velocidadeMovimento;
    [SerializeField] private Rigidbody2D rigidBody;

    public float VelocidadeMovimento { get { return velocidadeMovimento; } }   
    public Rigidbody2D RigidBody { get { return rigidBody; } }

}
