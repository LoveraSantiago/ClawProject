using System.Collections.Generic;
using UnityEngine;

public class TudoDeSaidaV2 
{
    private TuboDtoV2 tuboDto;

    public TudoDeSaidaV2(TuboDtoV2 tuboDto)
    {
        this.tuboDto = tuboDto;
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.TUBO_BASE];
        Color corBase = Utils.getCorByHex(hexCor);
        corBase.a = 0.88f;
        tuboDto.SprRendererBase.color = corBase;

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.TUBO_BORDA];
        tuboDto.SprRendererTopo.color = Utils.getCorByHex(hexCor);
    }   
}
