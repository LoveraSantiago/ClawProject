public class ModalSair : AcaoDesligarMaquinaCancelado.ProdutorEvento, 
                         AcaoDesligarMaquina.ConsumidorEvento    
{
    private const int SAIR_NORMAL    = 0;
    private const int SAIR_COLETAVEL = 1;
    private const int SAIR_EXTRA     = 2;

    private int estadoSairPara;    
    
    private ModalSairDto modalSairDto;
    private ProdutorDeEvento<CancelarDesligarMaquina> produtorDeEvento;

    public ModalSair(ModalSairDto modalSairDto)
    {
        this.modalSairDto = modalSairDto;
        this.modalSairDto.BtnCancelar.onClick.AddListener(()=>cancelarSaida());
        this.modalSairDto.BtnSair.onClick.AddListener(()=>sairDoGame());
        produtorDeEvento = new ProdutorDeEvento<CancelarDesligarMaquina>();
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        if(isSairByLevel(level))
        {
            estadoSairPara = SAIR_NORMAL;                       
        }
        else if (LevelUtils.isColetavelLevel(level))
        {
            estadoSairPara = SAIR_COLETAVEL;
        }
        else
        {
            estadoSairPara = SAIR_EXTRA;                        
        }
    }

    private bool isSairByLevel(AbstractLevel level)
    {
        return LevelUtils.isNormalLevel(level) || LevelUtils.isOrdemLevel(level) || LevelUtils.isElevadorLevel(level);
    }

    private void cancelarSaida()
    {
        modalSairDto.ModalSair.SetActive(false);
        produtorDeEvento.produziuEvento(null);
        Utils.continuarGame();
    }

    private void sairDoGame()
    {
        Utils.continuarGame();
        switch (estadoSairPara)
        {
            case SAIR_NORMAL:    CenaUtils.irParaCenaMap();        break;
            case SAIR_COLETAVEL: CenaUtils.irParaCenaColetaveis(); break;
            case SAIR_EXTRA:     CenaUtils.irParaCenaPup();        break;
        }        
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquina evento)
    {
        Utils.pausarGame();
        string text = null;
        switch (estadoSairPara)
        {
            case SAIR_NORMAL:    text = "Tem certeza que deseja sair?\nVocê perderá sua ficha!"; break;
            case SAIR_COLETAVEL: text = "Tem certeza que deseja sair?\nVocê perderá sua ficha!"; break;
            case SAIR_EXTRA:     text = "Tem certeza que deseja sair do treinamento?"; break;
        }
        
        modalSairDto.TextoSair.text = text;
        modalSairDto.ModalSair.SetActive(true);        
    }

    ProdutorDeEvento<CancelarDesligarMaquina> AcaoDesligarMaquinaCancelado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
