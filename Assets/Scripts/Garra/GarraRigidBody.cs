using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarraRigidBody
{
    private Vector2 posInicial;
    private Rigidbody2D garraRigidBody;

    public GarraRigidBody(Vector2 posInicial, Rigidbody2D garraRigidBody)
    {
        this.posInicial = posInicial;
        this.garraRigidBody = garraRigidBody;
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
