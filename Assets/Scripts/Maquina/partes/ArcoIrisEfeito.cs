using System.Collections;
using UnityEngine;

public class ArcoIrisEfeito : AcaoTempoEsgotado.ConsumidorEvento,
                              AcaoCacaNiquel.ConsumidorEvento
{
    public static Color greenHdr  { get; private set; }
    public static Color redHdr    { get; private set; }
    public static Color yellowHdr { get; private set; }

    private MaquinaEfeitoGlowDto maquinaEfeitoGlowDto;    
    private Coroutine coroutineAtual;        

    public ArcoIrisEfeito(MaquinaEfeitoGlowDto maquinaEfeitoGlowDto)
    {
        this.maquinaEfeitoGlowDto = maquinaEfeitoGlowDto;                
        configurarCoresHdr(maquinaEfeitoGlowDto.FactorHdr);
    }

    public void ligarEfeitoArcoIris()
    {
        ligarGlows();
        cleanCoroutineEmAndamento();
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(ligarGlowArcoIris());
    }

    public void ligarBlinkRed()
    {
        cleanCoroutineEmAndamento();
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(blinkarCor(redHdr));
    }

    public void ligarBlinkVerde()
    {
        cleanCoroutineEmAndamento();
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(blinkarCor(greenHdr));
    }

    public void ligarBlinkYellow()
    {
        cleanCoroutineEmAndamento();
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(blinkarCor(yellowHdr));
    }

    public void desligarEfeito()
    {
        desligarGlows();
        cleanCoroutineEmAndamento();
    }   

    private void ligarGlows()
    {
        maquinaEfeitoGlowDto.GoEfeito.SetActive(true);
    }

    private void desligarGlows()
    {
        maquinaEfeitoGlowDto.GoEfeito.SetActive(false);        
    }

    private void cleanCoroutineEmAndamento()
    {
        if (coroutineAtual != null)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutineAtual);
            coroutineAtual = null;
        }
    }

    private IEnumerator ligarGlowArcoIris()
    {
        while (true)
        {            
            Color singleColor    = HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * 0.5f, 1), 1, 1));
            Color singleColorHdr = HSBColor.toHdrColor(singleColor, maquinaEfeitoGlowDto.FactorHdr);

            maquinaEfeitoGlowDto.GoEfeito.SetActive(true);
            setCorNosMateriaisLayers(singleColorHdr);
            yield return null;
        }
    }

    private IEnumerator blinkarCor(Color cor)
    {
        while (true)
        {
            ligarGlows();            
            setCorNosMateriaisLayers(cor);            
            yield return new WaitForSeconds(0.2f);

            desligarGlows();            
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void configurarCoresHdr(float factorHdr)
    {
        greenHdr  = HSBColor.toHdrColor(Color.green, factorHdr);
        redHdr    = HSBColor.toHdrColor(Color.red, factorHdr);
        yellowHdr = HSBColor.toHdrColor(Color.yellow, factorHdr);
    }

    private void setCorNosMateriaisLayers(Color cor)
    {
        for (int contador = 0; contador < maquinaEfeitoGlowDto.MaterialLayers.Length; contador++)
        {
            maquinaEfeitoGlowDto.MaterialLayers[contador].SetColor("_corGlow", cor);
        }
    }

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotadoDto evento)
    {
        ligarBlinkRed();
    }

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelEventoDto evento)
    {
        if (evento.isEmAndamento)
        {
            if (evento.isResultSucesso())
            {
                ligarBlinkVerde();
            }
            else if (evento.isResultFail())
            {
                ligarBlinkRed();
            }
            else
            {
                ligarBlinkYellow();
            }
        }
    }
}
