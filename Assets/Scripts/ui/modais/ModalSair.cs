public class ModalSair : AcaoDesligarMaquina.ConsumidorEvento
{
    private ModalSairDto modalSairDto;

    public ModalSair(ModalSairDto modalSairDto)
    {
        this.modalSairDto = modalSairDto;
        this.modalSairDto.BtnCancelar.onClick.AddListener(()=>cancelarSaida());
    }

    public void cancelarSaida()
    {

    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(AcaoDesligar evento)
    {
        modalSairDto.ModalSair.SetActive(true);
    }
}
