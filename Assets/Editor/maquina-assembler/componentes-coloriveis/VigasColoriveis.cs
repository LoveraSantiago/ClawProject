using UnityEngine;

public class VigasColoriveis 
{
    private FinderComponente finder;

    public VigasColoriveis(FinderComponente finder)
    {
        this.finder = finder;
    }

    public ComponenteColorivel getVigas()
    {
        GameObject goVigas = finder.findNaMaquina("vigas");
        GameObject vigaDireita  = finder.findNoComponente(goVigas, ConstantesCoresMaquinaV2.VIGAS + "-direita");
        GameObject vigaEsquerda = finder.findNoComponente(goVigas, ConstantesCoresMaquinaV2.VIGAS + "-esquerda");

        return new MultipleCompColorivel(new GameObject[] { vigaDireita, vigaEsquerda });
    }    
}
