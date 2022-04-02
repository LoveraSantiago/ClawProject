using UnityEngine;

public class VigasColoriveis : Fornecedor<ComponenteColorivel>
{
    private FinderComponente finder;

    public VigasColoriveis(FinderComponente finder)
    {
        this.finder = finder;
    }

    public ComponenteColorivel fornecer()
    {
        GameObject goVigas = finder.findNaMaquina("vigas");
        GameObject vigaDireita  = finder.findNoComponente(goVigas, ConstantesCoresMaquinaV2.VIGAS + "-direita");
        GameObject vigaEsquerda = finder.findNoComponente(goVigas, ConstantesCoresMaquinaV2.VIGAS + "-esquerda");

        return new MultipleCompColorivel(new GameObject[] { vigaDireita, vigaEsquerda });
    }    
}
