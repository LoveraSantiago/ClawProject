using System;
using UnityEngine;

public class Prateleiras 
{
    private PrateleirasDto prateleirasDto;

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
        this.prateleirasDto = prateleirasDto;
        populadorPrateleira = new PopuladorPrateleira();

        carregarSpritesColetaveis();
        calcularTamanhoArmario();
        carregarReferenciasPosicoes();
        popularArmario();

        prateleiraCima = prateleirasDto.PrateleiraDto[0];
        prateleiraBaixo = prateleirasDto.PrateleiraDto[prateleirasDto.PrateleiraDto.Length - 1];

    }

    public void movimentarParaBaixo()
    {
        float posYPrateleira = prateleiraBaixo.RectTransformPrateleira.transform.position.y;
        if (contadorBaixoSprites < sprites.Length && posYPrateleira > posYReferenciaBaixo)
        {
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
            reposicionarPrateleiraParaUltimaPosicao();
            contadorCimaSprites += 5;
            Debug.Log("DESCER" + " PCima = " + contadorCimaSprites + " PBaixo = " + contadorBaixoSprites);
            Debug.Log("DESCER" + " PCima = " + prateleiraCima.RectTransformPrateleira.name + " PBaixo = " + prateleiraBaixo.RectTransformPrateleira.name);
        }
    }   

    public void movimentarParaCima()
    {
        float posYPrateleira = prateleiraCima.RectTransformPrateleira.transform.position.y;
        if (contadorCimaSprites > 0 && posYPrateleira < posYReferenciaCima)
        {
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
            reposicionarPrateleiraParaPrimeiraPosicao();
            contadorBaixoSprites -= 5;
            Debug.Log("SUBIR" + " PCima = " + contadorCimaSprites + " PBaixo = " + contadorBaixoSprites);
            Debug.Log("SUBIR" + " PCima = " + prateleiraCima.RectTransformPrateleira.name + " PBaixo = " + prateleiraBaixo.RectTransformPrateleira.name);
        }
    }

    private void reposicionarPrateleiraParaUltimaPosicao()
    {
        Vector2 posBaixo = prateleiraBaixo.RectTransformPrateleira.anchoredPosition;
        prateleiraCima.RectTransformPrateleira.anchoredPosition = new Vector2(posBaixo.x, posBaixo.y - 400f);

        prateleiraBaixo = prateleiraCima;
        int indicePrateleira = (int.Parse(prateleiraCima.RectTransformPrateleira.name) + 1) % prateleirasDto.PrateleiraDto.Length;
        prateleiraCima = prateleirasDto.PrateleiraDto[indicePrateleira];
        populadorPrateleira.disposePrateleira(prateleiraCima);
    }

    private void reposicionarPrateleiraParaPrimeiraPosicao()
    {
        Vector2 posCima = prateleiraCima.RectTransformPrateleira.anchoredPosition;
        prateleiraBaixo.RectTransformPrateleira.anchoredPosition = new Vector2(posCima.x, posCima.y + 400);

        prateleiraCima = prateleiraBaixo;
        int indicePrateleira = ((int.Parse(prateleiraBaixo.RectTransformPrateleira.name) + prateleirasDto.PrateleiraDto.Length) - 1) % prateleirasDto.PrateleiraDto.Length;
        prateleiraBaixo = prateleirasDto.PrateleiraDto[indicePrateleira];
        populadorPrateleira.disposePrateleira(prateleiraBaixo);
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
        //PROBLEMA AQUI NO DISPOSE
    }

    private void carregarSpritesColetaveis()
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        sprites = helperColetavel.getAllSpritesColetaveisOrdenados();
    }

    private void calcularTamanhoArmario()
    {
        float result = ((float)sprites.Length) / ((float)prateleirasDto.PrateleiraDto[0].ItensPrateleira.Length);
        int qtdPrateleira = (int)Math.Ceiling(result);
        int acrescimoPrateleiras = prateleirasDto.QtdPrateleirasVisiveis - qtdPrateleira;        
        prateleirasDto.RTransformArmario.offsetMin += new Vector2(prateleirasDto.RTransformArmario.offsetMin.x, (acrescimoPrateleiras * 400));
    }

    private void carregarReferenciasPosicoes()
    {
        posYReferenciaBaixo = prateleirasDto.RTransformRefBaixo.position.y;
        posYReferenciaCima = prateleirasDto.RTransformRefCima.position.y;
    }

    private void popularArmario()
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
