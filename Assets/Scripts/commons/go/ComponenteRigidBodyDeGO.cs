using UnityEngine;

public class ComponenteRigidBodyDeGO : ComponenteSpriteDeGO
{
    private Rigidbody2D rigidbody;

    public ComponenteRigidBodyDeGO(GameObject go) 
        : base(go){}

    protected void carregarRigidBody()
    {
        rigidbody = extrairComponente<Rigidbody2D>();
    }

    public bool isVelocidadeYPositiva()
    {
        return rigidbody.velocity.y > 0;
    }

    public virtual void parar()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
    }

    public virtual void ligarGravidadeZero()
    {
        rigidbody.gravityScale = 0;
    }

    public virtual void ligarGravidadeHum()
    {
        rigidbody.gravityScale = 1;
    }

    public void setGravidade(float gravidade)
    {
        rigidbody.gravityScale = gravidade;
    }

    public virtual void fixarEixoX()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public virtual void fixarEixoXY()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void desafixarVerticalmente()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    protected void addImpulso(Vector3 forca)
    {
        rigidbody.AddForce(forca, ForceMode2D.Impulse);
    }
}
