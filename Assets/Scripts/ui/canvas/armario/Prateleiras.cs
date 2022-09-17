using System.Collections.Generic;
using UnityEngine;

public class Prateleiras : ScrollMovimentador<PrateleirasDto>,
                           AcaoBtnPrateleiraAcionado.ProdutorEvento
{
    private ColetavelEntidade[] coletaveis;
    private PropsCimaBaixoPrateleiraDto propsDto;   

    private PopuladorPrateleira populadorPrateleira;
    private ProdutorDeEvento<bool> produtorDeEvento;

    public Prateleiras(PrateleirasDto prateleirasDto)
    {        
        produtorDeEvento = new ProdutorDeEvento<bool>();
        populadorPrateleira = new PopuladorPrateleira();
        carregarColetaveis();
        configurarPrateleiras(prateleirasDto);                
    }

    public override void movimentarParaBaixo(PrateleirasDto prateleirasDto)
    {
        float posYPrateleira = propsDto.prateleiraBaixo.RectTransformPrateleira.transform.position.y;
        if (propsDto.contadorBaixoSprites < coletaveis.Length && posYPrateleira > propsDto.posYReferenciaBaixo)
        {
            PrateleiraArmarioDto prateleiraCima = propsDto.prateleiraCima;
            populadorPrateleira.disposePrateleira(prateleiraCima);
            for (int contadorItens = 0; contadorItens < prateleiraCima.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraCima.ItensPrateleira[contadorItens];
                if (propsDto.contadorBaixoSprites < coletaveis.Length)
                {
                    populadorPrateleira.popularItemDaPrateleira(itemPrateleiraIt, coletaveis[propsDto.contadorBaixoSprites]);                    
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
                    populadorPrateleira.popularItemDaPrateleira(itemPrateleiraIt, coletaveis[propsDto.contadorCimaSprites]);
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

    private void carregarColetaveis()
    {
        //sprites = HelperColetavelEntidade.getAllSpritesColetaveisOrdenados();
        MapaEntidade[] mapas = FactoryMapaEntidade.getMapaEntidadesLiberados(1);
        List<ColetavelEntidade> listaDeColetaveis = new List<ColetavelEntidade>();
        for(int contador = 0; contador < mapas.Length; contador++)
        {
            ColetavelEntidade[] coletaveis = mapas[contador].getColetaveis();
            listaDeColetaveis.AddRange(coletaveis);
        }
        coletaveis = listaDeColetaveis.ToArray();
    }      

    private void configurarPrateleiras(PrateleirasDto prateleirasDto)
    {
        ConfiguradorDePrateleiras configurador = new ConfiguradorDePrateleiras(coletaveis, prateleirasDto);
        configurador.config1CalcularTamanhoArmario();
        configurador.config2CarregarReferenciasPosicoes();
        configurador.config3PopularArmario(populadorPrateleira, produtorDeEvento);

        propsDto = configurador.propsDto;
        propsDto.setPrateleiraCima(prateleirasDto.PrateleiraDto[0]);
        propsDto.setPrateleiraBaixo(prateleirasDto.PrateleiraDto[prateleirasDto.PrateleiraDto.Length - 1]);
    }

    ProdutorDeEvento<bool> AcaoBtnPrateleiraAcionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
