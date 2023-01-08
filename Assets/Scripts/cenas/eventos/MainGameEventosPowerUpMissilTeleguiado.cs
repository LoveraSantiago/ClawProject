using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameEventosPowerUpMissilTeleguiado : AbstractMainGameEventosTutorial
{
    private TutorialPowerUpMissilTeleguiado tutorial;
    public MainGameEventosPowerUpMissilTeleguiado(AllGameManagers allGameManagers, TutorialPowerUpMissilTeleguiado tutorial)
       : base(allGameManagers)
    {
        this.tutorial = tutorial;
    }

    public override void iniciar()
    {
        tutorial.iniciar();
    }

    protected override AcaoPowerUpAcionado configurarAcaoPowerUpAcionado()
    {
        AcaoPowerUpAcionado acaoPowerUpAcionado = base.configurarAcaoPowerUpAcionado();
        acaoPowerUpAcionado.adicionarConsumidor(tutorial);
        return acaoPowerUpAcionado;
    }

    protected override AcaoColetado configurarAcaoColetado()
    {
        AcaoColetado acaoColetado = base.configurarAcaoColetado();

        AcaoColetado acaoColetadoTutorial = new AcaoColetado();
        acaoColetadoTutorial.configurarProdutor(tutorial)
            .adicionarConsumidor(allGameManagers.getModalResultadosManager());

        return acaoColetado;
    }
}
