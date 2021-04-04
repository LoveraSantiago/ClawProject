using UnityEngine;

public class JoystickHaste : ConsumidorDeEvento<Direcao>
{
    private int ANGULO = 25;
    private float velocidade;

    private Transform hasteJoystick;
    private float incremento;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;
    private Quaternion anguloDesejadoAtual;

    //UTILIZANDO MESMA VELOCIDADE DE MOVIMENTACAO HORIZONTAL DA GARRA
    /* A VELOCIDADE VAI PEGAR O VALOR INICIAL DE VELOCIDADE SE MUDADO 
       DURANTE GAMEPLAY NAO REFLETE AQUI SO NO PROXIMO START*/
    public JoystickHaste(Transform hasteJoystick, float velocidade)
    {
        this.hasteJoystick = hasteJoystick;
        this.velocidade = velocidade * .005f;

        anguloDesejadoDireita = Quaternion.Euler(0, 0, -ANGULO);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, ANGULO);
        anguloDesejadoAtual = Quaternion.Euler(0, 0, 0);
    }

    public void fixedUpdate()
    {
        incremento = Time.fixedDeltaTime + velocidade;
        hasteJoystick.rotation = Quaternion.RotateTowards(hasteJoystick.rotation, anguloDesejadoAtual, incremento);
    }

    public ConsumidorDeEvento<Direcao> getConsumidorDeEventoDeDirecao()
    {
        return this;
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<Direcao> INICIO
    //CONSOME EVENTO DE DIRECAO DISPARADO PELA GARRA PARA TER SINCRONIA NA DIRECAO DA GARRA
    public void consumirEvento(Direcao direcao)
    {
        if(direcao == Direcao.DIREITA)
        {
            anguloDesejadoAtual = anguloDesejadoDireita;
        }
        else
        {
            anguloDesejadoAtual = anguloDesejadoEsquerda;
        }
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<Direcao> FIM
}
