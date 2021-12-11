public abstract class TrocadorDeOrdem
{
    //CONFIGURAR VIA POWERUPMANAGER VIA ALLMANAGERS
    public abstract void trocar(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo);
    public abstract void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo);
    public abstract void atualizar(ColetavelTile coletavelPrimeiro);
}
