using UnityEngine;

public class ComponentePincasDeMovimentacaoGarra : ComponenteAnimacaoDeMovimentacaoGarra
{
    protected void acionarColliderDasPincas()
    {
        getGarra().pincas.acionarCollider();
    }

    protected void acionarTriggerDasPincas()
    {
        getGarra().pincas.acionarTrigger();
    }

    protected bool isPincaDireitaNoAngulo(Quaternion anguloDesejado)
    {
        return getGarra().pincas.isDireitaNoAngulo(anguloDesejado);
    }

    protected bool isPincaDireitaNoAnguloDeFechamento()
    {
        return isPincaDireitaNoAngulo(getAngulosProps().angFechamentoDireita);
    }

    protected void rotacionarPincaVelocidadeAberturaFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        float velocMovAngAbertura = getGarra().getVelocidadeMovAnguloAbertura();
        rotacionarPincaFDT(velocMovAngAbertura, angEsquerda, angDireita);
    }

    protected void rotacionarPincaVelocidadeFechamentoFDT()
    {
        rotacionarPincaVelocidadeFechamentoFDT(getAngulosProps().angFechamentoEsquerda, getAngulosProps().angFechamentoDireita);
    }

    protected void rotacionarPincaVelocidadeFechamentoFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        float velocidadeMovAngFechamento = getGarra().getVelocidadeMovAnguloFechamento();
        rotacionarPincaFDT(velocidadeMovAngFechamento, angEsquerda, angDireita);
    }

    protected void rotacionarPincaVelocidadeIdleFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        float velocidadeMovAngIdle = getGarra().getVelocidadeMovAnguloIdle();
        rotacionarPincaFDT(velocidadeMovAngIdle, angEsquerda, angDireita);
    }

    protected void rotacionarPincaFDT(float velocidade, Quaternion angEsquerda, Quaternion angDireita)
    {
        getGarra().pincas.rotacionarFDT(velocidade, angEsquerda, angDireita);
    }
}
