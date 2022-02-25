using System.Collections.Generic;

public class ControleObstaculos : RemontadorBoard
{
    public Dictionary<int, Dictionary<int, bool>> dicionarioEstadosGaiola;    

    public ControleObstaculos(ReferenciasDoBoardObstaculo referencias, ListaDeSprites listaDeSprites)
        :base(referencias, listaDeSprites)
    {
        this.referencias = referencias;
        inicializarDicionarioEstados();
    }

    public bool getEstadoObstaculo(int linha, int coluna)
    {
        return dicionarioEstadosGaiola[linha][coluna];
    }

    public void processarObstaculo(PosicaoMira posicaoMira)
    {
        Dictionary<int, bool> dicionarioLinha = dicionarioEstadosGaiola[posicaoMira.linha];
        bool estado = dicionarioLinha[posicaoMira.coluna];
        bool estadoAtual = !estado;

        dicionarioLinha[posicaoMira.coluna] = estadoAtual;        
        if (estadoAtual)
        {   
            updateGaiola(posicaoMira.linha, posicaoMira.coluna, true);
        }
        else
        {            
            updateGaiola(posicaoMira.linha, posicaoMira.coluna, false);
        }
    }

    public void resetControle()
    {
        for(int contadorLinha = 0; contadorLinha < dicionarioEstadosGaiola.Count; contadorLinha++)
        {
            for(int contadorColuna = 0; contadorColuna < dicionarioEstadosGaiola[contadorLinha].Count; contadorColuna++)
            {
                dicionarioEstadosGaiola[contadorLinha][contadorColuna] = false;
            }
        }
    }

    public void montarObstaculos(bool[,] obstaculos)
    {
        if (obstaculos == null)
        {
            return;
        }

        int qtdLinhas = referencias.getQtdLinhasDoBoard();
        for (int contadorLinha = 0; contadorLinha < qtdLinhas; contadorLinha++)
        {
            int qtdColunas = referencias.getQtdColunasDoBoard(contadorLinha);
            for (int contadorColuna = 0; contadorColuna < qtdColunas; contadorColuna++)
            {
                bool estadoGaiola = obstaculos[contadorLinha, contadorColuna];
                dicionarioEstadosGaiola[contadorLinha][contadorColuna] = estadoGaiola;                
                updateGaiola(contadorLinha, contadorColuna, estadoGaiola);
            }
        }
    }

    private void updateGaiola(int linha, int coluna, bool estado)
    {
        ((ReferenciasDoBoardObstaculo)referencias).updateElementoGaiola(linha, coluna, estado);
    }

    private void inicializarDicionarioEstados()
    {
        int qtdLinhas = referencias.getQtdLinhasDoBoard();
        int qtdColunas = referencias.getQtdColunasDoBoard(0);

        dicionarioEstadosGaiola = new Dictionary<int, Dictionary<int, bool>>();
        for(int contadorLinha = 0; contadorLinha < qtdLinhas; contadorLinha++)
        {
            Dictionary<int, bool> dicionarioEstadoColuna = new Dictionary<int, bool>();
            for(int contadorColuna = 0; contadorColuna < qtdColunas; contadorColuna++)
            {
                dicionarioEstadoColuna.Add(contadorColuna, false);
            }
            dicionarioEstadosGaiola.Add(contadorLinha, dicionarioEstadoColuna);
        }
    }
}
