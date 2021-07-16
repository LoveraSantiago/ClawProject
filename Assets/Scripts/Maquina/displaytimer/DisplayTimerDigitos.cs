using System.Collections.Generic;
using UnityEngine;

public class DisplayTimerDigitos 
{
    public int segundosUnidadeAtual{ get; private set; }
    public int segundosDezenaAtual { get; private set; }
    public int minutosUnidadeAtual { get; private set; }
    public int minutosDezenaAtual  { get; private set; }

    private SpriteRenderer placaTimer;

    public DisplayTimerDigito[] displayTimerDigito { get; private set; }

    public DisplayTimerDigitos(DisplayTimerDto displayDto)
    {
        placaTimer = displayDto.SprRendererPlaca;

        displayTimerDigito = new DisplayTimerDigito[4];
        displayTimerDigito[0] = new DisplayTimerDigito(displayDto.SingleDisplay[0]);
        displayTimerDigito[1] = new DisplayTimerDigito(displayDto.SingleDisplay[1]);
        displayTimerDigito[2] = new DisplayTimerDigito(displayDto.SingleDisplay[2]);
        displayTimerDigito[3] = new DisplayTimerDigito(displayDto.SingleDisplay[3]);
    }

    public void passarCoresAosDisplayDigitos(Dictionary<string, string> dicionarioDeCores)
    {
        string corTimerHex = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_TIMER];
        string corDigitosHex = dicionarioDeCores[ConstantesCoresMaquina.DIGITOS_TIMERS];

        placaTimer.color = Utils.getCorByHex(corTimerHex);

        Color corDigito = Utils.getCorByHex(corDigitosHex);
        displayTimerDigito[0].configuraradoPeloLevel(corDigito);
        displayTimerDigito[1].configuraradoPeloLevel(corDigito);
        displayTimerDigito[2].configuraradoPeloLevel(corDigito);
        displayTimerDigito[3].configuraradoPeloLevel(corDigito);
    }

    public void setSegundosUnidade(int unidadeSegundos)
    {
        segundosUnidadeAtual = unidadeSegundos;
        displayTimerDigito[3].mostrarDigito(unidadeSegundos);
    }

    public void setSegundosDezena(int dezenaSegundos)
    {
        segundosDezenaAtual = dezenaSegundos;
        displayTimerDigito[2].mostrarDigito(dezenaSegundos);
    }

    public void setMinutosUnidade(int unidadesMinutos)
    {
        minutosUnidadeAtual = unidadesMinutos;
        displayTimerDigito[1].mostrarDigito(unidadesMinutos);
    }

    public void setMinutosDezena(int dezenaMinutos)
    {
        minutosDezenaAtual = dezenaMinutos;
        displayTimerDigito[0].mostrarDigito(dezenaMinutos);
    }
}
