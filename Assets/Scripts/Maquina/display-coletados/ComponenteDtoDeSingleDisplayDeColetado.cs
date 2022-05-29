using UnityEngine;

public abstract class ComponenteDtoDeSingleDisplayDeColetado 
{
    private static DisplaysColetadosDto displaysColetadosDto;
    private SingleSlotColetadoDto singleSlotColetadoDto;

    protected ComponenteDtoDeSingleDisplayDeColetado(SingleSlotColetadoDto singleSlotColetadoDto)
    {
        this.singleSlotColetadoDto = singleSlotColetadoDto;
    }

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

    protected SingleSlotColetadoDto getSingleSlotColetadoDto()
    {
        return singleSlotColetadoDto;
    }

    public void configuradoPeloLevel(Color corDisplay)
    {
        singleSlotColetadoDto.SprRendererSlotColetado.color = corDisplay;
    }

    public float getFimDelay()
    {
        return displaysColetadosDto.FimDelay;
    }
}
