using UnityEngine;

public class GerenciadorDeMovimentacaoNormal : GerenciadorDeMovimentacao,
                                               ComunicadorComGerMovNormal,
                                               AcaoInfoDaGarra.ProdutorEvento
{
    private MovimentacaoDaGarra movAtual;        

    public GerenciadorDeMovimentacaoNormal()
    {        
        MovimentacaoDaGarraNormal.configurarComunicadorComGerMovimentacao(this);
        MovimentadorProdutorInformacaoGarra.configurar();               
    }

    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO INICIO
    public override void iniciarMovimentacoes()
    {
        trocarParaMovLateral();        
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
        movAtual.playAnimacaoComemorar();
    }
    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO FIM

    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL INICIO    
    public void trocarParaAcaoDescendo()
    {
        AudioController.current.PlayAudioGarra();        
        trocarMovimentador(new MovimentacaoParaBaixo());
    }

    public void trocarParaAcaoSubindo()
    {   
        trocarMovimentador(new MovimentacaoParaCima());
    }

    public void trocarParaAcaoNormal()
    {
        AudioController.current.StopAudioGarra();
        if (movAtual.isPlayAnimacaoComemorando())
        {
            //Debug.Log("comemorando");
            trocarParaAcaoParado();
        }
        else
        {
            //Debug.Log("normal");
            trocarParaMovLateral();            
        }
    }

    public void trocarParaAcaoAgarrada()
    {
        trocarMovimentador(new MovimentacaoAgarrandoEmbaixo());
    }

    public void trocarParaAcaoVoltarParaCima()
    {   
        trocarMovimentador(new MovimentacaoParaCimaVoltarMeio());
    }

    public void trocarParaAcaoVoltarParaMeio()
    {
        trocarMovimentador(new MovimentacaoVoltarParaMeioNormal());
    }

    public void trocarParaAcaoParado()
    {
        trocarMovimentador(new MovimentacaoParadoNormal());
    }

    public void trocarParaMovLateral()
    {
        trocarMovimentador(new MovimentacaoLateralZigZag());
    }
    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL FIM

    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }

    ProdutorDeEvento<InformacoesDaGarraDto> AcaoInfoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return MovimentadorProdutorInformacaoGarra.produtorEventoInfoGarra;
    }

    public override ProdutorDeEvento<DirecaoDaGarra> getProdutorDeEvento()
    {
        return ((AcaoSincroniaComDirecaoDaGarra.ProdutorEvento)new MovimentacaoLateralZigZag()).getProdutorDeEvento();
    }    
}
