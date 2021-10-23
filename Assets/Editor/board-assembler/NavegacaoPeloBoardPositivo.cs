using UnityEngine.UIElements;

public class NavegacaoPeloBoardPositivo : NavegacaoPeloBoard
{
    public NavegacaoPeloBoardPositivo(VisualElement root, ReferenciasDoBoardAssemblerPositivo referencias)
        : base(root, referencias){}

    protected override string getNomeBtnIrParaBaixo()
    {
        return "botaoBaixo";
    }

    protected override string getNomeBtnIrParaCima()
    {
        return "botaoCima";
    }
}
