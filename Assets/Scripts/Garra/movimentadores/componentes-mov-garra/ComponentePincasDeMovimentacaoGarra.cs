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
        return isPincaDireitaNoAngulo(angulosProps.angFechamentoDireita);
    }

    protected void rotacionarPincaVelocidadeAberturaFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        rotacionarPincaFDT(getGarra().garraDto.Velocidades.MovAnguloAbertura, angEsquerda, angDireita);
    }

    protected void rotacionarPincaVelocidadeFechamentoFDT()
    {
        rotacionarPincaVelocidadeFechamentoFDT(angulosProps.angFechamentoEsquerda, angulosProps.angFechamentoDireita);
    }

    protected void rotacionarPincaVelocidadeFechamentoFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        rotacionarPincaFDT(getGarra().garraDto.Velocidades.MovAnguloFechamento, angEsquerda, angDireita);
    }

    protected void rotacionarPincaVelocidadeIdleFDT(Quaternion angEsquerda, Quaternion angDireita)
    {
        rotacionarPincaFDT(getGarra().garraDto.Velocidades.MovAnguloIdle, angEsquerda, angDireita);
    }

    protected void rotacionarPincaFDT(float velocidade, Quaternion angEsquerda, Quaternion angDireita)
    {
        getGarra().pincas.rotacionarFDT(velocidade, angEsquerda, angDireita);
    }
}
