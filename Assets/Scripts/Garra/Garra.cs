using UnityEngine;

public class Garra : ComponenteRigidBodyDaGarra,
                     AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{
    public GarraPincas           pincas { get; private set; }
    public AbstractGarraAnimacao animacao { get; private set; }
    public GarraRigidBody        rigidBody { get; private set; }    
    public GarraEfeito           efeito { get; private set; }

    private ProdutorDeEvento<DirecaoDaGarra> produtorEventoDirecao;

    public Garra(GarraDto garraDto)
        :base(garraDto)
    {        
        definindoGenero(garraDto);

        pincas    = new GarraPincas(garraDto.Corpo.TransformPincaEsquerda, garraDto.Corpo.TransformPincaDireita);        
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
            animacao = new GarraAnimacaoMacho(garraDto.Corpo.Animator);
        }
        else
        {
            GeneroGarraDto generoFemea = garraDto.GeneroFemea;
            setarGenero(garraDto.Corpo, generoFemea);
            animacao = new GarraAnimacaoFemea(garraDto.Corpo.Animator);
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
