using UnityEngine;

public class MovimentacaoAgarrando : MovimentacaoDaGarra
{
    //private readonly float INCREMENTO_DE_MASSA = 2;    
    
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    //float massaOriginal;

    public MovimentacaoAgarrando()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0,   compDaGarra.AnguloFechamento);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -compDaGarra.AnguloFechamento);        
    }
    
    public override void preInicio()
    {        
        diminuirInerciaDaGarra();
        //massaOriginal = compDaGarra.RigidBody.mass;
        compDaGarra.RigidBody.mass = 1;
    }

    public override void fixedUpdate()
    {        
        diminuirInerciaDaGarra();

        pincas.fixUpdateRotacionamento(compDaGarra.VelocidadeAnguloFechamento, anguloDesejadoEsquerda, anguloDesejadoDireita);
        
        //if (pincas.isDireitaNoAngulo(compDaGarra.AnguloFechamento))
        if (pincas.isDireitaNoAngulo(anguloDesejadoDireita))
        {
            //compDaGarra.RigidBody.mass = 1;
            //compDaGarra.RigidBody.mass = massaOriginal;
            comunicadorComGerMovimentacao.trocarParaAcaoSubindo();
        }        
    }    
}
