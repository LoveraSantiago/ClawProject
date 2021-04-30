using UnityEngine;

public class GerenciadorDeMovimentacaoNormal : GerenciadorDeMovimentacao,
                                               ComunicadorComGerMovNormal
{
    private MovimentacaoDaGarra           movAtual;
    private MovimentacaoParaBaixo         movPBaixo;
    private MovimentacaoDaGarra           movAgarrandoBaixo;
    private MovimentacaoParaCima          movPCima;
    private MovimentacaoDaGarra           movLateral;    

    public GerenciadorDeMovimentacaoNormal(GarraManager.MECANICA_GARRA mecanicaGarraEscolhida)
    {        
        MovimentacaoDaGarraNormal.configurarComunicadorComGerMovimentacao(this);

        movLateral        = selecionarMecanicaHorizontal(mecanicaGarraEscolhida);
        movPCima          = new MovimentacaoParaCima();
        movPBaixo         = new MovimentacaoParaBaixo();
        movAgarrandoBaixo = new MovimentacaoAgarrandoEmbaixo();        
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
    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO FIM

    private MovimentacaoDaGarra selecionarMecanicaHorizontal(GarraManager.MECANICA_GARRA mecanicaGarraEscolhida)
    {
        switch (mecanicaGarraEscolhida)
        {
            case (GarraManager.MECANICA_GARRA.ZIG_ZAG):
                return new MovimentacaoLateralZigZag();

            case (GarraManager.MECANICA_GARRA.TELEGUIADA):
                return new MovimentacaoLateralTeleguiada();

            case (GarraManager.MECANICA_GARRA.ZIG_ZAGTELEGUIADO):
                return new MovimentacaoLateralZigTeleguiado();

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
    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL FIM

    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }    
}
