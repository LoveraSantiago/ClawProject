using UnityEngine.SceneManagement;

public class ModalSair : AcaoDesligarMaquina.ConsumidorEvento
{
    private string nomeCenaVoltar;
    private ModalSairDto modalSairDto;
    private CallbackDesligar callBackDesligar;

    public ModalSair(ModalSairDto modalSairDto)
    {
        this.modalSairDto = modalSairDto;
        this.modalSairDto.BtnCancelar.onClick.AddListener(()=>cancelarSaida());
        this.modalSairDto.BtnSair.onClick.AddListener(()=>sairDoGame());
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
        callBackDesligar.cancelarDesligamento();
    }

    private void sairDoGame()
    {
        SceneManager.LoadScene(nomeCenaVoltar);
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(AcaoDesligar evento)
    {
        modalSairDto.ModalSair.SetActive(true);
        callBackDesligar = evento.callbackDesligar;
    }
}
