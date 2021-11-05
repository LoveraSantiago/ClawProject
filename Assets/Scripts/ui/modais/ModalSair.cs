using UnityEngine.SceneManagement;

public class ModalSair : AcaoDesligarMaquinaCancelado.ProdutorEvento, 
                         AcaoDesligarMaquina.ConsumidorEvento    
{
    private string nomeCenaVoltar;
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
            nomeCenaVoltar = "MapScene";
        }
        else
        {
            nomeCenaVoltar = "PupScene";
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
        SceneManager.LoadScene(nomeCenaVoltar);
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquina evento)
    {
        Utils.pausarGame();
        modalSairDto.ModalSair.SetActive(true);        
    }

    ProdutorDeEvento<CancelarDesligarMaquina> AcaoDesligarMaquinaCancelado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
