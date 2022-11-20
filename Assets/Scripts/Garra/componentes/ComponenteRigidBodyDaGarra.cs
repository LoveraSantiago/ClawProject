using UnityEngine;

public class ComponenteRigidBodyDaGarra : ComponenteSomDaGarra
{
    private Vector2 posInicial;

    public ComponenteRigidBodyDaGarra(GarraDto garraDto, SomGarra somGarra)
        : base(garraDto, somGarra)
    {
        posInicial = garraDto.Corpo.RigidBody.transform.localPosition;
    }

    public void setVelocidade(Vector2 velocidade)
    {
        getRigidBody().velocity = velocidade;
    }

    public void parar()
    {
        Rigidbody2D rigidBody = getRigidBody();
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = 0;
    }

    public void colocarNaHalturaInicial()
    {
        getRigidBody().transform.localPosition = new Vector2(getRigidBody().transform.localPosition.x, posInicial.y);
    }

    public void colocarNaPosicaoInicial()
    {
        getRigidBody().transform.localPosition = posInicial;
    }

    public void colocarNaPosicaoHorizontal(float posHorizontal)
    {
        getRigidBody().transform.localPosition = new Vector3(posHorizontal, posInicial.y, 0);
    }

    public void moverPCima()
    {
        //Debug.Log("noverPCima");
        setVelocidade(new Vector2(0, getVelocidades().MovCima));
    }

    public void moverPBaixo()
    {
        setVelocidade(new Vector2(0, getVelocidades().MovBaixo));
    }

    public void moverPHorizontal(float direcao)
    {
        setVelocidade(new Vector2(direcao * getVelocidades().MovHorizontal, 0));
    }

    public void colocarMassa(float massa)
    {
        getRigidBody().mass = massa;
    }

    public void fixarVerticalEHorizontal()
    {
        getRigidBody().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void fixarHorizontalmente()
    {
        getRigidBody().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void fixarVerticalmente()
    {
        getRigidBody().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public void desafixar()
    {
        getRigidBody().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public bool isAcimaPosInicial()
    {
        //Debug.Log(getRigidBody().transform.localPosition.y + " - " + posInicial.y + " - isacima = " + (getRigidBody().transform.localPosition.y >= posInicial.y));
        return getRigidBody().transform.localPosition.y >= posInicial.y;
    }

    public bool isMaiorPosHorizontal(float posHorizontal)
    {
        return getRigidBody().transform.localPosition.x > posHorizontal;
    }

    public bool isMenorPosHorizontal(float posHorizontal)
    {
        return getRigidBody().transform.localPosition.x < posHorizontal;
    }

    private Rigidbody2D getRigidBody()
    {
        return garraDto.Corpo.RigidBody;
    } 
    
    private GarraVelocidadesDto getVelocidades()
    {
        return garraDto.Velocidades;
    }
}
