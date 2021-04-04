using UnityEngine;

public class MovimentacaoAgarrando : MovimentacaoDaGarra
{
    private readonly float INCREMENTO_DE_MASSA = 3;
    
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    public MovimentacaoAgarrando()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0,   compDaGarra.AnguloFechamento);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -compDaGarra.AnguloFechamento);        
    }
    
    public override void preInicio()
    {        
        diminuirInerciaDaGarra();
        compDaGarra.RigidBody.mass = compDaGarra.RigidBody.mass * INCREMENTO_DE_MASSA;
    }

    public override void fixedUpdate()
    {        
        diminuirInerciaDaGarra();

        pincas.fixUpdateRotacionamento(compDaGarra.VelocidadeAnguloFechamento, anguloDesejadoEsquerda, anguloDesejadoDireita);
        
        if (pincas.isNoAngulo(compDaGarra.AnguloFechamento))
        {            
            compDaGarra.RigidBody.mass = compDaGarra.RigidBody.mass / INCREMENTO_DE_MASSA;
            comunicadorComGerMovimentacao.trocarParaAcaoSubindo();
        }        
    }    
}
