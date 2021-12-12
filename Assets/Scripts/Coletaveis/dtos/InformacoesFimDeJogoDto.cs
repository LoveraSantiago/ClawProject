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

    public static InformacoesFimDeJogoDto ofFimColetados(bool fimDeColetaveis)
    {
        return new InformacoesFimDeJogoDto(fimDeColetaveis, false, false);
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
