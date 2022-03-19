using UnityEngine;

public class GarraRigidBody
{
    private Vector2 posInicial;
    private Rigidbody2D garraRigidBody;
    private GarraVelocidadesDto velocidadesDto;

    public GarraRigidBody(GarraDto garraDto)
    {
        garraRigidBody = garraDto.Corpo.RigidBody;
        posInicial     = garraDto.Corpo.RigidBody.transform.localPosition;
        velocidadesDto = garraDto.Velocidades;
    }    

    public void setVelocidade(Vector2 velocidade)
    {
        garraRigidBody.velocity = velocidade;
    }

    public void parar()
    {
        garraRigidBody.velocity = Vector3.zero;
        garraRigidBody.angularVelocity = 0;
    }

    public void colocarNaHalturaInicial()
    {
        garraRigidBody.transform.localPosition = new Vector2(garraRigidBody.position.x, posInicial.y);
    }

    public void colocarNaPosicaoInicial()
    {
        garraRigidBody.transform.localPosition = posInicial;
    }

    public void colocarNaPosicaoHorizontal(float posHorizontal)
    {
        garraRigidBody.transform.localPosition = new Vector3(posHorizontal, posInicial.y, 0);
    }

    public void moverPCima()
    {
        setVelocidade(new Vector2(0, velocidadesDto.MovCima));
    }

    public void moverPBaixo()
    {
        setVelocidade(new Vector2(0, velocidadesDto.MovBaixo));
    }

    public void moverPHorizontal(float direcao)
    {
        setVelocidade(new Vector2(direcao * velocidadesDto.MovHorizontal, 0));
    }

    public void colocarMassa(int massa)
    {
        garraRigidBody.mass = massa;
    }

    public void fixarVerticalEHorizontal()
    {
        garraRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void fixarHorizontalmente()
    {
        garraRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void fixarVerticalmente()
    {
        garraRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public void desafixar()
    {
        garraRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public bool isAcimaPosInicial()
    {
        return garraRigidBody.transform.localPosition.y >= posInicial.y;
    }

    public bool isMaiorPosHorizontal(float posHorizontal)
    {
        return garraRigidBody.transform.localPosition.x > posHorizontal;
    }

    public bool isMenorPosHorizontal(float posHorizontal)
    {
        return garraRigidBody.transform.localPosition.x < posHorizontal;
    }
}
