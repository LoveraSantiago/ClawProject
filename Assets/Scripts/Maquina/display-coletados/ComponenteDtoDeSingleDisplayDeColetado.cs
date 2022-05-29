using UnityEngine;

public abstract class ComponenteDtoDeSingleDisplayDeColetado 
{
    private static DisplaysColetadosDto displaysColetadosDto;
    private SingleSlotColetadoDto singleSlotColetadoDto;

    protected ComponenteDtoDeSingleDisplayDeColetado(SingleSlotColetadoDto singleSlotColetadoDto)
    {
        this.singleSlotColetadoDto = singleSlotColetadoDto;
    }

    public void colorirPlacaGrupo(Color cor)
    {
        displaysColetadosDto.SprRendererPlacaGrupo.color = cor;
    }

    public void configuradoPeloLevel(Color corDisplay)
    {
        singleSlotColetadoDto.SprRendererSlotColetado.color = corDisplay;
    }

    public float getFimDelay()
    {
        return displaysColetadosDto.FimDelay;
    }

    protected void mostrarAlvo()
    {
        singleSlotColetadoDto.SprRendererSlotMeio.sprite = getDisplaysColetadosDto().SprMiraGrossa;
        singleSlotColetadoDto.SprRendererSlotMeio.sharedMaterial = getDisplaysColetadosDto().MaterialAlvoPiscando;
    }

    public void mostrarAlvoSelecionado()
    {
        singleSlotColetadoDto.SprRendererSlotMeio.sprite = getDisplaysColetadosDto().SprMiraGrossa;
        singleSlotColetadoDto.SprRendererSlotMeio.sharedMaterial = getDisplaysColetadosDto().MaterialAlvoSelecionado;
    }

    protected void desligarAlvo()
    {
        singleSlotColetadoDto.SprRendererSlotMeio.sprite = null;
        singleSlotColetadoDto.SprRendererSlotMeio.sharedMaterial = MaterialSprUnlitDefault.getMaterial();
    }

    protected void mostrarColetado(Sprite sprite)
    {
        singleSlotColetadoDto.SprRendererSlotBaixo.sprite = sprite;
    }

    protected void mostrarNone()
    {
        singleSlotColetadoDto.SprRendererSlotCima.sprite = getDisplaysColetadosDto().SprNone;
        singleSlotColetadoDto.SprRendererSlotCima.color = Color.red;
    }

    protected void limparNone()
    {
        singleSlotColetadoDto.SprRendererSlotCima.sprite = null;
    }

    protected bool isMiraSelecionado()
    {
        return getSingleSlotColetadoDto().SprRendererSlotMeio.sharedMaterial == getDisplaysColetadosDto().MaterialAlvoPiscando ||
               getSingleSlotColetadoDto().SprRendererSlotMeio.sharedMaterial == getDisplaysColetadosDto().MaterialAlvoSelecionado;
    }

    protected DisplaysColetadosDto getDisplaysColetadosDto()
    {
        return displaysColetadosDto;
    }

    protected SingleSlotColetadoDto getSingleSlotColetadoDto()
    {
        return singleSlotColetadoDto;
    }

    protected static void configurar(DisplaysColetadosDto displayColetadosDtoArg)
    {
        displaysColetadosDto = displayColetadosDtoArg;
    }
}
