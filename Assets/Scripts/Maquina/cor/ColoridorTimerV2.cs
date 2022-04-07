using System.Collections.Generic;
using UnityEngine;

public class ColoridorTimerV2 
{
    private SpriteRenderer placaTimer;
    private DisplayTimerDigito[] displayTimerDigito;

    public ColoridorTimerV2(SpriteRenderer placaTimer, DisplayTimerDigito[] displayTimerDigito)
    {
        this.placaTimer = placaTimer;
        this.displayTimerDigito = displayTimerDigito;
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
        iniciarDisplayTimers();        
    }

    private void passarCoresAosDisplaysDigitos(Color corDigito, Color corPlaca)
    {
        for (int contador = 0; contador < displayTimerDigito.Length; contador++)
        {
            displayTimerDigito[contador].configuradoPeloLevel(corDigito, corPlaca);
        }
    }

    private void iniciarDisplayTimers()
    {
        for (int contador = 0; contador < displayTimerDigito.Length - 1; contador++)
        {
            displayTimerDigito[contador].mostrarDigito(0);
        }
    }
}
