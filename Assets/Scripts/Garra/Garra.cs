using UnityEngine;

public class Garra : AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    public GarraDto garraDto;

    public GarraPincas    pincas { get; private set; }
    public GarraAnimacao  animacao { get; private set; }
    public GarraRigidBody rigidBody { get; private set; }    
    public GarraEfeito    efeito { get; private set; }

    private ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao;

    public Garra(GarraDto garraDto)
    {
        this.garraDto = garraDto;                

        pincas    = new GarraPincas(garraDto.Corpo.PincaEsquerda, garraDto.Corpo.PincaDireita);
        animacao  = new GarraAnimacao(garraDto.Corpo.Animator);
        rigidBody = new GarraRigidBody(garraDto);
        efeito    = new GarraEfeito(garraDto.EfeitoTrail);

        produtorEventoDirecao = new ProdutorDeEvento<DirecaoDaGarra>();
    }          
    
    public Vector3 getPosicaoCentroGarra()
    {
        return garraDto.Corpo.CentroDaGarra.position;
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

    public void dispararEventoDirecao(DirecaoDaGarra direcao)
    {
        produtorEventoDirecao.produziuEvento(direcao);
    }

    ProdutorDeEvento<DirecaoDaGarra> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorEventoDirecao;
    }
}
