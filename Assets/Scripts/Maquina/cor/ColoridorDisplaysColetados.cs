using System.Collections.Generic;
using UnityEngine;

public class ColoridorDisplaysColetados 
{
    public void colorir(DisplayDeColetado[] displayDeColetado, Dictionary<string, string> dicionarioDeCores)
    {
        string hexCorDisplay = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_COLETADOS];
        Color corDisplay = Utils.getCorByHex(hexCorDisplay);

        string hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO1];
        displayDeColetado[0].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDentro));

        hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO2];
        displayDeColetado[1].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDentro));

        hexCorDentro = dicionarioDeCores[ConstantesCoresMaquina.PLACA_COLETADO3];
        displayDeColetado[2].configuradoPeloLevel(corDisplay, Utils.getCorByHex(hexCorDentro));
    }
}
