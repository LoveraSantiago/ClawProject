using UnityEngine;
using System.Collections;

public class DisplayDeColetado 
{
    private static DisplayDeColetadoDto displayColetadoDto;

    private bool ocupado;

    private Vector3 posicaoDesejada;
    private Vector3 posicaoSlotBaixoInicial;
    private Vector3 posicaoSlotCimaInicial;
      
    private GlowEfeito glowEfeito;
    private AnimacaoDisplayColetado animacao;

    private SingleDisplayColetadoDto sDisplayDto;

    public DisplayDeColetado(SingleDisplayColetadoDto singleDisplayColetadoDto)
    {
        sDisplayDto = singleDisplayColetadoDto;

        animacao = new AnimacaoDisplayColetado(singleDisplayColetadoDto.Animator);

        MaterialGlow materialGlow = new MaterialGlow(displayColetadoDto.MaterialGlowDisplay);
        glowEfeito = new GlowEfeito(singleDisplayColetadoDto.SprRendererDentroEfeito.gameObject, materialGlow);        

        posicaoSlotBaixoInicial = sDisplayDto.GoSlotBaixo.transform.localPosition;
        posicaoSlotCimaInicial = sDisplayDto.GoSlotCima.transform.localPosition;

        Vector3 localPosition = sDisplayDto.GoSlotBaixo.transform.localPosition;
        posicaoDesejada = new Vector3(localPosition.x, 0.5f, localPosition.z);
    }    

    public void configuradoPeloLevel(Color corDisplay, Color corDentro)
    {
        sDisplayDto.SprDisplay.color = corDisplay;
        sDisplayDto.SprRendererDentro.color = corDentro;
    }   

    public void mostrarAlvo(MonoBehaviour monoBehaviour)
    {
        if (ocupado)
        {
            animacao.ligarAnimacaoMira();            
        }
        else
        {
            monoBehaviour.StartCoroutine(descerSlotCima(displayColetadoDto.SprVazio));
        }
    }

    public void desligarAlvo(MonoBehaviour monoBehavior)
    {
        if (animacao.isMiraLigado)
        {
            animacao.desligarAnimacao();
        }
        else{
            monoBehavior.StartCoroutine(subirSlotCima());
        }
    }

    public IEnumerator subirSlotBaixo(Sprite sprite)
    {
        ocupado = true;

        sDisplayDto.SlotSpriteBaixo.sprite = sprite;
        ligarGlowLuz();
        yield return new WaitForSeconds(displayColetadoDto.InicialDelay);

        while(slotBaixoAtingiuPosicao(posicaoDesejada))        
        {
            moverSlotBaixoAtePosicao(posicaoDesejada);
            yield return null;
        }

        sDisplayDto.GoSlotBaixo.transform.localPosition = posicaoDesejada;
        yield return new WaitForSeconds(displayColetadoDto.InicialDelay);
        desligarGlow();
    }   

    public IEnumerator descerSlotBaixo()
    {
        ocupado = false;

        yield return new WaitForSeconds(displayColetadoDto.FimDelay);

        while(slotBaixoAtingiuPosicao(posicaoSlotBaixoInicial))        
        {            
            moverSlotBaixoAtePosicao(posicaoSlotBaixoInicial);
            yield return null;
        }
        sDisplayDto.GoSlotBaixo.transform.localPosition = posicaoSlotBaixoInicial;
    }     
    
    public IEnumerator descerSlotCima(Sprite sprite)
    {
        sDisplayDto.SlotSpriteCima.sprite = sprite;
        sDisplayDto.SlotSpriteCima.color = Color.red;
        while (slotCimaAtingiuPosicao(posicaoDesejada))
        {
            moverSlotCimaAtePosicao(posicaoDesejada);
            yield return null;
        }
        sDisplayDto.GoSlotCima.transform.localPosition = posicaoDesejada;
        yield return null;
    }

    public IEnumerator subirSlotCima()
    {
        while (slotCimaAtingiuPosicao(posicaoSlotCimaInicial))
        {
            moverSlotCimaAtePosicao(posicaoSlotCimaInicial);
            yield return null;
        }
        sDisplayDto.GoSlotBaixo.transform.localPosition = posicaoSlotCimaInicial;
    }

    private bool slotBaixoAtingiuPosicao(Vector3 posicao)
    {
        return slotaAtingiuPosicao(sDisplayDto.GoSlotBaixo, posicao);        
    }

    private bool slotCimaAtingiuPosicao(Vector3 posicao)
    {
        return slotaAtingiuPosicao(sDisplayDto.GoSlotCima, posicao);        
    }

    private bool slotaAtingiuPosicao(GameObject slot, Vector3 posicao)
    {
        return (Vector3.Distance(slot.transform.localPosition, posicao))
               > (displayColetadoDto.VelocImg * Time.deltaTime);
    }

    private void moverSlotBaixoAtePosicao(Vector3 posicao)
    {
        moverSlotAtePosicao(sDisplayDto.GoSlotBaixo, posicao);        
    }

    private void moverSlotCimaAtePosicao(Vector3 posicao)
    {
        moverSlotAtePosicao(sDisplayDto.GoSlotCima, posicao);        
    }

    private void moverSlotAtePosicao(GameObject slot, Vector3 posicao)
    {
        float acrescimo = displayColetadoDto.VelocImg * Time.deltaTime;
        slot.transform.localPosition = Vector3.MoveTowards(
                slot.transform.localPosition, posicao, acrescimo);
    }

    public void ligarGlowSucesso()
    {
        glowEfeito.ligarGlowSucesso();        
    }

    public void ligarGlowFail()
    {
        glowEfeito.ligarGlowFail();
    }

    public void ligarGlowLuz()
    {
        glowEfeito.ligarGlowLuz();        
    }

    public void desligarGlow()
    {
        glowEfeito.desligarGlow();
    }    

    public bool isOcupado()
    {
        return ocupado;
    }

    public bool isDesocupado()
    {
        return !isOcupado();
    }

    public MaterialGlow getMaterialGlow()
    {
        return glowEfeito.getMaterialGlow();
    }

    public static void configurarDisplay(DisplayDeColetadoDto displayColetadoDtoArg)
    {
        displayColetadoDto = displayColetadoDtoArg;
    }
}
