public class InformacoesFimDeJogoDto 
{
    public bool fimColetados;
    public bool erroOrdem;
    public bool trincaColetaveis;

    private InformacoesFimDeJogoDto(bool fimColetados, bool erroOrdem, bool trincaColetaveis)
    {
        this.fimColetados = fimColetados;
        this.erroOrdem = erroOrdem;
        this.trincaColetaveis = trincaColetaveis;
    }

    public static InformacoesFimDeJogoDto ofFimColetados()
    {
        return new InformacoesFimDeJogoDto(true, false, false);
    }

    public static InformacoesFimDeJogoDto ofErroOrdem()
    {
        return new InformacoesFimDeJogoDto(false, true, false);
    }

    public static InformacoesFimDeJogoDto ofTrinca()
    {
        return new InformacoesFimDeJogoDto(false, false, true);
    }
}
