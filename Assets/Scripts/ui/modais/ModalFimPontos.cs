public class ModalFimPontos : AbstractModalFim
{
    public override void ligar()
    {
        throw new System.NotImplementedException();
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaMap();
    }
}
