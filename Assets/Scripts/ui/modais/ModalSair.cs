public class ModalSair : AcaoDesligarMaquinaResultado.ProdutorEvento, 
                         AcaoDesligarMaquina.ConsumidorEvento    
{
    private const int SAIR_NORMAL    = 0;
    private const int SAIR_COLETAVEL = 1;
    private const int SAIR_EXTRA     = 2;

    private int estadoSairPara;    
    
    private ModalSairDto modalSairDto;
    private ProdutorDeEvento<ResultadoDesligarMaquinaDto> produtorDeEvento;

    public ModalSair(ModalSairDto modalSairDto)
    {
        this.modalSairDto = modalSairDto;
        this.modalSairDto.BtnCancelar.onClick.AddListener(()=>cancelarSaida());
        this.modalSairDto.BtnSair.onClick.AddListener(()=>sairDoGame());
        produtorDeEvento = new ProdutorDeEvento<ResultadoDesligarMaquinaDto>();
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
        produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(false));
        Utils.continuarGame();
    }

    private void sairDoGame()
    {
        Utils.continuarGame();
        produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(true));
        switch (estadoSairPara)
        {
            case SAIR_NORMAL:    CenaUtils.irParaCenaMap();        break;
            case SAIR_COLETAVEL: CenaUtils.irParaCenaColetaveis(); break;
            case SAIR_EXTRA:     CenaUtils.irParaCenaPup();        break;
        }        
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquinaDto evento)
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

    ProdutorDeEvento<ResultadoDesligarMaquinaDto> AcaoDesligarMaquinaResultado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
