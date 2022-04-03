using System.Collections.Generic;
using UnityEngine;

public class DisplayTimerDigitos 
{
    public int segundosUnidadeAtual{ get; private set; }
    public int segundosDezenaAtual { get; private set; }
    public int minutosUnidadeAtual { get; private set; }
    public int minutosDezenaAtual  { get; private set; }

    private SpriteRenderer placaTimer;

    private DisplayTimerDigito2Pontos displayTimer2Pontos;
    public DisplayTimerDigito[] displayTimerDigito { get; private set; }

    public DisplayTimerDigitos(DisplayTimerDto displayDto)
    {
        placaTimer = displayDto.SprRendererPlaca;

        displayTimer2Pontos = new DisplayTimerDigito2Pontos(displayDto.SingleDisplay[4]);

        DisplayTimerDigito.configurar(displayDto);
        displayTimerDigito = new DisplayTimerDigito[4];
        displayTimerDigito[0] = new DisplayTimerDigito(displayDto.SingleDisplay[0]);
        displayTimerDigito[1] = new DisplayTimerDigito(displayDto.SingleDisplay[1]);
        displayTimerDigito[2] = new DisplayTimerDigito(displayDto.SingleDisplay[2]);
        displayTimerDigito[3] = new DisplayTimerDigito(displayDto.SingleDisplay[3]);
    }

    public void passarCoresAosDisplayDigitos(Dictionary<string, string> dicionarioDeCores)
    {
        ColoridorTimerV2 coloridor = new ColoridorTimerV2(placaTimer, displayTimerDigito);
        coloridor.colorir(dicionarioDeCores);
    }

    public void blinkar(bool estadoBlink)
    {
        displayTimerDigito[3].estadoBlink(estadoBlink);
        displayTimerDigito[2].estadoBlink(estadoBlink);
        displayTimerDigito[1].estadoBlink(estadoBlink);
        displayTimerDigito[0].estadoBlink(estadoBlink);

        displayTimer2Pontos.estadoBlink(estadoBlink);
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
