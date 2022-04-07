using System.Collections.Generic;
using UnityEngine;

public class DisplayTimerDigitos 
{
    public int segundosUnidadeAtual{ get; private set; }
    public int segundosDezenaAtual { get; private set; }
    public int minutosUnidadeAtual { get; private set; }
    public int minutosDezenaAtual  { get; private set; }
    
    public DisplayTimerDigito[] displayTimerDigito { get; private set; }

    public DisplayTimerDigitos(DisplayTimerDto displayDto)
    {
        DisplayTimerDigito.configurar(displayDto);
        displayTimerDigito = new DisplayTimerDigito[5];
        displayTimerDigito[0] = new DisplayTimerDigito(displayDto.SingleDisplay[0]);
        displayTimerDigito[1] = new DisplayTimerDigito(displayDto.SingleDisplay[1]);
        displayTimerDigito[2] = new DisplayTimerDigito(displayDto.SingleDisplay[2]);
        displayTimerDigito[3] = new DisplayTimerDigito(displayDto.SingleDisplay[3]);
        displayTimerDigito[4] = new DisplayTimerDigito(displayDto.SingleDisplay[4]);
    }

    public void passarCoresAosDisplayDigitos(DisplayTimerDto displayDto, Dictionary<string, string> dicionarioDeCores)
    {
        SpriteRenderer placaTimer = displayDto.SprRendererPlacaGrupo;
        ColoridorTimerV2 coloridor = new ColoridorTimerV2(placaTimer, displayTimerDigito);
        coloridor.colorir(dicionarioDeCores);
    }

    public void blinkar(bool estadoBlink)
    {
        displayTimerDigito[3].estadoBlink(estadoBlink);
        displayTimerDigito[2].estadoBlink(estadoBlink);
        displayTimerDigito[1].estadoBlink(estadoBlink);
        displayTimerDigito[0].estadoBlink(estadoBlink);

        displayTimerDigito[4].estadoBlink(estadoBlink);
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
