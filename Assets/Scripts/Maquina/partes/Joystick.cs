using UnityEngine;
using System.Collections.Generic;

public class Joystick : AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento
{
    private readonly int ANGULO = 20;
    
    private float incremento;
    private int multiplicador;
        
    private JoystickDto joystickDto;
    private MesaJoystickDto mesaJoystickDto;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;
    private Quaternion anguloDesejadoAtual;
    private Quaternion anguloInicial;

    //UTILIZANDO MESMA VELOCIDADE DE MOVIMENTACAO HORIZONTAL DA GARRA
    /* A VELOCIDADE VAI PEGAR O VALOR INICIAL DE VELOCIDADE SE MUDADO 
       DURANTE GAMEPLAY NAO REFLETE AQUI SO NO PROXIMO START*/
    public Joystick(JoystickDto joystickDto, MesaJoystickDto mesaJoystickDto)
    {
        this.joystickDto = joystickDto;
        this.mesaJoystickDto = mesaJoystickDto;

        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -ANGULO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, ANGULO);
        anguloDesejadoAtual    = Quaternion.Euler(0, 0, 0);
        anguloInicial          = this.joystickDto.JoystickTransform.rotation;
    }

    public void fixedUpdate()
    {
        incremento = (Time.fixedDeltaTime + mesaJoystickDto.Velocidade) * multiplicador;
        joystickDto.JoystickTransform.rotation = Quaternion.RotateTowards(joystickDto.JoystickTransform.rotation, anguloDesejadoAtual, incremento);
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioCores)
    {
        ColoridorJoystickV2 coloridorJoystick = new ColoridorJoystickV2();
        coloridorJoystick.colorir(mesaJoystickDto, dicionarioCores);        
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<Direcao> INICIO
    //CONSOME EVENTO DE DIRECAO DISPARADO PELA GARRA PARA TER SINCRONIA NA DIRECAO DA GARRA
    void AcaoSincroniaComDirecaoDaGarra.ConsumidorEvento.consumirEvento(DirecaoDaGarra evento)
    {
        if(evento == DirecaoDaGarra.DIREITA)
        {
            anguloDesejadoAtual = anguloDesejadoDireita;
            multiplicador = 1;
        }
        else if(evento == DirecaoDaGarra.ESQUERDA)
        {
            anguloDesejadoAtual = anguloDesejadoEsquerda;
            multiplicador = 1;
        }
        else if(evento == DirecaoDaGarra.CENTRALIZADA)
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
