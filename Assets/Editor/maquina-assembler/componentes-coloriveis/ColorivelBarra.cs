using UnityEngine;

public class ColorivelBarra
{
    private FinderComponente finder;

    public ColorivelBarra(FinderComponente finder)
    {
        this.finder = finder;
    }

    public ComponenteColorivel getBarra()
    {
        GameObject goBarra = finder.findNaMaquina(ConstantesCoresMaquinaV2.BARRA);
        GameObject goViga = finder.findNoComponente(goBarra, "viga");
        GameObject goSuporteEsquerda = finder.findNoComponente(goBarra, "suporte-esquerda");
        GameObject goSuporteDireita  = finder.findNoComponente(goBarra, "suporte-direita");

        return new MultipleCompColorivel(new GameObject[] {
            goViga, goSuporteDireita, goSuporteEsquerda
        });
    }
}
