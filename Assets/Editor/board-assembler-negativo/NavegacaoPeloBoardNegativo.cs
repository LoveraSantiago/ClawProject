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
}
