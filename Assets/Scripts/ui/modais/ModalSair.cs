public class ModalSair : AcaoDesligarMaquinaCancelado.ProdutorEvento, 
                         AcaoDesligarMaquina.ConsumidorEvento    
{
    private bool isLevelGame;
    
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
        if(level.isNormalLevel() || level.isOrdemLevel() || level.isElevadorLevel())
        {
            isLevelGame = true;                       
        }
        else
        {
            isLevelGame = false;                        
        }
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
        if (isLevelGame)
        {
            CenaUtils.irParaCenaMap();
        }
        else
        {
            CenaUtils.irParaCenaPup();
        }        
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquina evento)
    {
        Utils.pausarGame();
        if (isLevelGame)
        {
            modalSairDto.TextoSair.text = "Tem certeza que deseja sair?\nVocê perderá sua ficha!";
        }
        else
        {
            modalSairDto.TextoSair.text = "Tem certeza que deseja sair do treinamento?";
        }       
        modalSairDto.ModalSair.SetActive(true);        
    }

    ProdutorDeEvento<CancelarDesligarMaquina> AcaoDesligarMaquinaCancelado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
