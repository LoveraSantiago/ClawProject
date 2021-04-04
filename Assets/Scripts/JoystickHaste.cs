using UnityEngine;

public class JoystickHaste : ConsumidorDeEvento<Direcao>
{
    private int ANGULO = 25;
    private float velocidade = 0.25f;
    private Transform hasteJoystick;
    private float incremento;

    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;
    private Quaternion anguloDesejadoAtual;


    public JoystickHaste(Transform hasteJoystick)
    {
        this.hasteJoystick = hasteJoystick;

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
