using UnityEngine;

public class JoystickHaste : ConsumidorDeEvento<DirecaoDaGarra>
{
    private readonly int ANGULO = 25;

    private float velocidade;
    private float incremento;
    private int multiplicador;

    private Transform hasteJoystick;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;
    private Quaternion anguloDesejadoAtual;

    //UTILIZANDO MESMA VELOCIDADE DE MOVIMENTACAO HORIZONTAL DA GARRA
    /* A VELOCIDADE VAI PEGAR O VALOR INICIAL DE VELOCIDADE SE MUDADO 
       DURANTE GAMEPLAY NAO REFLETE AQUI SO NO PROXIMO START*/
    public JoystickHaste(Transform hasteJoystick, float velocidade)
    {
        this.hasteJoystick = hasteJoystick;
        this.velocidade = velocidade * .005f;//AJUSTANDO PARA PROPORCAO TAMANHO JOYSTICK

        anguloDesejadoDireita = Quaternion.Euler(0, 0, -ANGULO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, ANGULO);
        anguloDesejadoAtual = Quaternion.Euler(0, 0, 0);
    }

    public void fixedUpdate()
    {
        incremento = (Time.fixedDeltaTime + velocidade) * multiplicador;
        hasteJoystick.rotation = Quaternion.RotateTowards(hasteJoystick.rotation, anguloDesejadoAtual, incremento);
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
        else
        {
            multiplicador = 0;
        }
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<Direcao> FIM
}
