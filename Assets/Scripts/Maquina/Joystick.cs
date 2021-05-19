using UnityEngine;
using System.Collections.Generic;

public class Joystick : ConsumidorDeEvento<DirecaoDaGarra>
{
    private readonly int ANGULO = 20;

    private float velocidade;
    private float incremento;
    private int multiplicador;
        
    private JoystickDto joystickDto;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;
    private Quaternion anguloDesejadoAtual;
    private Quaternion anguloInicial;

    //UTILIZANDO MESMA VELOCIDADE DE MOVIMENTACAO HORIZONTAL DA GARRA
    /* A VELOCIDADE VAI PEGAR O VALOR INICIAL DE VELOCIDADE SE MUDADO 
       DURANTE GAMEPLAY NAO REFLETE AQUI SO NO PROXIMO START*/
    public Joystick(JoystickDto joystickDto, float velocidade)
    {
        this.joystickDto = joystickDto;
        this.velocidade = velocidade * .3f;//AJUSTANDO PARA PROPORCAO TAMANHO JOYSTICK

        anguloDesejadoDireita = Quaternion.Euler(0, 0, -ANGULO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, ANGULO);
        anguloDesejadoAtual = Quaternion.Euler(0, 0, 0);
        anguloInicial = this.joystickDto.JoystickTransform.rotation;
    }

    public void fixedUpdate()
    {
        incremento = (Time.fixedDeltaTime + velocidade) * multiplicador;
        joystickDto.JoystickTransform.rotation = Quaternion.RotateTowards(joystickDto.JoystickTransform.rotation, anguloDesejadoAtual, incremento);
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioCores)
    {
        string hexCor = dicionarioCores[ConstantesCoresMaquina.PARTE_CIMA];
        joystickDto.ParteCima.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.PARTE_BAIXO];
        joystickDto.ParteBaixo.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.FURO_HASTE];
        joystickDto.FuroHaste.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.HASTE];
        joystickDto.Haste.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.JOYSTICK_BOLA];
        joystickDto.Bola.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.FURO_BOTAO];
        joystickDto.FuroBotao.color = Utils.getCorByHex(hexCor);

        hexCor = dicionarioCores[ConstantesCoresMaquina.BOTAO];
        joystickDto.JoystickBotao.color = Utils.getCorByHex(hexCor);
    }

    public ConsumidorDeEvento<DirecaoDaGarra> getConsumidorDeEventoDeDirecao()
    {
        return this;
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<Direcao> INICIO
    //CONSOME EVENTO DE DIRECAO DISPARADO PELA GARRA PARA TER SINCRONIA NA DIRECAO DA GARRA
    public void consumirEvento(DirecaoDaGarra direcao)
    {
        if(direcao == DirecaoDaGarra.DIREITA)
        {
            anguloDesejadoAtual = anguloDesejadoDireita;
            multiplicador = 1;
        }
        else if(direcao == DirecaoDaGarra.ESQUERDA)
        {
            anguloDesejadoAtual = anguloDesejadoEsquerda;
            multiplicador = 1;
        }
        else if(direcao == DirecaoDaGarra.CENTRALIZADA)
        {
            //Debug.Log("Direcao CENTRO");
            anguloDesejadoAtual = Quaternion.Euler(0, 0, 0); ;
            multiplicador = 1;
        }
        else
        {
            multiplicador = 0;
        }
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<Direcao> FIM
}
