using UnityEngine;

public abstract class ComponenteDtoDeSingleDisplayDeColetado 
{
    private static DisplaysColetadosDto displaysColetadosDto;

    protected static void configurar(DisplaysColetadosDto displayColetadosDtoArg)
    {
        displaysColetadosDto = displayColetadosDtoArg;
    }

    public void colorirPlacaGrupo(Color cor)
    {
        displaysColetadosDto.SprRendererPlacaGrupo.color = cor;
    }

    protected DisplaysColetadosDto getDisplaysColetadosDto()
    {
        return displaysColetadosDto;
    }

    public float getFimDelay()
    {
        return displaysColetadosDto.FimDelay;
    }
}
