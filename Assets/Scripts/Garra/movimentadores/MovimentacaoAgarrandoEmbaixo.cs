using UnityEngine;

public class MovimentacaoAgarrandoEmbaixo : MovimentacaoDaGarraNormal
{
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;

    public MovimentacaoAgarrandoEmbaixo()
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0, garra.garraDto.Angulos.Fechamento);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, -garra.garraDto.Angulos.Fechamento);        
    }
    
    public override void preInicio()
    {
        agarrando();
        colocarMassa(1);        
    }

    public override void fixedUpdate()
    {
        parar();
        rotacionarPincaFDT(garra.garraDto.Velocidades.MovAnguloFechamento, anguloDesejadoEsquerda, anguloDesejadoDireita);
        
        if (isPincaDireitaNoAngulo(anguloDesejadoDireita))
        {       
            comunicadorComGerMovimentacao.trocarParaAcaoSubindo();
        }        
    }    
}
