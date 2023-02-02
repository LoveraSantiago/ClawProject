using System;
using UnityEngine;

public class ConfiguradorDePrateleiras 
{
    private ColetavelEntidade[] coletaveis;
    private PrateleirasDto prateleirasDto;
    public PropsCimaBaixoPrateleiraDto propsDto { get; private set; }

    public ConfiguradorDePrateleiras(ColetavelEntidade[] coletaveis, PrateleirasDto prateleirasDto)
    {
        this.coletaveis = coletaveis;
        this.prateleirasDto = prateleirasDto;
    }

    public void config1CalcularTamanhoArmario()
    {
        float result = ((float)coletaveis.Length) / ((float)prateleirasDto.PrateleiraDto[0].ItensPrateleira.Length);
        int qtdPrateleira = (int)Math.Ceiling(result) + 1;
        int acrescimoPrateleiras = prateleirasDto.QtdPrateleirasVisiveis - qtdPrateleira;
        //Debug.Log("result " + result + " qtdPrateleiras " + qtdPrateleira + " acrescimo " + acrescimoPrateleiras);
        float yAcrescimo = acrescimoPrateleiras * prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        prateleirasDto.RTransformArmario.offsetMin += new Vector2(0, yAcrescimo);

        float haltura = -(qtdPrateleira + 2) * prateleirasDto.PrateleiraDto[0].RectTransformPrateleira.rect.height;
        prateleirasDto.RPrateleiraBottom.anchoredPosition = new Vector2(prateleirasDto.RPrateleiraBottom.anchoredPosition.x, haltura);
    }

    public void config2CarregarReferenciasPosicoes()
    {
        float posYReferenciaBaixo = prateleirasDto.RTransformRefBaixo.position.y;
        float posYReferenciaCima = prateleirasDto.RTransformRefCima.position.y;
        propsDto = new PropsCimaBaixoPrateleiraDto(posYReferenciaBaixo, posYReferenciaCima);
    }

    public void config3PopularArmario(
        PopuladorPrateleira populadorPrateleira, ProdutorDeEvento<bool> produtorDeEvento, SomManagerColetaveis somManager)
    {
        for (int contadorPrateleiras = 0; contadorPrateleiras < prateleirasDto.PrateleiraDto.Length; contadorPrateleiras++)
        {
            PrateleiraArmarioDto prateleiraDtoIt = prateleirasDto.PrateleiraDto[contadorPrateleiras];
            int itensPopulados = 0;
            for (int contadorItens = 0; contadorItens < prateleiraDtoIt.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraDtoIt.ItensPrateleira[contadorItens];
                if (propsDto.contadorBaixoSprites < coletaveis.Length)
                {
                    populadorPrateleira.popularItemDaPrateleira(itemPrateleiraIt, coletaveis[propsDto.contadorBaixoSprites]);
                    itemPrateleiraIt.BtnItem.onClick.AddListener(() => {
                            somManager.playSomCliqueColetavel();
                            btnPrateleiraAcionado(produtorDeEvento);
                        });
                    itensPopulados++;
                }
                else
                {
                    itemPrateleiraIt.GoItem.SetActive(false);
                }
                propsDto.incrementarContadorBaixoSprites();

                if(itensPopulados == 0)
                {
                    prateleiraDtoIt.RectTransformPrateleira.gameObject.SetActive(false);
                }
            }
        }
    }

    private void btnPrateleiraAcionado(ProdutorDeEvento<bool> produtorDeEvento)
    {
        produtorDeEvento.produziuEvento(true);
    }
}
