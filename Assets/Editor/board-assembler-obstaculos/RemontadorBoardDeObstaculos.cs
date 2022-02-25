public class RemontadorBoardDeObstaculos : RemontadorBoard
{
    public RemontadorBoardDeObstaculos(ReferenciasDoBoard referencias, ListaDeSprites listaDeSprites)
        : base(referencias, listaDeSprites){}

    public void montarObstaculos(bool [,] obstaculos)
    {
        if(obstaculos == null)
        {
            return;
        }

        int qtdLinhas = referencias.getQtdLinhasDoBoard();
        for(int contadorLinha = 0; contadorLinha < qtdLinhas; contadorLinha++)
        {
            int qtdColunas = referencias.getQtdColunasDoBoard(contadorLinha);
            for(int contadorColuna = 0; contadorColuna < qtdColunas; contadorColuna++)
            {
                bool estadoGaiola = obstaculos[contadorLinha, contadorColuna];
                if (estadoGaiola)
                {
                    ((ReferenciasDoBoardObstaculo)referencias).updateElementoGaiola(contadorLinha, contadorColuna, true);
                }
            }
        }
    }
}
