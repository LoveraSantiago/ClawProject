using UnityEngine;

public class Garra 
{
    public float alturaLocalEfeitoTrail { get; private set; }    

    public GarraDto garraDto { get; private set; }

    public GarraPincas pincas { get; private set; }
    public GarraAnimacao animacao { get; private set; }
    public GarraRigidBody rigidBody { get; private set; }    

    public static ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao { get; private set; }

    public Garra(GarraDto garraDto)
    {
        this.garraDto = garraDto;        
        alturaLocalEfeitoTrail = garraDto.EfeitoTrail.transform.localPosition.y;

        pincas = new GarraPincas(garraDto.PincaEsquerda, garraDto.PincaDireita);
        animacao = new GarraAnimacao(garraDto.Animator);
        rigidBody = new GarraRigidBody(garraDto.RigidBody.transform.localPosition, garraDto.RigidBody);
        produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();
    }                           

    public void moverParaCima()
    {
        ligarEfeitoTrailAngulo(-0.4f, 180);
        rigidBody.setVelocidade(new Vector2(0, garraDto.Velocidades.MovCima));
    }

    public void moverParaBaixo()
    {
        ligarEfeitoTrailAngulo(0.8f, 0);
        rigidBody.setVelocidade(new Vector2(0, garraDto.Velocidades.MovBaixo));
    }

    public void moverHorizontalmente(float direcao)
    {
        garraDto.EfeitoTrail.Stop();
        //Debug.Log(direcao * garraDto.VelocMovHorizontal);
        rigidBody.setVelocidade(new Vector2(direcao * garraDto.Velocidades.MovHorizontal, 0));
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
