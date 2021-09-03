using System.Collections.Generic;
using UnityEngine;

public class ColoridorDisplaysColetados 
{
    public void colorir(DisplayDeSlot[] displayDeSlot, Dictionary<string, string> dicionarioDeCores)
    {
        string hexCorDisplay = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_COLETADOS];
        Color corDisplay = Utils.getCorByHex(hexCorDisplay);

        string hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO1];
        displayDeSlot[0].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDentro));

        hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO2];
        displayDeSlot[1].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDentro));

        hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO3];
        displayDeSlot[2].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDentro));
    }
}
