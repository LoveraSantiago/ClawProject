public class ComponenteSomDaGarraDeMovimentacaoGarra : ComponenteGarraDeMovimentacaoGarra
{
    public void playSomGarraMovimentoVertical()
    {
        getGarra().playSomGarraMovimentoVertical();
    }

    public void stopSomGarraMovimentoVertical()
    {
        getGarra().stopSomGarraSubindo();
    }

    public void playSomGarraAgarrando()
    {
        getGarra().playSomGarraAgarrando();
    }

    public void playSomGarraInicioDescida()
    {
        getGarra().playSomGarraInicioDescida();
    }
}
