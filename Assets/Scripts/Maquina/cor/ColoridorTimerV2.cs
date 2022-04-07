using System.Collections.Generic;
using UnityEngine;

public class ColoridorTimerV2 
{
    private SpriteRenderer placaTimer;
    private DisplayTimerDigitos displayTimerDigitos;

    public ColoridorTimerV2(SpriteRenderer placaTimer, DisplayTimerDigitos displayTimerDigito)
    {
        this.placaTimer = placaTimer;
        this.displayTimerDigitos = displayTimerDigito;
    }

    public void colorir(Dictionary<string, string> dicionarioDeCores)
    {
        string corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL];
        placaTimer.color = Utils.getCorByHex(corDigitosHex);

        corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS];
        Color corDigito = Utils.getCorByHex(corDigitosHex);

        corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO];
        Color corPlaca = Utils.getCorByHex(corDigitosHex);

        passarCoresAosDisplaysDigitos(corDigito, corPlaca);
        DisplayTimerDigito2Pontos displayTimer2Pontos = displayTimerDigitos.getDisplayTimer2Segmentos();
        displayTimer2Pontos.configuradoPeloLevel(corDigito);

    }

    private void passarCoresAosDisplaysDigitos(Color corDigito, Color corPlaca)
    {
        for (int contador = 0; contador < displayTimerDigitos.getQtdDisplaysDigitos(); contador++)
        {
            DisplayTimerDigito displayTimerDigito = displayTimerDigitos.getDisplayTimer(contador);
            displayTimerDigito.configuradoPeloLevel(corDigito, corPlaca);
        }
    }    
}
