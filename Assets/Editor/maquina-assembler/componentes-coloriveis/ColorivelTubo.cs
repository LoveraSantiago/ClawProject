using UnityEngine;

public class ColorivelTubo
{
    private FinderComponente finder;
    private GameObject goTubo;

    public ColorivelTubo(FinderComponente finder)
    {
        this.finder = finder;
        goTubo = finder.findNaMaquina("tubo");
    }

    public ComponenteColorivel getBase()
    {
        GameObject goBase = finder.findNoComponente(goTubo, ConstantesCoresMaquinaV2.TUBO_BASE);
        return new SingleCompColorivel(goBase, 0.88f);
    }

    public ComponenteColorivel getBorda()
    {
        GameObject goBorda = finder.findNoComponente(goTubo, ConstantesCoresMaquinaV2.TUBO_BORDA);
        return new SingleCompColorivel(goBorda);
    }
}
