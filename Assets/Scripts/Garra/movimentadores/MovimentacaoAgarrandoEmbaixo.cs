using UnityEngine;

public class MovimentacaoAgarrandoEmbaixo : MovimentacaoDaGarraNormal
{
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    public MovimentacaoAgarrandoEmbaixo()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0,   garraDto.AnguloFechamento);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -garraDto.AnguloFechamento);        
    }
    
    public override void preInicio()
    {   
        colocarMassaNaGarra(1);        
    }

    public override void fixedUpdate()
    {
        pararGarra();
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloFechamento, anguloDesejadoEsquerda, anguloDesejadoDireita);
        
        if (pincas.isDireitaNoAngulo(anguloDesejadoDireita))
        {       
            comunicadorComGerMovimentacao.trocarParaAcaoSubindo();
        }        
    }    
}
