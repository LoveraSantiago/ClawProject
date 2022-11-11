using System.Collections.Generic;

public class ColoridorDisplaysColetadosV2
{
    public void colorir(        
        SingleDisplayDeColetado[] displayDeSlot, 
        Dictionary<string, string> dicionarioDeCores)
    {
        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_GRUPO];
        displayDeSlot[0].colorirPlacaGrupo(CorUtils.getCorByHex(hexCor));

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL1];
        displayDeSlot[0].configuradoPeloLevel(CorUtils.getCorByHex(hexCor));

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL2];
        displayDeSlot[1].configuradoPeloLevel(CorUtils.getCorByHex(hexCor));

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL3];
        displayDeSlot[2].configuradoPeloLevel(CorUtils.getCorByHex(hexCor));
    }
}
