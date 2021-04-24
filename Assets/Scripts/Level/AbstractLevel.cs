public abstract class AbstractLevel 
{
    public abstract string getMsgObjetivoLevel();
    public abstract GarraManager.MECANICA_GARRA getMecanicaDaGarra();
    public abstract bool devolverParaBoard();//Pode ser trocado p enum para tipos de devolucoes
    public abstract int[,] getArrayDeColetaveis();
}
