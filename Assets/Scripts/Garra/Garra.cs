using UnityEngine;

public class Garra 
{
    public GarraDto garraDto;

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
        rigidBody = new GarraRigidBody(garraDto);
        efeito    = new GarraEfeito(garraDto.EfeitoTrail);

        produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();
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

   
}
