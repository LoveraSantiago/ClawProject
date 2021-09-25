public class BoardOrdem 
{
    public int ordem { get; private set; }
    public int linha { get; private set; }
    public int coluna { get; private set; }

    public BoardOrdem(int ordem, int linha, int coluna)
    {
        this.ordem = ordem;
        this.linha = linha;
        this.coluna = coluna;
    }    
}
