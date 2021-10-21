using UnityEngine;

public class MovimentacaoSoltar : MovimentacaoDaGarraPowerUp
{   
    public override void preInicio()
    {
        acaoSoltarPowerUp();   
    }

    public override void fixedUpdate()
    {
        parar();

        Quaternion angAberturaDireita  = getAnguloAberturaDireita();
        Quaternion angAberturaEsquerda = getAnguloAberturaEsquerda();        
        rotacionarPincaVelocidadeAberturaFDT(angAberturaEsquerda, angAberturaDireita);
        if (isPincaDireitaNoAngulo(angAberturaDireita))
        {
            comunicadorComGerMovimentacao.trocarParaAcaoParado();
        }
    }

    private void acaoSoltarPowerUp()
    {
        parar();
        garraInteracaoComPowerUp.parar();
        garraInteracaoComPowerUp.ligarGravidadeHum();
        garraInteracaoComPowerUp.fixarEixoX();        
    } 
}
