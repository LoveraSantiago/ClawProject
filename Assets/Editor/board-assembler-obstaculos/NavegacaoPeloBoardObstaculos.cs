using UnityEngine.UIElements;

public class NavegacaoPeloBoardObstaculos : NavegacaoPeloBoard
{
    public NavegacaoPeloBoardObstaculos(VisualElement root, ReferenciasDoBoardAssembler referencias)
        : base(root, referencias){}

    protected override string getNomeBtnIrParaBaixo()
    {
        return "botaoBaixo";
    }

    protected override string getNomeBtnIrParaCima()
    {
        return "botaoCima";
    }

    protected override bool isLinhaMenor(int value)
    {
        return false;
}
}
