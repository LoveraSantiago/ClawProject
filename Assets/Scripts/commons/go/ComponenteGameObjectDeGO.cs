using UnityEngine;

public class ComponenteGameObjectDeGO 
{
    private GameObject go;
    public string nome { get; private set; }

    public ComponenteGameObjectDeGO(GameObject go)
    {
        this.go = go;
    }

    public void setNome(string nome)
    {
        this.nome = nome;
        if (!nome.Equals(go.name))
        {
            go.name = nome;
        }
    }

    protected void setLayer(int layer)
    {
        go.layer = layer;
    }   

    protected bool isLayer(int layer)
    {
        return go.layer == layer;
    }

    protected GameObject getGo()
    {
        return go;
    }

    protected Animator extrairAnimator(string nome)
    {
        return extrairTransform(nome).GetComponent<Animator>();
    }

    protected CircleCollider2D extrairCircleCollider()
    {
        return go.GetComponent<CircleCollider2D>();
    }

    protected CapsuleCollider2D extrairCapsuleCollider()
    {
        return go.GetComponent<CapsuleCollider2D>();
    }

    protected Rigidbody2D extrairRigidBody()
    {
        return go.GetComponent<Rigidbody2D>(); ;
    }

    protected Transform extrairTransform(string nome)
    {
        return go.transform.Find(nome).transform;
    }

    protected T extrairComponente<T>()
    {
        return go.GetComponent<T>();
    }
}
