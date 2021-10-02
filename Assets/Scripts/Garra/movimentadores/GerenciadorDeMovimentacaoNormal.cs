using UnityEngine;

public class GerenciadorDeMovimentacaoNormal : GerenciadorDeMovimentacao,
                                               ComunicadorComGerMovNormal,
                                               AcaoImantadoPelaGarra.ProdutorEvento,
                                               AcaoSubidaDaGarra.ProdutorEvento
{
    private MovimentacaoDaGarra   movAtual;
    private MovimentacaoParaBaixo movPBaixo;
    private MovimentacaoDaGarra   movAgarrandoBaixo;
    private MovimentacaoParaCima  movPCima;
    private MovimentacaoDaGarra   movLateral;
    private MovimentacaoDaGarra   movVoltarMeio;
    private MovimentacaoDaGarra   movParado;

    public GerenciadorDeMovimentacaoNormal()
    {        
        MovimentacaoDaGarraNormal.configurarComunicadorComGerMovimentacao(this);

        movLateral        = new MovimentacaoLateralZigZag();
        movPCima          = new MovimentacaoParaCima();
        movPBaixo         = new MovimentacaoParaBaixo();
        movAgarrandoBaixo = new MovimentacaoAgarrandoEmbaixo();
        movVoltarMeio     = new MovimentacaoVoltarParaMeioNormal();
        movParado         = new MovimentacaoParadoNormal();
    }

    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO INICIO
    public override void iniciarMovimentacoes()
    {
        trocarMovimentador(movLateral);
    }

    public override void update(InputGame inputGame)
    {
        movAtual.update(inputGame);
        //Debug.Log(movimentacaoAtual);
    }

    public override void fixedUpdate()
    {
        movAtual.fixedUpdate();
    }

    public override void garraColidiuCom(Collider2D other)
    {
        movAtual.garraColidiuCom(other.gameObject);
    }

    public override void garraComemorar()
    {
        movAtual.comemorar();
    }
    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO FIM

    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL INICIO    
    public void trocarParaAcaoDescendo()
    {
        AudioController.current.PlayAudioGarra();        
        trocarMovimentador(movPBaixo);
    }

    public void trocarParaAcaoSubindo()
    {
        movPCima.toAcaoNormal();
        trocarMovimentador(movPCima);
    }

    public void trocarParaAcaoNormal()
    {
        AudioController.current.StopAudioGarra();
        if (movAtual.isComemorando())
        {
            //Debug.Log("comemorando");
            trocarParaAcaoParado();
        }
        else
        {
            //Debug.Log("normal");
            trocarMovimentador(movLateral);
        }
    }

    public void trocarParaAcaoAgarrada()
    {
        trocarMovimentador(movAgarrandoBaixo);
    }

    public void trocarParaAcaoVoltarParaCima()
    {
        movPCima.toAcaoEsperar();
        trocarMovimentador(movPCima);
    }

    public void trocarParaAcaoVoltarParaMeio()
    {
        trocarMovimentador(movVoltarMeio);
    }

    public void trocarParaAcaoParado()
    {
        trocarMovimentador(movParado);
    }
    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL FIM

    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }

    ProdutorDeEvento<InformacoesDaGarraDto> AcaoImantadoPelaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoImantadoPelaGarra.ProdutorEvento)movPBaixo).getProdutorDeEvento();
    }

    ProdutorDeEvento<ContagemSubidaGarra> AcaoSubidaDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoSubidaDaGarra.ProdutorEvento)movPCima).getProdutorDeEvento();
    }

   
}
