using UnityEngine;

public class ColorivelDisplayColetavel 
{
    private FinderComponente finder;
    private GameObject goDisplayColetado;

    public ColorivelDisplayColetavel(FinderComponente finder)
    {
        this.finder = finder;
        goDisplayColetado = finder.findNaMaquina("display-coletados");
    }

    public ComponenteColorivel getPlacaPrincipal()
    {
        GameObject goPlacaGrupo = finder.findNoComponente(goDisplayColetado, ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_GRUPO);
        return new SingleCompColorivel(goPlacaGrupo);
    }

    public ComponenteColorivel getPlacaIndividual1()
    {
        GameObject goPlacaGrupo = finder.findNoComponente(goDisplayColetado, ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL1);
        return new SingleCompColorivel(goPlacaGrupo);
    }

    public ComponenteColorivel getPlacaIndividual2()
    {
        GameObject goPlacaGrupo = finder.findNoComponente(goDisplayColetado, ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL2);
        return new SingleCompColorivel(goPlacaGrupo);
    }

    public ComponenteColorivel getPlacaIndividual3()
    {
        GameObject goPlacaGrupo = finder.findNoComponente(goDisplayColetado, ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL3);
        return new SingleCompColorivel(goPlacaGrupo);
    }
}
