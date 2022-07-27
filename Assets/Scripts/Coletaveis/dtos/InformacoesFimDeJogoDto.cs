public class InformacoesFimDeJogoDto 
{
    private const int FIM_COLETADOS_FALSE   = 0;
    private const int FIM_COLETADOS_TRUE    = 1;
    private const int ERRO_ORDEM            = 2;
    private const int TRINCA_COLETAVEIS     = 3;
    private const int FAIL_TRINCA_COLETAVEIS= 4;

    private int estadoAtual = 0;

    public bool fimColetados        { get { return estadoAtual == FIM_COLETADOS_TRUE; } }
    public bool erroOrdem           { get { return estadoAtual == ERRO_ORDEM; } }
    public bool trincaColetaveis    { get { return estadoAtual == TRINCA_COLETAVEIS; } }
    public bool trincaColetaveisFail{ get { return estadoAtual == FAIL_TRINCA_COLETAVEIS; } }

    private InformacoesFimDeJogoDto(int estado)
    {
        estadoAtual = estado;
    }

    public static InformacoesFimDeJogoDto ofFimColetados(bool fimDeColetaveis)
    {
        if (fimDeColetaveis)
        {
            return new InformacoesFimDeJogoDto(FIM_COLETADOS_TRUE);
        }
        else
        {
            return new InformacoesFimDeJogoDto(FIM_COLETADOS_FALSE);
        }
    }

    public static InformacoesFimDeJogoDto ofErroOrdem()
    {
        return new InformacoesFimDeJogoDto(ERRO_ORDEM);
    }

    public static InformacoesFimDeJogoDto ofTrinca()
    {
        return new InformacoesFimDeJogoDto(TRINCA_COLETAVEIS);
    }

    public static InformacoesFimDeJogoDto ofTrincaFail()
    {
        return new InformacoesFimDeJogoDto(FAIL_TRINCA_COLETAVEIS);
    }
}
