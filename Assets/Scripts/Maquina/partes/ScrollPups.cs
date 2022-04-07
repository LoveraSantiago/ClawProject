using System.Collections.Generic;
using UnityEngine;

public class ScrollPups 
{
    public void configuradoPeloLevel(ScrollPupsDto scrollPupsDto, Dictionary<string, string> dicionarioDeCores)
    {
        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA];
        scrollPupsDto.SprRendererPlacaExterna.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA];
        scrollPupsDto.SprRendererPlacaInterna.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SCROLL_PUP_SETAS_LATERAIS];
        Color cor = Utils.getCorByHex(hexCor);
        scrollPupsDto.SprRendererPlacaSetaDireita.color = cor;
        scrollPupsDto.SprRendererPlacaSetaEsquerda.color = cor;

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.SCROLL_PUP_SETA_CIMA];
        scrollPupsDto.SprRendererPlacaSetaCima.color = cor;
    }
}
