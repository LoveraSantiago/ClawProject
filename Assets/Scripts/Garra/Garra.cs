using UnityEngine;

public class Garra 
{
    public GarraDto garraDto { get; private set; }

    public GarraPincas    pincas { get; private set; }
    public GarraAnimacao  animacao { get; private set; }
    public GarraRigidBody rigidBody { get; private set; }    
    public GarraEfeito    efeito { get; private set; }

    public static ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao { get; private set; }

    public Garra(GarraDto garraDto)
    {
        this.garraDto = garraDto;                

        pincas    = new GarraPincas(garraDto.PincaEsquerda, garraDto.PincaDireita);
        animacao  = new GarraAnimacao(garraDto.Animator);
        rigidBody = new GarraRigidBody(garraDto.RigidBody.transform.localPosition, garraDto.RigidBody);
        efeito    = new GarraEfeito(garraDto.EfeitoTrail);

        produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();
    }                           

    public void moverParaCima()
    {
        efeito.ligarTrailPCima();
        rigidBody.setVelocidade(new Vector2(0, garraDto.Velocidades.MovCima));
    }

    public void moverParaBaixo()
    {
        efeito.ligarTrailPBaixo();
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
}
