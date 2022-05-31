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

    protected void configSlotBaixo(float y, Sprite sprite)
    {
        singleSlotColetadoDto.SprRendererSlotBaixo.transform.localPosition = new Vector3(0, y, 0);
        singleSlotColetadoDto.SprRendererSlotBaixo.sprite = sprite;
    }

    protected void configSlotMeio(float y, Sprite sprite)
    {
        singleSlotColetadoDto.SprRendererSlotMeio.transform.localPosition = new Vector3(0, y, 0);
        singleSlotColetadoDto.SprRendererSlotMeio.sprite = sprite;
    }

    protected void configSlotCima(float y, Sprite sprite)
    {
        singleSlotColetadoDto.SprRendererSlotCima.transform.localPosition = new Vector3(0, y, 0);
        singleSlotColetadoDto.SprRendererSlotCima.sprite = sprite;
    }

    protected SpriteRenderer[] getSlotsSprRenderers()
    {
       return new SpriteRenderer[] {
            singleSlotColetadoDto.SprRendererSlotBaixo,
            singleSlotColetadoDto.SprRendererSlotMeio,
            singleSlotColetadoDto.SprRendererSlotCima
        };
    }

    protected SpriteRenderer getSprRendererMaisProximo(float y)
    {
        float distBaixo = Mathf.Abs(y - singleSlotColetadoDto.SprRendererSlotBaixo.transform.localPosition.y);
        float distMedio = Mathf.Abs(y - singleSlotColetadoDto.SprRendererSlotMeio.transform.localPosition.y);
        float distCima  = Mathf.Abs(y - singleSlotColetadoDto.SprRendererSlotCima.transform.localPosition.y);
        if(distBaixo < distMedio && distBaixo < distCima)
        {   
            return singleSlotColetadoDto.SprRendererSlotBaixo;
        }
        else if(distMedio < distBaixo && distMedio < distCima)
        {         
            return singleSlotColetadoDto.SprRendererSlotMeio;
        }
        else
        {         
            return singleSlotColetadoDto.SprRendererSlotCima;
        }
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
