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

    public override void fixedUpdate()
    {
        incremento = Time.deltaTime * compDaGarra.VelocidadeFechamentoGarra;

        //Fechando a garra Esquerda
        compDaGarra.PincaEsquerda.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaEsquerda.rotation, anguloDesejadoEsquerda, incremento);        

        //Fechando a garra Direita
        compDaGarra.PincaDireita.rotation = Quaternion.RotateTowards(
            compDaGarra.PincaDireita.rotation, anguloDesejadoDireita, incremento);

        
        if (isGarraFechadaNoAngulo())
        {   
            communicatorComGarra.trocarParaAcaoSubindo();
        }        
    }

    private bool isGarraFechadaNoAngulo()
    {
        return Mathf.Round(compDaGarra.PincaDireita.rotation.eulerAngles.z) == compDaGarra.AnguloFechamentoGarra;
    }
}
