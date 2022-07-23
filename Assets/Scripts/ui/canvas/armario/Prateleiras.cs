using System;
using UnityEngine;

public class Prateleiras 
{
    private Sprite[] sprites;

    private float posYReferenciaBaixo;
    private float posYReferenciaCima;

    private int contadorBaixoSprites;
    private int contadorCimaSprites;

    private PrateleiraArmarioDto prateleiraCima;
    private PrateleiraArmarioDto prateleiraBaixo;

    private PopuladorPrateleira populadorPrateleira;

    public Prateleiras(PrateleirasDto prateleirasDto)
    {        
        populadorPrateleira = new PopuladorPrateleira();

        carregarSpritesColetaveis();
        calcularTamanhoArmario(prateleirasDto);
        carregarReferenciasPosicoes(prateleirasDto);
        popularArmario(prateleirasDto);

        prateleiraCima = prateleirasDto.PrateleiraDto[0];
        prateleiraBaixo = prateleirasDto.PrateleiraDto[prateleirasDto.PrateleiraDto.Length - 1];
    }

    public void movimentarParaBaixo(PrateleirasDto prateleirasDto)
    {
        float posYPrateleira = prateleiraBaixo.RectTransformPrateleira.transform.position.y;
        if (contadorBaixoSprites < sprites.Length && posYPrateleira > posYReferenciaBaixo)
        {
            populadorPrateleira.disposePrateleira(prateleiraCima);
            for (int contadorItens = 0; contadorItens < prateleiraCima.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraCima.ItensPrateleira[contadorItens];
                if (contadorBaixoSprites < sprites.Length)
                {
                    populadorPrateleira.popularItemDaPrateleira(itemPrateleiraIt, sprites[contadorBaixoSprites]);                    
                }
                else
                {
                    itemPrateleiraIt.GoItem.SetActive(false);
                }
                contadorBaixoSprites++;
            }
            reposicionarPrateleiraParaUltimaPosicao(prateleirasDto);
            contadorCimaSprites += 5;
            //Debug.Log("DESCER" + " PCima = " + contadorCimaSprites + " PBaixo = " + contadorBaixoSprites);
            //Debug.Log("DESCER" + " PCima = " + prateleiraCima.RectTransformPrateleira.name + " PBaixo = " + prateleiraBaixo.RectTransformPrateleira.name);
        }
    }   

    public bool isPrateleiraBaixoVisivel()
    {
        float posYPrateleira = prateleiraBaixo.RectTransformPrateleira.transform.position.y;
        return posYPrateleira > posYReferenciaBaixo;
    }

    public void movimentarParaCima(PrateleirasDto prateleirasDto)
    {
        float posYPrateleira = prateleiraCima.RectTransformPrateleira.transform.position.y;
        if (contadorCimaSprites > 0 && posYPrateleira < posYReferenciaCima)
        {
            populadorPrateleira.disposePrateleira(prateleiraBaixo);
            for (int contadorItens = prateleiraBaixo.ItensPrateleira.Length - 1; contadorItens >= 0; contadorItens--)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraBaixo.ItensPrateleira[contadorItens];
                if (contadorCimaSprites >= 0)
                {
                    populadorPrateleira.popularItemDaPrateleira(itemPrateleiraIt, sprites[--contadorCimaSprites]);
                }
                else
                {
                    itemPrateleiraIt.GoItem.SetActive(false);
                }
            }
            reposicionarPrateleiraParaPrimeiraPosicao(prateleirasDto);
            contadorBaixoSprites -= 5;
            //Debug.Log("SUBIR" + " PCima = " + contadorCimaSprites + " PBaixo = " + contadorBaixoSprites);
            //Debug.Log("SUBIR" + " PCima = " + prateleiraCima.RectTransformPrateleira.name + " PBaixo = " + prateleiraBaixo.RectTransformPrateleira.name);
        }
    }

    private void reposicionarPrateleiraParaUltimaPosicao(PrateleirasDto prateleirasDto)
    {
        Vector2 posBaixo = prateleiraBaixo.RectTransformPrateleira.anchoredPosition;
        float haltura = posBaixo.y - prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        prateleiraCima.RectTransformPrateleira.anchoredPosition = new Vector2(posBaixo.x, haltura);
                
        prateleiraBaixo = prateleiraCima;
        int indicePrateleira = (int.Parse(prateleiraCima.RectTransformPrateleira.name) + 1) % prateleirasDto.PrateleiraDto.Length;
        prateleiraCima = prateleirasDto.PrateleiraDto[indicePrateleira];
    }

    private void reposicionarPrateleiraParaPrimeiraPosicao(PrateleirasDto prateleirasDto)
    {
        Vector2 posCima = prateleiraCima.RectTransformPrateleira.anchoredPosition;
        float haltura = posCima.y + prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        prateleiraBaixo.RectTransformPrateleira.anchoredPosition = new Vector2(posCima.x, haltura);
                
        prateleiraCima = prateleiraBaixo;
        int indicePrateleira = ((int.Parse(prateleiraBaixo.RectTransformPrateleira.name) + prateleirasDto.PrateleiraDto.Length) - 1) % prateleirasDto.PrateleiraDto.Length;
        prateleiraBaixo = prateleirasDto.PrateleiraDto[indicePrateleira];
    }

    private void carregarSpritesColetaveis()
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        sprites = helperColetavel.getAllSpritesColetaveisOrdenados();
    }

    private void calcularTamanhoArmario(PrateleirasDto prateleirasDto)
    {
        float result = ((float)sprites.Length) / ((float)prateleirasDto.PrateleiraDto[0].ItensPrateleira.Length);
        int qtdPrateleira = (int)Math.Ceiling(result);
        int acrescimoPrateleiras = prateleirasDto.QtdPrateleirasVisiveis - qtdPrateleira;
        Debug.Log("result " + result + " qtdPrateleiras " + qtdPrateleira + " acrescimo " + acrescimoPrateleiras);
        float yAcrescimo = acrescimoPrateleiras * prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        prateleirasDto.RTransformArmario.offsetMin += new Vector2(prateleirasDto.RTransformArmario.offsetMin.x, yAcrescimo);

        float haltura = - (qtdPrateleira + 2) * prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        prateleirasDto.RPrateleiraBottom.anchoredPosition = new Vector2(prateleirasDto.RPrateleiraBottom.anchoredPosition.x, haltura);
    }

    private void carregarReferenciasPosicoes(PrateleirasDto prateleirasDto)
    {
        posYReferenciaBaixo = prateleirasDto.RTransformRefBaixo.position.y;
        posYReferenciaCima = prateleirasDto.RTransformRefCima.position.y;
    }

    private void popularArmario(PrateleirasDto prateleirasDto)
    {
        for (int contadorPrateleiras = 0; contadorPrateleiras < prateleirasDto.PrateleiraDto.Length; contadorPrateleiras++)
        {
            PrateleiraArmarioDto prateleiraDtoIt = prateleirasDto.PrateleiraDto[contadorPrateleiras];
            for (int contadorItens = 0; contadorItens < prateleiraDtoIt.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraDtoIt.ItensPrateleira[contadorItens];
                if (contadorBaixoSprites < sprites.Length)
                {
                    populadorPrateleira.popularItemDaPrateleira(itemPrateleiraIt, sprites[contadorBaixoSprites]);                    
                }
                else
                {
                    itemPrateleiraIt.GoItem.SetActive(false);
                }
                contadorBaixoSprites++;
            }
        }
    }
}
