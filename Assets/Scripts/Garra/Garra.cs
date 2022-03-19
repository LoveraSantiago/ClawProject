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
        definindoGenero(garraDto);

        pincas    = new GarraPincas(garraDto.Corpo.TransformPincaEsquerda, garraDto.Corpo.TransformPincaDireita);
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

    private void definindoGenero(GarraDto garraDto)
    {
        int generoConfigurado = PlayerPrefsGarra.getGarraMachoOrFemea();        
        if(generoConfigurado == 1)
        {
            GeneroGarraDto generoMacho = garraDto.GeneroMacho;
            setarGenero(garraDto.Corpo, generoMacho);
        }
        else
        {
            GeneroGarraDto generoFemea = garraDto.GeneroFemea;
            setarGenero(garraDto.Corpo, generoFemea);
        }
    }

    private void setarGenero(CorpoGarraDto corpo, GeneroGarraDto genero)
    {
        corpo.SprRendererBaseCorpo.sprite = genero.CorpoBase;
        corpo.SprRendererPincaDireita.sprite  = genero.Pinca;
        corpo.SprRendererPincaEsquerda.sprite = genero.Pinca;
        corpo.SprRendererSimbolo.sprite = genero.Simbolo;
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
