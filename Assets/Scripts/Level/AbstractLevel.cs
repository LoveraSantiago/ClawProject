using System.Collections.Generic;

public abstract class AbstractLevel 
{
    protected static readonly string TIMER_ZERO = "00:00";

    public abstract string getLevelName();

    public abstract string getMsgObjetivoLevel();

    public abstract GarraManager.MECANICA_GARRA getMecanicaDaGarra();

    public abstract bool devolverParaBoard();//Pode ser trocado p enum para tipos de devolucoes

    public abstract int[,] getArrayDeColetaveis();
    public abstract ColetavelEntidade.FAMILIA getFamiliaColetavel();

    public abstract PowerUpEntidade.NAME[] getPowerUpsParaBotoesMaquina();

    public abstract TipoContagemTempoDto getTempoContagem();

    public abstract Dictionary<string, string> getDicionarioDeCores();
   
    public bool isFaseContagemContinua()
    {
        return getTempoContagem().contagem == ContadorTimer.Contagem.CONTINUA;
    }
}
