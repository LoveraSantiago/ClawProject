using UnityEngine;

public class MovimentacaoAgarrandoEmbaixo : MovimentacaoDaGarraNormal
{
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    public MovimentacaoAgarrandoEmbaixo()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0,   garraDto.Angulos.Fechamento);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -garraDto.Angulos.Fechamento);        
    }
    
    public override void preInicio()
    {   
        colocarMassa(1);        
    }

    public override void fixedUpdate()
    {
        parar();
        pincas.rotacionarFDT(garraDto.Velocidades.MovAnguloFechamento, anguloDesejadoEsquerda, anguloDesejadoDireita);
        
        if (pincas.isDireitaNoAngulo(anguloDesejadoDireita))
        {       
            comunicadorComGerMovimentacao.trocarParaAcaoSubindo();
        }        
    }    
}
