using UnityEngine;

public class MovimentacaoAgarrando : MovimentacaoDaGarra
{
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
        compDaGarra.RigidBody.mass = 1;
    }

    public override void fixedUpdate()
    {        
        diminuirInerciaDaGarra();

        pincas.fixUpdateRotacionamento(compDaGarra.VelocidadeAnguloFechamento, anguloDesejadoEsquerda, anguloDesejadoDireita);
        
        if (pincas.isDireitaNoAngulo(anguloDesejadoDireita))
        {       
            comunicadorComGerMovimentacao.trocarParaAcaoSubindo();
        }        
    }    
}
