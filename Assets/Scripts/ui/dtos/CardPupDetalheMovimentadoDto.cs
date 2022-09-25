public class CardPupDetalheMovimentadoDto 
{
    private readonly int ESTADO_RESTAURACAO = 0;
    private readonly int ESTADO_FLIP_DOWN   = 1;
    private readonly int ESTADO_FLIP_UP     = 2;


    private int estadoAtual;

    public bool isRestauracao { get { return estadoAtual == ESTADO_RESTAURACAO; } }
    public bool isFlipDown    { get { return estadoAtual == ESTADO_FLIP_DOWN; } }
    public bool isFlipUp      { get { return estadoAtual == ESTADO_FLIP_UP; } }    

    public void restaurar()
    {
        estadoAtual = ESTADO_RESTAURACAO;
    }

    public void flipDown()
    {
        estadoAtual = ESTADO_FLIP_DOWN;
    }

    public void flipUp()
    {
        estadoAtual = ESTADO_FLIP_UP;
    }
}
