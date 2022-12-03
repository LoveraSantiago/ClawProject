using System.Collections.Generic;
using UnityEngine;

public class ColoridorScrollPups
{
    public void colorir(ScrollPupsDto scrollPupsDto)
    {
        Dictionary<string, string> dicionarioDeCores = ContextoEstaticoUtils.level.getDicionarioDeCores();
        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA];
        scrollPupsDto.SprRendererPlacaExterna.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA];
        scrollPupsDto.SprRendererPlacaInterna.color = CorUtils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SCROLL_PUP_SETAS_LATERAIS];
        Color cor = CorUtils.getCorByHex(hexCor);
        scrollPupsDto.SprRendererPlacaSetaDireita.color = cor;
        scrollPupsDto.SprRendererPlacaSetaEsquerda.color = cor;

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SCROLL_PUP_SETA_CIMA];
        scrollPupsDto.SprRendererPlacaSetaCima.color = cor;

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SCROLL_PUP_DIVISORIA];
        cor = CorUtils.getCorByHex(hexCor);
        for(int contador = 0; contador < scrollPupsDto.ItensScrollPup.Length; contador++)
        {
            scrollPupsDto.ItensScrollPup[contador].SprRendererDivisoria.color = cor;
        }
    }
}
