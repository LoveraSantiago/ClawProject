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
        return new SingleCompColorivel(goTubo, 0.88f);
    }

    public ComponenteColorivel getBorda()
    {
        GameObject goBorda = finder.findNoComponente(goTubo, ConstantesCoresMaquinaV2.TUBO_BORDA);
        return new SingleCompColorivel(goBorda);
    }
}
