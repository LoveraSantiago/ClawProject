using System.Collections.Generic;
using UnityEngine;

public class ColoridorDisplaysColetadosV2
{
    public void colorir(
        SpriteRenderer sprRendererPlacaGrupo,
        SingleDisplayDeColetado[] displayDeSlot, 
        Dictionary<string, string> dicionarioDeCores)
    {
        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_GRUPO];
        sprRendererPlacaGrupo.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL1];
        displayDeSlot[0].configuradoPeloLevel(Utils.getCorByHex(hexCor));

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL2];
        displayDeSlot[1].configuradoPeloLevel(Utils.getCorByHex(hexCor));

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL3];
        displayDeSlot[2].configuradoPeloLevel(Utils.getCorByHex(hexCor));
    }
}
