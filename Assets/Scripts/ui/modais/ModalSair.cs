public class ModalSair : AcaoDesligarMaquina.ConsumidorEvento
{
    private ModalSairDto modalSairDto;
    private CallbackDesligar callBackDesligar;

    public ModalSair(ModalSairDto modalSairDto)
    {
        this.modalSairDto = modalSairDto;
        this.modalSairDto.BtnCancelar.onClick.AddListener(()=>cancelarSaida());
    }

    public void cancelarSaida()
    {
        modalSairDto.ModalSair.SetActive(false);
        callBackDesligar.cancelarDesligamento();
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(AcaoDesligar evento)
    {
        modalSairDto.ModalSair.SetActive(true);
        callBackDesligar = evento.callbackDesligar;
    }
}
