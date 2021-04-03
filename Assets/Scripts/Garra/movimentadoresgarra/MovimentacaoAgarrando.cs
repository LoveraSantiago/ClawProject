using UnityEngine;

public class MovimentacaoAgarrando : MovimentacaoDaGarra
{
    private readonly float INCREMENTO_DE_MASSA = 3;

    private float incremento;    
    
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    public MovimentacaoAgarrando()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0,   compDaGarra.AnguloFechamentoGarra);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -compDaGarra.AnguloFechamentoGarra);        
    }
    
    public override void preInicio()
    {        
        diminuirInerciaDaGarra();
        compDaGarra.RigidBody.mass = compDaGarra.RigidBody.mass * INCREMENTO_DE_MASSA;
    }

    public override void fixedUpdate()
    {        
        diminuirInerciaDaGarra();

        incremento = Time.deltaTime * compDaGarra.VelocidadeFechamentoGarra;

        //FECHANDO A GARRA ESQUERDA
        compDaGarra.PincaEsquerda.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);        

        //FECHANDO A GARRA DIREITA
        compDaGarra.PincaDireita.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaDireita.rotation, anguloDesejadoDireita, incremento);

        
        if (isGarraFechadaNoAngulo())
        {            
            compDaGarra.RigidBody.mass = compDaGarra.RigidBody.mass / INCREMENTO_DE_MASSA;
            comunicadorComGerMovimentacao.trocarParaAcaoSubindo();
        }        
    }

    private bool isGarraFechadaNoAngulo()
    {
        return Mathf.Round(compDaGarra.PincaDireita.rotation.eulerAngles.z) == compDaGarra.AnguloFechamentoGarra;
    }
}
