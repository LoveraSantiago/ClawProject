using System;
using UnityEngine;
using System.Collections.Generic;

public class Prateleiras : ScrollMovimentador<PrateleirasDto>,
                           AcaoBtnPrateleiraAcionado.ProdutorEvento
{
    private Sprite[] sprites;
    private ColetavelEntidade[] coletaveis;
    private PropsCimaBaixoPrateleiraDto propsDto;   

    private PopuladorPrateleira populadorPrateleira;
    private ProdutorDeEvento<bool> produtorDeEvento;

    public Prateleiras(PrateleirasDto prateleirasDto)
    {        
        populadorPrateleira = new PopuladorPrateleira();
        carregarSpritesColetaveis();
        calcularTamanhoArmario(prateleirasDto);
        carregarReferenciasPosicoes(prateleirasDto);
        popularArmario(prateleirasDto);

        propsDto.setPrateleiraCima(prateleirasDto.PrateleiraDto[0]);
        propsDto.setPrateleiraBaixo(prateleirasDto.PrateleiraDto[prateleirasDto.PrateleiraDto.Length - 1]);
        produtorDeEvento = new ProdutorDeEvento<bool>();
    }

    public override void movimentarParaBaixo(PrateleirasDto prateleirasDto)
    {
        float posYPrateleira = propsDto.prateleiraBaixo.RectTransformPrateleira.transform.position.y;
        if (propsDto.contadorBaixoSprites < sprites.Length && posYPrateleira > propsDto.posYReferenciaBaixo)
        {
            PrateleiraArmarioDto prateleiraCima = propsDto.prateleiraCima;
            populadorPrateleira.disposePrateleira(prateleiraCima);
            for (int contadorItens = 0; contadorItens < prateleiraCima.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraCima.ItensPrateleira[contadorItens];
                if (propsDto.contadorBaixoSprites < sprites.Length)
                {
                    populadorPrateleira.popularItemDaPrateleira(itemPrateleiraIt, sprites[propsDto.contadorBaixoSprites]);                    
                }
                else
                {
                    itemPrateleiraIt.GoItem.SetActive(false);
                }
                propsDto.incrementarContadorBaixoSprites();
            }
            reposicionarPrateleiraParaUltimaPosicao(prateleirasDto);
            propsDto.incrementarContadorCimaSprites(5);
            //Debug.Log("DESCER" + " PCima = " + contadorCimaSprites + " PBaixo = " + contadorBaixoSprites);
            //Debug.Log("DESCER" + " PCima = " + prateleiraCima.RectTransformPrateleira.name + " PBaixo = " + prateleiraBaixo.RectTransformPrateleira.name);
        }
    }   

    public bool isPrateleiraVisivel(int indiceOrdemColetavel)
    {
        return indiceOrdemColetavel <= propsDto.contadorBaixoSprites;
    }

    public override void movimentarParaCima(PrateleirasDto prateleirasDto)
    {
        float posYPrateleira = propsDto.prateleiraCima.RectTransformPrateleira.transform.position.y;
        if (propsDto.contadorCimaSprites > 0 && posYPrateleira < propsDto.posYReferenciaCima)
        {
            PrateleiraArmarioDto prateleiraBaixo = propsDto.prateleiraBaixo;
            populadorPrateleira.disposePrateleira(prateleiraBaixo);
            for (int contadorItens = prateleiraBaixo.ItensPrateleira.Length - 1; contadorItens >= 0; contadorItens--)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraBaixo.ItensPrateleira[contadorItens];
                if (propsDto.contadorCimaSprites >= 0)
                {
                    propsDto.decrementarContadorCimaSprites();
                    populadorPrateleira.popularItemDaPrateleira(itemPrateleiraIt, sprites[propsDto.contadorCimaSprites]);
                }
                else
                {
                    itemPrateleiraIt.GoItem.SetActive(false);
                }
            }
            reposicionarPrateleiraParaPrimeiraPosicao(prateleirasDto);
            propsDto.decrementarContadorBaixoSprites(5);            
            //Debug.Log("SUBIR" + " PCima = " + contadorCimaSprites + " PBaixo = " + contadorBaixoSprites);
            //Debug.Log("SUBIR" + " PCima = " + prateleiraCima.RectTransformPrateleira.name + " PBaixo = " + prateleiraBaixo.RectTransformPrateleira.name);
        }
    }

    private void reposicionarPrateleiraParaUltimaPosicao(PrateleirasDto prateleirasDto)
    {
        Vector2 posBaixo = propsDto.prateleiraBaixo.RectTransformPrateleira.anchoredPosition;
        float haltura = posBaixo.y - prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        propsDto.prateleiraCima.RectTransformPrateleira.anchoredPosition = new Vector2(posBaixo.x, haltura);

        propsDto.setPrateleiraBaixo(propsDto.prateleiraCima);
        int indicePrateleira = (int.Parse(propsDto.prateleiraCima.RectTransformPrateleira.name) + 1) % prateleirasDto.PrateleiraDto.Length;
        propsDto.setPrateleiraCima(prateleirasDto.PrateleiraDto[indicePrateleira]);
    }

    private void reposicionarPrateleiraParaPrimeiraPosicao(PrateleirasDto prateleirasDto)
    {
        Vector2 posCima = propsDto.prateleiraCima.RectTransformPrateleira.anchoredPosition;
        float haltura = posCima.y + prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        propsDto.prateleiraBaixo.RectTransformPrateleira.anchoredPosition = new Vector2(posCima.x, haltura);

        propsDto.setPrateleiraCima(propsDto.prateleiraBaixo);
        int indicePrateleira = ((int.Parse(propsDto.prateleiraBaixo.RectTransformPrateleira.name) + prateleirasDto.PrateleiraDto.Length) - 1) % prateleirasDto.PrateleiraDto.Length;
        propsDto.setPrateleiraBaixo(prateleirasDto.PrateleiraDto[indicePrateleira]);
    }

    private void carregarSpritesColetaveis()
    {
        //sprites = HelperColetavelEntidade.getAllSpritesColetaveisOrdenados();
        MapaEntidade[] mapas = FactoryMapaEntidade.getMapaEntidadesLiberados();
        List<ColetavelEntidade> listaDeColetaveis = new List<ColetavelEntidade>();
        for(int contador = 0; contador < mapas.Length; contador++)
        {
            ColetavelEntidade[] coletaveis = mapas[contador].getColetaveis();
            listaDeColetaveis.AddRange(coletaveis);
        }
        coletaveis = listaDeColetaveis.ToArray();
    }

    private void calcularTamanhoArmario(PrateleirasDto prateleirasDto)
    {
        float result = ((float)sprites.Length) / ((float)prateleirasDto.PrateleiraDto[0].ItensPrateleira.Length);
        int qtdPrateleira = (int)Math.Ceiling(result);
        int acrescimoPrateleiras = prateleirasDto.QtdPrateleirasVisiveis - qtdPrateleira;
        Debug.Log("result " + result + " qtdPrateleiras " + qtdPrateleira + " acrescimo " + acrescimoPrateleiras);
        float yAcrescimo = acrescimoPrateleiras * prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        prateleirasDto.RTransformArmario.offsetMin += new Vector2(0, yAcrescimo);

        float haltura = - (qtdPrateleira + 2) * prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        prateleirasDto.RPrateleiraBottom.anchoredPosition = new Vector2(prateleirasDto.RPrateleiraBottom.anchoredPosition.x, haltura);
    }

    private void carregarReferenciasPosicoes(PrateleirasDto prateleirasDto)
    {
        float posYReferenciaBaixo = prateleirasDto.RTransformRefBaixo.position.y;
        float posYReferenciaCima = prateleirasDto.RTransformRefCima.position.y;
        propsDto = new PropsCimaBaixoPrateleiraDto(posYReferenciaBaixo, posYReferenciaCima);
    }

    private void popularArmario(PrateleirasDto prateleirasDto)
    {
        for (int contadorPrateleiras = 0; contadorPrateleiras < prateleirasDto.PrateleiraDto.Length; contadorPrateleiras++)
        {
            PrateleiraArmarioDto prateleiraDtoIt = prateleirasDto.PrateleiraDto[contadorPrateleiras];
            for (int contadorItens = 0; contadorItens < prateleiraDtoIt.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraDtoIt.ItensPrateleira[contadorItens];
                if (propsDto.contadorBaixoSprites < sprites.Length)
                {
                    populadorPrateleira.popularItemDaPrateleira(itemPrateleiraIt, sprites[propsDto.contadorBaixoSprites]);
                    itemPrateleiraIt.BtnItem.onClick.AddListener(()=> btnPrateleiraAcionado());
                }
                else
                {
                    itemPrateleiraIt.GoItem.SetActive(false);
                }
                propsDto.incrementarContadorBaixoSprites();
            }
        }
    }

    private void btnPrateleiraAcionado()
    {
        produtorDeEvento.produziuEvento(true);
    }

    ProdutorDeEvento<bool> AcaoBtnPrateleiraAcionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
