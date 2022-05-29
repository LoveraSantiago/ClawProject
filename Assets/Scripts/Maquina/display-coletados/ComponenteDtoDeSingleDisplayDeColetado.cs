using UnityEngine;

public abstract class ComponenteDtoDeSingleDisplayDeColetado 
{
    protected static DisplaysColetadosDto displaysColetadosDto;

    protected static void configurar(DisplaysColetadosDto displayColetadosDtoArg)
    {
        displaysColetadosDto = displayColetadosDtoArg;
    }

    public void colorirPlacaGrupo(Color cor)
    {
        displaysColetadosDto.SprRendererPlacaGrupo.color = cor;
    }
}
