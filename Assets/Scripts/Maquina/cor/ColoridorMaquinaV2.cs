using System.Collections.Generic;
using UnityEngine;

public class ColoridorMaquinaV2 
{
    public void colorir(
        PartesMaquinaDtoV2 partesDto)
    {
        Dictionary<string, string> dicionarioDeCores = ContextoEstaticoUtils.level.getDicionarioDeCores();
        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.PLACA_FRENTE];
        partesDto.PlacaFrente.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.BASE_CHAO];
        partesDto.BaseChao.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.VIGAS];
        Color cor = CorUtils.getCorByHex(hexCor);
        partesDto.SprRendererVigaDireita.color = cor;
        partesDto.SprRendererVigaEsquerda.color = cor;

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.BARRA];
        partesDto.SprRendererBarra.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_EXTERNO];
        colorirSimbolos(hexCor, partesDto.SimbolosParteExterna);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO];
        colorirSimbolos(hexCor, partesDto.SimbolosParteInterna);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.CHAO_DENTRO];
        partesDto.SprRendererChao.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.TUBO_BASE];
        Color corBase = CorUtils.getCorByHex(hexCor);
        corBase.a = 0.88f;
        partesDto.SprRendererTuboBase.color = corBase;

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.TUBO_BORDA];
        partesDto.SprRendererTuboTopo.color = CorUtils.getCorByHex(hexCor);
    }

    private void colorirSimbolos(string hexCor, SpriteRenderer[] spriteRenderers)
    {
        Color cor = CorUtils.getCorByHex(hexCor);
        for(int contador = 0; contador < spriteRenderers.Length; contador++)
        {
            spriteRenderers[contador].color = cor;
        }
    }
}
