using UnityEngine;

public class MovimentacaoSoltar : MovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoAberturaEsquerda;
    private Quaternion anguloDesejadoAberturaDireita;    

    public MovimentacaoSoltar()
    {
        anguloDesejadoAberturaDireita = Quaternion.Euler(0, 0, -garraDto.AnguloAbertura);
        anguloDesejadoAberturaEsquerda = Quaternion.Euler(0, 0, garraDto.AnguloAbertura);
    }

    public override void preInicio()
    {
        acaoSoltarPowerUp();   
    }

    public override void fixedUpdate()
    {
        pararGarra();
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoAberturaEsquerda, anguloDesejadoAberturaDireita);
        if (pincas.isDireitaNoAngulo(anguloDesejadoAberturaDireita))
        {
            comunicadorComGerMovimentacao.trocarParaAcaoParado();
        }
    }

    private void acaoSoltarPowerUp()
    {
        pararGarra();
        garraInteracaoComPowerUp.parar();
        garraInteracaoComPowerUp.ligarGravidade();
        garraInteracaoComPowerUp.fixarVerticalmente();        
    } 
}
