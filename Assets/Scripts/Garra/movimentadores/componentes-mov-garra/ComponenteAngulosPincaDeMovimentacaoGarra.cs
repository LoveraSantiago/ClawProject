using UnityEngine;

public class ComponenteAngulosPincaDeMovimentacaoGarra : ComponentePincasDeMovimentacaoGarra
{
    protected Quaternion getAnguloIdleMaxDireita()
    {
        return getAngulosProps().angIdleMaxDireita;
    }

    protected Quaternion getAnguloIdleMaxEsquerda()
    {
        return getAngulosProps().angIdleMaxEsquerda;
    }

    protected Quaternion getAnguloIdleMinDireita()
    {
        return getAngulosProps().angIdleMinDireita;
    }

    protected Quaternion getAnguloIdleMinEsquerda()
    {
        return getAngulosProps().angIdleMinEsquerda;
    }

    protected Quaternion getAnguloAberturaEsquerda()
    {
        return getAngulosProps().angAberturaEsquerda;
    }

    protected Quaternion getAnguloAberturaDireita()
    {
        return getAngulosProps().angAberturaDireita;
    }
}
