using UnityEngine;

public class ColorivelSimbolo 
{
    private FinderComponente finder;
    private GameObject[] gosCirculoExternos;
    private GameObject[] gosCirculoInternos;

    public ColorivelSimbolo(FinderComponente finder)
    {
        this.finder = finder;
        inicializarArrays();
    }

    public ComponenteColorivel getSimbolosExternos()
    {
        return new MultipleCompColorivel(gosCirculoExternos);
    }

    public ComponenteColorivel getSimbolosInternos()
    {
        return new MultipleCompColorivel(gosCirculoInternos);
    }

    private void inicializarArrays()
    {
        GameObject goSimboloSupEsquerdo = finder.findNaMaquina("simbolo-superior-esquerdo");        
        GameObject circuloInterno1 = finder.findNoComponente(goSimboloSupEsquerdo, ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO);

        GameObject goSimboloSupMaior = finder.findNaMaquina("simbolo-superior-maior");        
        GameObject circuloInterno2 = finder.findNoComponente(goSimboloSupMaior, ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO);

        GameObject goSimboloSupDireito = finder.findNaMaquina("simbolo-superior-direito");        
        GameObject circuloInterno3 = finder.findNoComponente(goSimboloSupDireito, ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO);

        GameObject goTubo = finder.findNaMaquina("tubo");
        GameObject goSimboloTubo = finder.findNoComponente(goTubo, "simbolo-menor");        
        GameObject circuloInterno4 = finder.findNoComponente(goSimboloTubo, ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO);

        GameObject goMesa = finder.findNaMaquina("mesa-joystick");
        GameObject goMesaBaixo = finder.findNoComponente(goMesa, ConstantesCoresMaquinaV2.JOYSTICK_MESA_BAIXO);
        GameObject goSimboloMesa = finder.findNoComponente(goMesaBaixo, "simbolo-menor");        
        GameObject circuloInterno5 = finder.findNoComponente(goSimboloMesa, ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO);

        GameObject goSimbInfEsquerdo = finder.findNaMaquina("simbolo-inferior-esquerdo");        
        GameObject circuloInterno6 = finder.findNoComponente(goSimbInfEsquerdo, ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO);

        GameObject goSimbInfDireito  = finder.findNaMaquina("simbolo-inferior-direito");        
        GameObject circuloInterno7 = finder.findNoComponente(goSimbInfDireito, ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO);

        gosCirculoExternos = new GameObject[] {
            goSimboloSupEsquerdo, goSimboloSupMaior, goSimboloSupDireito, goSimboloTubo, goSimboloMesa, goSimbInfEsquerdo, goSimbInfDireito
        };

        gosCirculoInternos = new GameObject[] {
            circuloInterno1, circuloInterno2, circuloInterno3, circuloInterno4, circuloInterno5, circuloInterno6, circuloInterno7
        };
    }
}
