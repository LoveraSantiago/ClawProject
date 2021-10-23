using UnityEngine.UIElements;

public class NavegacaoPeloBoardNegativo : NavegacaoPeloBoard
{
    public NavegacaoPeloBoardNegativo(VisualElement root, ReferenciasDoBoardAssembler referencias) 
        : base(root, referencias){}

    protected override string getNomeBtnIrParaBaixo()
    {
        return "botaoCima";
    }

    protected override string getNomeBtnIrParaCima()
    {
        return "botaoBaixo";
    }

    protected override bool isLinhaMenor(int value)
    {
        return isPar(value);
    }
}
