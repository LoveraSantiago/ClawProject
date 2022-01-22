using UnityEngine;

public class ReferenciasDoBoardNegativo : ReferenciasDoBoard
{
    public ReferenciasDoBoardNegativo() :
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
