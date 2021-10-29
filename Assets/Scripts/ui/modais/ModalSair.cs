public class ModalSair : AcaoDesligarMaquina.ConsumidorEvento
{
    private ModalSairDto modalSairDto;

    public ModalSair(ModalSairDto modalSairDto)
    {
        this.modalSairDto = modalSairDto;
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(AcaoDesligar evento)
    {
        modalSairDto.ModalSair.SetActive(true);
    }
}
