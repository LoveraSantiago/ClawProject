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
        partesDto.SprRendererVigaDireita.color = cor;
        partesDto.SprRendererVigaEsquerda.color = cor;

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.BARRA];
        partesDto.SprRendererBarra.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_EXTERNO];
        colorirSimbolos(hexCor, partesDto.SimbolosParteExterna);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO];
        colorirSimbolos(hexCor, partesDto.SimbolosParteInterna);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.CHAO_DENTRO];
        partesDto.SprRendererChao.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.TUBO_BASE];
        Color corBase = Utils.getCorByHex(hexCor);
        corBase.a = 0.88f;
        partesDto.SprRendererTuboBase.color = corBase;

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.TUBO_BORDA];
        partesDto.SprRendererTuboTopo.color = Utils.getCorByHex(hexCor);
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
