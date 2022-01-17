using UnityEngine;

public class ReferenciasDoBoardAssemblerNegativo : ReferenciasDoBoardAssembler
{
    public ReferenciasDoBoardAssemblerNegativo() :
       base("BoardAssembler-Negativo")
    { }

    protected override void iteracaoColuna(int contadorColuna, int indiceColuna)
    {
    }

    protected override void iteracaoLinha(int contadorLinha, GameObject goBoardAssembler)
    {
    }

    protected override void posIteracaoColuna(int contadorLinha)
    {
    }

    protected override void preIteracaoColuna()
    {
    }

    protected override void preIteracaoLinha()
    {
    }
}
