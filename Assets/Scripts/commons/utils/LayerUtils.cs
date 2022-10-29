using UnityEngine;

public class LayerUtils
{
    public static readonly string LAYER_COLETAVEL_DESCRICAO = "Coletavel";
    public static readonly int    LAYER_COLETAVEL_INDICE = LayerMask.NameToLayer(LAYER_COLETAVEL_DESCRICAO);

    public static readonly string LAYER_GAIOLA_DESCRICAO = "Gaiola";

    public static readonly string LAYER_COLETAVELGAIOLA_DESCRICAO = "GaiolaColetavel";
    public static readonly int    LAYER_COLETAVELGAIOLA_INDICE    = LayerMask.NameToLayer(LAYER_COLETAVELGAIOLA_DESCRICAO);

    public static readonly int LAYER_ELEVADOR_INDICE = 20;
    public static readonly int LAYER_NORMAL_INDICE   = 9;

    public static readonly int LAYER_ATRACAO_INDICE = LayerMask.NameToLayer("Atracao");
    public static readonly int LAYER_NAOINTERACAOCOLETAVEL_INDICE = LayerMask.NameToLayer("ColetavelNaoInteracao");

    public static readonly LayerMask LAYER_GARRACCENTRO_MASK = LayerMask.GetMask("GarraCentro");

    public static readonly int LAYER_CONTAINER_COLETAVEL_INDICE = LayerMask.NameToLayer("ContainerColetavel");
}
