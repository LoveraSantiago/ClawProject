using UnityEngine;

public class ColetadoFimDto 
{
    private static readonly int ESTADO_NORMAL    = 0;
    private static readonly int ESTADO_ROLLBACK     = 1;
    private static readonly int ESTADO_DESCARTE = 2;

    private int estadoAtual;
    public bool isNormal { get { return estadoAtual == ESTADO_NORMAL; } }
    public bool isRollback { get { return estadoAtual == ESTADO_ROLLBACK; } }
    public bool isDescarte { get { return estadoAtual == ESTADO_DESCARTE; } }
    public bool[] clears { get; private set; }

    private ColetadoFimDto(int estadoAtual, bool[] clears)        
    {
        this.estadoAtual = estadoAtual;
        this.clears = clears;
    }    

    public int getPrimeiroIndiceParaLimpar()
    {
        if (clears[0]) return 0;
        if (clears[1]) return 1;
        return 2;
    }

    public bool isTodosColetados()
    {
        return clears[0] && clears[1] && clears[2];
    }

    public static ColetadoFimDto ofNormal(bool[] clears)
    {
        return new ColetadoFimDto(ESTADO_NORMAL, clears);        
    }

    public static ColetadoFimDto ofPup(PowerUpEnums.TIPO tipo, bool[] clears)
    {
        if(tipo == PowerUpEnums.TIPO.ROLLBACK)
        {
            //Debug.Log("Tipo Rollback criado");
            return new ColetadoFimDto(ESTADO_ROLLBACK, clears);
        }
        else if(tipo == PowerUpEnums.TIPO.DESCARTE)
        {
            //Debug.Log("Tipo Descarte criado");
            return new ColetadoFimDto(ESTADO_DESCARTE, clears);
        }
        else
        {
            //Debug.Log("Tipo Normal criado");
            return ofNormal(clears);
        }
    }
}
