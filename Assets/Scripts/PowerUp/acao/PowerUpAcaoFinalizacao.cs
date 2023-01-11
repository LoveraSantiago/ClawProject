public interface PowerUpAcaoFinalizacao 
{

    void emAndamento(PowerUpEnums.ESTADO estadoAtual);
    void preFinalizar();
    void preFinalizar(Coletavel coletavel);
    void expirado();
    void finalizado();
}
