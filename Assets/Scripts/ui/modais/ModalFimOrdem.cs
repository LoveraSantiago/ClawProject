public class ModalFimOrdem : AbstractModalFim
{
    public override void configurar(ModalManipulacao modalManipulacao)
    {        
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaMap();
    }
}
