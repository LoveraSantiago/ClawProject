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
        GameObject vigas = finder.findNaMaquina("vigas");
        GameObject vigaDireita  = finder.findNoComponente(vigas, ConstantesCoresMaquinaV2.VIGAS + "-direita");
        GameObject vigaEsquerda = finder.findNoComponente(vigas, ConstantesCoresMaquinaV2.VIGAS + "-esquerda");

        return new MultipleCompColorivel(new GameObject[] { vigaDireita, vigaEsquerda });
    }    
}
