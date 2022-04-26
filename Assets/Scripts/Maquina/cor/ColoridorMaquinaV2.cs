using System.Collections.Generic;
using UnityEngine;

public class ColoridorMaquinaV2 
{
    public void colorir(
        PartesMaquinaDtoV2 partesDto, Dictionary<string, string> dicionarioDeCores)
    {
        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.PLACA_FRENTE];
        partesDto.PlacaFrente.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.BASE_CHAO];
        partesDto.BaseChao.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.VIGAS];
        Color cor = Utils.getCorByHex(hexCor);
        partesDto.SpriteRendererVigaDireita.color = cor;
        partesDto.SpriteRendererVigaEsquerda.color = cor;

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_EXTERNO];
        colorirSimbolos(hexCor, partesDto.SimbolosParteExterna);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO];
        colorirSimbolos(hexCor, partesDto.SimbolosParteInterna);
    }

    private void colorirSimbolos(string hexCor, SpriteRenderer[] spriteRenderers)
    {
        Color cor = Utils.getCorByHex(hexCor);
        for(int contador = 0; contador < spriteRenderers.Length; contador++)
        {
            spriteRenderers[contador].color = cor;
        }
    }
}
