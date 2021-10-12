using UnityEngine;

public class Garra 
{
    public float alturaLocalEfeitoTrail { get; private set; }
    public Vector2 posInicial { get; private set; }

    public GarraDto garraDto { get; private set; }

    public GarraPincas pincas { get; private set; }
    public GarraAnimacao animacao { get; private set; }
    public Rigidbody2D garraRigidBody { get { return garraDto.RigidBody; } }

    public static ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao { get; private set; }

    public Garra(GarraDto garraDto)
    {
        this.garraDto = garraDto;
        posInicial = garraDto.RigidBody.transform.localPosition;
        alturaLocalEfeitoTrail = garraDto.EfeitoTrail.transform.localPosition.y;

        pincas = new GarraPincas(garraDto.PincaEsquerda, garraDto.PincaDireita);
        animacao = new GarraAnimacao(garraDto.Animator);
        produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();
    }

    public void pararGarraRigidBody()
    {
        garraRigidBody.velocity = Vector3.zero;
        garraRigidBody.angularVelocity = 0;
    }

    public void colocarGarraRigidBodyAlturaInicial()
    {
        garraRigidBody.transform.localPosition = new Vector2(garraRigidBody.position.x, posInicial.y);
    }

    public void colocarGarraRigidBodyPosInicial()
    {
        garraRigidBody.transform.localPosition = posInicial;
    }

    public void colocarGarraRigidBodyPosHorizontal(float posHorizontal)
    {
        garraRigidBody.transform.localPosition = new Vector3(posHorizontal, posInicial.y, 0);
    }

    public void colocarMassaNaGarraRigidyBody(int massa)
    {
        garraRigidBody.mass = massa;
    }    

    public void fixarGarraRigidyBodyVerticalEHorizontal()
    {
        garraRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void fixarGarraRigidBodyHorizontalmente()
    {
        garraRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void fixarGarraRigidBodyVerticalmente()
    {
        garraDto.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public void desafixarGarraRigidBody()
    {
        garraRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public bool isGarraRigidyBodyAcimaPosInicial()
    {
        return garraRigidBody.transform.localPosition.y >= posInicial.y;
    }

    public bool isGarraRigidBodyMaiorPosHorizontal(float posHorizontal)
    {
        return garraRigidBody.transform.localPosition.x > posHorizontal;
    }

    public bool isGarraRigidBodyMenorPosHorizontal(float posHorizontal)
    {
        return garraDto.RigidBody.transform.localPosition.x < posHorizontal;
    }

    public void moverParaCima()
    {
        ligarEfeitoTrailAngulo(-0.4f, 180);
        garraRigidBody.velocity = new Vector2(0, garraDto.Velocidades.MovCima);
    }

    public void moverParaBaixo()
    {
        ligarEfeitoTrailAngulo(0.8f, 0);
        garraRigidBody.velocity = new Vector2(0, garraDto.Velocidades.MovBaixo);
    }

    public void moverHorizontalmente(float direcao)
    {
        garraDto.EfeitoTrail.Stop();
        //Debug.Log(direcao * garraDto.VelocMovHorizontal);
        garraRigidBody.velocity = new Vector2(direcao * garraDto.Velocidades.MovHorizontal, 0);
    }

    public void dispararEventoDirecao(int direcao)
    {
        if (direcao == 1)
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.DIREITA);
        }
        else
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
    }

    public void desligarTrail()
    {
        garraDto.EfeitoTrail.Stop();
    }

    public void ligarEfeitoTrailAngulo(float incremento, float angulo)
    {
        garraDto.EfeitoTrail.Play();
        garraDto.EfeitoTrail.transform.rotation = Quaternion.Euler(0, 0, angulo);

        Vector3 localPos = garraDto.EfeitoTrail.transform.localPosition;
        garraDto.EfeitoTrail.transform.localPosition = new Vector3(localPos.x, alturaLocalEfeitoTrail + incremento, localPos.z);
    }
}
