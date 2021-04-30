using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoSoltar : MovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoAberturaEsquerda;
    private Quaternion anguloDesejadoAberturaDireita;

    private GarraInteracaoComPowerUp garraInteracaoPowerUp;

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
            estadoAtual = ESTADO_ESPERANDO;
        }
    }

    private void acaoSoltarPowerUp()
    {
        pararGarra();
        garraInteracaoPowerUp.parar();
        garraInteracaoPowerUp.ligarGravidade();
        garraInteracaoPowerUp.fixarVerticalmente();        
    }

    //TODO EM DUPLICIDADE COM MOVIMENTACAOSEGURANDOEMCIMA
    public void receberInteracaoComPowerUp(GarraInteracaoComPowerUp garraInteracaoPowerUp)
    {
        this.garraInteracaoPowerUp = garraInteracaoPowerUp;
    }
}
