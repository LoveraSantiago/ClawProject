using UnityEngine;

public class MovimentacaoPincaZigZag : AbstractMovimentacaoDaGarraNormal
{
    private bool isUsandoMaxAngulo;

    private Quaternion anguloDesejadoEsquerdaAtual;
    private Quaternion anguloDesejadoDireitaAtual;

    public override void preInicio()
    {
        configurarAngulosParaMax();
    }

    public override void fixedUpdate()
    {
        verificarSePincaAtingiuLimites();
        rotacionarPincaVelocidadeIdleFDT(anguloDesejadoEsquerdaAtual, anguloDesejadoDireitaAtual);
    }

    private void verificarSePincaAtingiuLimites()
    {
        if (isPincaDireitaNoAngulo(anguloDesejadoDireitaAtual))
        {
            if (isUsandoMaxAngulo)
            {
                configurarAngulosParaMin();
            }
            else
            {
                configurarAngulosParaMax();
            }
        }
    }

    private void configurarAngulosParaMax()
    {
        isUsandoMaxAngulo = true;
        anguloDesejadoDireitaAtual = getAnguloIdleMaxDireita();
        anguloDesejadoEsquerdaAtual = getAnguloIdleMaxEsquerda();
    }

    private void configurarAngulosParaMin()
    {
        isUsandoMaxAngulo = false;
        anguloDesejadoDireitaAtual = getAnguloIdleMinDireita();
        anguloDesejadoEsquerdaAtual = getAnguloIdleMinEsquerda();
    }
}
