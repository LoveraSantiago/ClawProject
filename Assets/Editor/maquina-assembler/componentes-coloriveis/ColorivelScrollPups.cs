using UnityEngine;

public class ColorivelScrollPups 
{
    private FinderComponente finder;
    private GameObject goScrollPups;

    public ColorivelScrollPups(FinderComponente finder)
    {
        this.finder = finder;
        goScrollPups = finder.findNaMaquina("scrollpups");
    }

    public ComponenteColorivel getPlacaExterna()
    {
        GameObject goPlacaExterna = finder.findNoComponente(goScrollPups, ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA);
        return new SingleCompColorivel(goPlacaExterna);
    }

    public ComponenteColorivel getPlacaInterna()
    {
        GameObject goPlacaInterna = finder.findNoComponente(goScrollPups, ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA);
        return new SingleCompColorivel(goPlacaInterna);
    }

    public ComponenteColorivel getSetasLaterais()
    {
        GameObject goSetaEsquerda = finder.findNoComponente(goScrollPups, "seta-esquerda");
        GameObject goSetaDireita  = finder.findNoComponente(goScrollPups, "seta-direita");
        return new MultipleCompColorivel(new GameObject[] {
            goSetaEsquerda, goSetaDireita
        });
    }

    public ComponenteColorivel getSetaSuperior()
    {
        GameObject goSetaCima = finder.findNoComponente(goScrollPups, ConstantesCoresMaquinaV2.SCROLL_PUP_SETA_CIMA);
        return new SingleCompColorivel(goSetaCima);
    }
}
