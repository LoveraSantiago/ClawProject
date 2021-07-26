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

    public GerenciadorDeMovimentacaoNormal()
    {        
        MovimentacaoDaGarraNormal.configurarComunicadorComGerMovimentacao(this);

        movLateral        = new MovimentacaoLateralZigZag();
        movPCima          = new MovimentacaoParaCima();
        movPBaixo         = new MovimentacaoParaBaixo();
        movAgarrandoBaixo = new MovimentacaoAgarrandoEmbaixo();
        movVoltarMeio = new MovimentacaoVoltarParaMeioNormal();
    }

    public void configuradoPeloLevel(GarraManager.MECANICA_GARRA mecanicaGarraEscolhida)
    {
        movLateral = selecionarMecanicaHorizontal(mecanicaGarraEscolhida);
    }

    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO INICIO
    public override void iniciarMovimentacoes()
    {
        trocarMovimentador(movLateral);
    }

    public override void update()
    {
        movAtual.update();
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

    public MovimentacaoDaGarra selecionarMecanicaHorizontal(GarraManager.MECANICA_GARRA mecanicaGarraEscolhida)
    {
        switch (mecanicaGarraEscolhida)//MECANICAS ANTIGAS REMOVIDAS IMPLEMENTACAO LEGADA
        {
            case (GarraManager.MECANICA_GARRA.ZIG_ZAG):
                return movLateral;
        }
        return new MovimentacaoLateralZigZag();
    }

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
        trocarMovimentador(movLateral);
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
        throw new System.NotImplementedException();
    }

    public void trocarParaAcaoParado()
    {
        throw new System.NotImplementedException();
    }
    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL FIM

    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }

    ProdutorDeEvento<InformacoesColetadoImantadoDto> AcaoImantadoPelaGarra.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return ((AcaoImantadoPelaGarra.ProdutorEvento)movPBaixo).getProdutorDeEventoColetado();
    }

    ProdutorDeEvento<ContagemSubidaGarra> AcaoSubidaDaGarra.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return ((AcaoSubidaDaGarra.ProdutorEvento)movPCima).getProdutorDeEventoColetado();
    }

   
}
