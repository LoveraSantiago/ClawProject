public class PosicaoMira 
{
    public int linha { get; private set; }
    public int coluna { get; private set; }

    public PosicaoMira(int linha, int coluna)
    {
        this.linha = linha;
        this.coluna = coluna;
    }
}
