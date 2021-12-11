public interface TrocadorDeOrdem
{
    //CONFIGURAR VIA POWERUPMANAGER VIA ALLMANAGERS
    void trocar(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo);
    void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo);
    void atualizar(ColetavelTile coletavelPrimeiro);
}
