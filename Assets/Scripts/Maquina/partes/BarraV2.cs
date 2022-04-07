using System.Collections.Generic;
using UnityEngine;

public class BarraV2 
{
    public void configuradoPeloLevel(BarraDtoV2 barraDto, Dictionary<string, string> dicionarioDeCores)
    {
        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.BARRA];
        Color cor = Utils.getCorByHex(hexCor);

        barraDto.SprRendererBarra.color           = cor;
        barraDto.SprRendererSuporteEsquerda.color = cor;
        barraDto.SprRendererSuporteDireita.color  = cor;        
    }
}
