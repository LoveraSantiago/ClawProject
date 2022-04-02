using UnityEngine;

public class TimerColorivel 
{
    private FinderComponente finder;

    public TimerColorivel(FinderComponente finder)
    {
        this.finder = finder;
    }

    public ComponenteColorivel getPlacaPrincipal()
    {
        GameObject goTimer = finder.findNaMaquina("timer");
        GameObject placaPrincipal = finder.findNoComponente(goTimer, ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL);
        return new SingleCompColorivel(placaPrincipal);
    }
}
