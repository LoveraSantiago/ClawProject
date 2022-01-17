using UnityEngine.UIElements;
using UnityEngine.UI;

public class NavegacaoPeloBoardPositivo : NavegacaoPeloBoard
{
    public NavegacaoPeloBoardPositivo(VisualElement root, ReferenciasDoBoardPositivo referencias)
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
        return isImpar(value);
    }

    public Text getTextDaMira()
    {
        return ((ReferenciasDoBoardPositivo)referencias).dicionarioTextLabels[linhaAtual][colunaAtual];
    }
}
