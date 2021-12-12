public class InformacoesFimDeJogo 
{
    public bool fimColetados;
    public bool erroOrdem;
    public bool trincaColetaveis;

    private InformacoesFimDeJogo(bool fimColetados, bool erroOrdem, bool trincaColetaveis)
    {
        this.fimColetados = fimColetados;
        this.erroOrdem = erroOrdem;
        this.trincaColetaveis = trincaColetaveis;
    }

    public static InformacoesFimDeJogo ofFimColetados()
    {
        return new InformacoesFimDeJogo(true, false, false);
    }

    public static InformacoesFimDeJogo ofErroOrdem()
    {
        return new InformacoesFimDeJogo(false, true, false);
    }

    public static InformacoesFimDeJogo ofTrinca()
    {
        return new InformacoesFimDeJogo(false, false, true);
    }
}
