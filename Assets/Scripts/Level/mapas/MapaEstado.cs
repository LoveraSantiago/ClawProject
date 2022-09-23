public class MapaEstado 
{
    private MapaEstadoEnum estadoAtual;
    public bool isLivre     { get { return estadoAtual == MapaEstadoEnum.LIVRE; } }
    public bool isProgresso { get { return estadoAtual == MapaEstadoEnum.PROGRESSO; } }
    public bool isBloqueado { get { return estadoAtual == MapaEstadoEnum.BLOCKED; } }
    public bool isLockado   { get { return estadoAtual == MapaEstadoEnum.LOCKED; } }

    public MapaEstado()
    {
        estadoAtual = MapaEstadoEnum.NONE;
    }

    public void liberar()
    {
        estadoAtual = MapaEstadoEnum.LIVRE;
    }

    public void emProgresso()
    {
        if(estadoAtual == MapaEstadoEnum.NONE || estadoAtual == MapaEstadoEnum.LIVRE)
        {
            estadoAtual = MapaEstadoEnum.PROGRESSO;
        }
    }

    public void bloquear()
    {
        if(estadoAtual == MapaEstadoEnum.NONE)
        {
            estadoAtual = MapaEstadoEnum.BLOCKED;
        }
    }

    public void lockar()
    {
        if(estadoAtual == MapaEstadoEnum.NONE)
        {
            estadoAtual = MapaEstadoEnum.LOCKED;
        }
    }

    private enum MapaEstadoEnum
    {
        LIVRE, PROGRESSO, LOCKED, BLOCKED, NONE
    }
}
