using UnityEngine;

public class MovimentacaoSoltar : MovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoAberturaEsquerda;
    private Quaternion anguloDesejadoAberturaDireita;    

    public MovimentacaoSoltar()
    {
        anguloDesejadoAberturaDireita = Quaternion.Euler(0, 0, -contexto.garraDto.Angulos.Abertura);
        anguloDesejadoAberturaEsquerda = Quaternion.Euler(0, 0, contexto.garraDto.Angulos.Abertura);
    }

    public override void preInicio()
    {
        acaoSoltarPowerUp();   
    }

    public override void fixedUpdate()
    {
        parar();
        rotacionarPincaFDT(contexto.garraDto.Velocidades.MovAnguloAbertura, anguloDesejadoAberturaEsquerda, anguloDesejadoAberturaDireita);
        if (isPincaDireitaNoAngulo(anguloDesejadoAberturaDireita))
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
