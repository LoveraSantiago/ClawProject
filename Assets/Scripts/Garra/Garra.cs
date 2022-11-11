using UnityEngine;

public class Garra : ComponenteAnimacaoDaGarra,
                     AcaoSincroniaComDirecaoDaGarra.ProdutorEvento
{   
    private ProdutorDeEvento<Direcao> produtorEventoDirecao;

    public Garra(GarraDto garraDto)
        :base(garraDto)
    {        
        definindoGenero(garraDto);        
        produtorEventoDirecao = new ProdutorDeEvento<Direcao>();
    }          
    
    public Vector3 getPosicaoCentroGarra()
    {
        return garraDto.Corpo.CentroDaGarra.position;
    }

    public void dispararEventoDirecao(int direcao)
    {
        if (direcao == 1)
        {
            produtorEventoDirecao.produziuEvento(Direcao.DIREITA);
        }
        else
        {
            produtorEventoDirecao.produziuEvento(Direcao.ESQUERDA);
        }
    }

    private void definindoGenero(GarraDto garraDto)
    {
        Genero genero = PlayerPrefsGarra.getGarraMachoOrFemea();        
        if(GeneroUtils.isGeneroMacho(genero))
        {
            GeneroGarraDto generoMacho = garraDto.GeneroMacho;
            setarGenero(garraDto.Corpo, generoMacho);
            animacaoMacho();
        }
        else
        {
            GeneroGarraDto generoFemea = garraDto.GeneroFemea;
            setarGenero(garraDto.Corpo, generoFemea);
            animacaoFemea();
        }
    }

    private void setarGenero(CorpoGarraDto corpo, GeneroGarraDto genero)
    {
        corpo.SprRendererBaseCorpo.sprite = genero.CorpoBase;
        corpo.SprRendererPincaDireita.sprite  = genero.Pinca;
        corpo.SprRendererPincaEsquerda.sprite = genero.Pinca;
        corpo.SprRendererSimbolo.sprite = genero.Simbolo;
    }

    public void dispararEventoDirecao(Direcao direcao)
    {
        produtorEventoDirecao.produziuEvento(direcao);
    }

    ProdutorDeEvento<Direcao> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorEventoDirecao;
    }
}
