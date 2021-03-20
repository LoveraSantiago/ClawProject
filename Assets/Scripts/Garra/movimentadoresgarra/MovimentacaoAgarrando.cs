using UnityEngine;

public class MovimentacaoAgarrando : MovimentacaoDaGarra
{   
    private float incremento;    
    
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    public MovimentacaoAgarrando()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0,   compDaGarra.AnguloFechamentoGarra);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -compDaGarra.AnguloFechamentoGarra);        
    }

    Vector2 posOriginal;
    public override void preInicio()
    {
        compDaGarra.RigidBody.velocity = Vector3.zero;
        compDaGarra.RigidBody.angularVelocity = 0;

        compDaGarra.RigidBody.mass = compDaGarra.RigidBody.mass * 3;
    }

    public override void fixedUpdate()
    {
        compDaGarra.RigidBody.velocity = Vector3.zero;
        compDaGarra.RigidBody.angularVelocity = 0;
        incremento = Time.deltaTime * compDaGarra.VelocidadeFechamentoGarra;

        //Fechando a garra Esquerda
        compDaGarra.PincaEsquerda.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);        

        //Fechando a garra Direita
        compDaGarra.PincaDireita.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaDireita.rotation, anguloDesejadoDireita, incremento);

        
        if (isGarraFechadaNoAngulo())
        {
            Debug.Log("Subindo");
            compDaGarra.RigidBody.mass = compDaGarra.RigidBody.mass / 3;
            communicatorComGarra.trocarParaAcaoSubindo();
        }        
    }

    private bool isGarraFechadaNoAngulo()
    {
        return Mathf.Round(compDaGarra.PincaDireita.rotation.eulerAngles.z) == compDaGarra.AnguloFechamentoGarra;
    }
}
