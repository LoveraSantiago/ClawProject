public class ModalSair : AcaoDesligarMaquinaResultado.ProdutorEvento, 
                         AcaoDesligarMaquina.ConsumidorEvento    
{
    private const int SAIR_NORMAL    = 0;
    private const int SAIR_COLETAVEL = 1;
    private const int SAIR_EXTRA     = 2;

    private int estadoSairPara;    
    
    private ModalSairDto modalSairDto;
    private ProdutorDeEvento<ResultadoDesligarMaquinaDto> produtorDeEvento;

    public ModalSair(ModalSairDto modalSairDto, Loading loading)
    {
        this.modalSairDto = modalSairDto;
        this.modalSairDto.BtnCancelar.onClick.AddListener(()=>cancelarSaida());
        this.modalSairDto.BtnSair.onClick.AddListener(()=>sairDoGame(loading));
        produtorDeEvento = new ProdutorDeEvento<ResultadoDesligarMaquinaDto>();
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        if(LevelUtils.isPlayableLevel(level))
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

    private void cancelarSaida()
    {
        modalSairDto.ModalSair.SetActive(false);
        produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(false));
        ContextoEstaticoUtils.continuarGame();
    }

    private void sairDoGame(Loading loading)
    {
        ContextoEstaticoUtils.continuarGame();        
        switch (estadoSairPara)
        {
            case SAIR_NORMAL:
                {
                    produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(true, true));
                    loading.irParaMapScene();                    
                    break;
                }
            case SAIR_COLETAVEL:
                {
                    produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(true, false));
                    loading.irParaColetaveisCena();
                    break;
                }
            case SAIR_EXTRA:
                {
                    produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(true, false));
                    loading.irParaPowerUpCena();
                    break;
                }
        }        
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquinaDto evento)
    {
        ContextoEstaticoUtils.pausarGame();
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
