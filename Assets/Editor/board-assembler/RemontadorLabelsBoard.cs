public class RemontadorLabelsBoard 
{
    private ListaDeSprites listaDeSprites;
    private ReferenciasDoBoardPositivo referencias;

    public RemontadorLabelsBoard(
        ReferenciasDoBoardPositivo referencias, ListaDeSprites listaDeSprites)
    {
        this.listaDeSprites = listaDeSprites;
        this.referencias = referencias;
    }

    public void montarLabels(BoardOrdem[] boardOrdem)
    {
        if (boardOrdem == null)
        {
            return;
        }

        int contadorNome = 0;
        int qtdLinhas = referencias.getQtdLinhasDoBoard();
        for (int contadorLinha = 0; contadorLinha < qtdLinhas; contadorLinha++)
        {
            int qtdColunas = referencias.getQtdColunasDoBoard(contadorLinha);
            for (int contadorColuna = 0; contadorColuna < qtdColunas; contadorColuna++)
            {
                bool isSpriteVazio = referencias.isElementoGoComSprite(contadorLinha, contadorColuna, listaDeSprites.getSpriteVazio());                
                if (!isSpriteVazio)
                {
                    int nomeOrdem = contadorNome + 1;
                    BoardOrdem boardOrdemIt = getOrdemByNome(nomeOrdem, boardOrdem);
                    if (boardOrdem != null)
                    {
                        referencias.updateElementoTexto(contadorLinha, contadorColuna, boardOrdemIt.ordem.ToString());                        
                    }
                    contadorNome++;
                }
            }
        }
    }

    private BoardOrdem getOrdemByNome(int nomeOrdem, BoardOrdem[] boardOrdem)
    {
        string nomeOrdemString = nomeOrdem.ToString();
        for (int contador = 0; contador < boardOrdem.Length; contador++)
        {
            if (boardOrdem[contador].nome.Equals(nomeOrdemString))
            {
                return boardOrdem[contador];
            }
        }
        return null;
    }
}
