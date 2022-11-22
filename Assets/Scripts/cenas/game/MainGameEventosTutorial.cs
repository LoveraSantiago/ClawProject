using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameEventosTutorial : MainGameEventos
{
    private Tutorial tutorial;

    public MainGameEventosTutorial(Tutorial tutorial)
    {
        this.tutorial = tutorial;
    }

    protected override AcaoColetadoFim configurarAcaoColetadoFim(MainGameManagers mainGameManagers)
    {
        AcaoColetadoFim acaoColetadoFim = base.configurarAcaoColetadoFim(mainGameManagers);
        acaoColetadoFim.adicionarConsumidor(tutorial);
        return acaoColetadoFim;
    }
}
