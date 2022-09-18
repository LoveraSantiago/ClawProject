public class MapaEstado 
{
    private MapaEstadoEnum estadoAtual;
    public bool isLivre     { get { return estadoAtual == MapaEstadoEnum.LIVRE; } }
    public bool isProgresso { get { return estadoAtual == MapaEstadoEnum.PROGRESSO; } }
    public bool isBloqueado { get { return estadoAtual == MapaEstadoEnum.BLOCKED; } }
    public bool isLockado   { get { return estadoAtual == MapaEstadoEnum.LOCKED; } }

    public MapaEstado()
    {
        estadoAtual = MapaEstadoEnum.LIVRE;
    }

    public void emProgresso()
    {
        estadoAtual = MapaEstadoEnum.PROGRESSO;
    }

    public void bloquear()
    {
        estadoAtual = MapaEstadoEnum.BLOCKED;
    }

    public void lockar()
    {
        estadoAtual = MapaEstadoEnum.LOCKED;
    }

    private enum MapaEstadoEnum
    {
        LIVRE, PROGRESSO, LOCKED, BLOCKED
    }
}
