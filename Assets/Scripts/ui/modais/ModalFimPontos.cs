public class ModalFimPontos : AbstractModalFim
{
    private ModalPontosDto modalPontosDto;

    public ModalFimPontos(ModalPontosDto modalPontosDto)
    {
        this.modalPontosDto = modalPontosDto;
        modalPontosDto.BtnAvancar.onClick.AddListener(() => irParaCena());
    }

    public void passarResultados(string resultados)
    {

    }

    public override void ligar()
    {
        modalPontosDto.GoModalPontos.SetActive(true);
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaMap();
    }
}
