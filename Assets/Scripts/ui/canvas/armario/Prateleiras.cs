using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Prateleiras 
{
    private PrateleirasDto prateleirasDto;
    private Sprite[] sprites;

    public Prateleiras(PrateleirasDto prateleirasDto)
    {
        this.prateleirasDto = prateleirasDto;
        carregarSpritesColetaveis();
    }

    private void carregarSpritesColetaveis()
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        sprites = helperColetavel.getAllSpritesColetaveisOrdenados();
    }

    private void calcularTamanhoArmario()
    {
        float result = ((float)sprites.Length) / ((float)prateleirasDto.PrateleiraDto[0].ItensPrateleira.Length);
        //int qtdPrateleira = (int)Math.Ceiling(result);
        //int acrescimoPrateleiras = qtdPrateleirasVisiveis - qtdPrateleira;

        //rTransformArmario.offsetMin += new Vector2(rTransformArmario.offsetMin.x, (acrescimoPrateleiras * 400));
    }
}
