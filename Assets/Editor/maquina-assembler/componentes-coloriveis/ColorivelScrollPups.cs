using UnityEngine;
using System.Collections.Generic;

public class ColorivelScrollPups 
{
    private FinderComponente finder;
    private GameObject goScrollPups;
    private GameObject goPlacaInterna;

    public ColorivelScrollPups(FinderComponente finder)
    {
        this.finder = finder;
        goScrollPups = finder.findNaMaquina("scrollpups");
        goPlacaInterna = finder.findNoComponente(goScrollPups, ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA);
    }

    public ComponenteColorivel getPlacaExterna()
    {
        GameObject goPlacaExterna = finder.findNoComponente(goScrollPups, ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA);
        return new SingleCompColorivel(goPlacaExterna);
    }

    public ComponenteColorivel getPlacaInterna()
    {
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

    public ComponenteColorivel getDivisorias()
    {
        List<GameObject> listaDivisorias = new List<GameObject>();

        GameObject goBarraRolagem = finder.findNoComponente(goPlacaInterna, "barra-rolagem");
        for(int contador = 0; contador < 6; contador++)
        {
            GameObject goItemRolagem = finder.findNoComponente(goBarraRolagem, "item-rolagem" + (contador + 1));            
            listaDivisorias.Add(goItemRolagem);
        }
        return new MultipleCompColorivel(listaDivisorias.ToArray());
    }

    public ComponenteColorivel getSetaSuperior()
    {
        GameObject goSetaCima = finder.findNoComponente(goScrollPups, ConstantesCoresMaquinaV2.SCROLL_PUP_SETA_CIMA);
        return new SingleCompColorivel(goSetaCima);
    }
}
