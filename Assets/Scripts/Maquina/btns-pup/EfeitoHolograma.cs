using UnityEngine;
using System.Collections;

public class EfeitoHolograma 
{
    private readonly int ESTADO_DESLIGADO          = 0;
    private readonly int ESTADO_LIGADO_EFEITO_HOR  = 1;
    private readonly int ESTADO_LIGADO_EFEITO_VERT = 2;

    private int estadoAtual;
    private EfeitoHologramaBtnPupDto efeitoHologramaDto;    

    public EfeitoHolograma(EfeitoHologramaBtnPupDto efeitoHologramaDto)
    {
        this.efeitoHologramaDto = efeitoHologramaDto;
    }

    public void ligarNaPosicao(BotaoPowerUpDtoV2 btnPowerUpDto)
    {   
        efeitoHologramaDto.GoMainEfeito.SetActive(true);
        efeitoHologramaDto.TransfMainEfeito.localPosition = new Vector3(btnPowerUpDto.PosXBotao, efeitoHologramaDto.TransfMainEfeito.localPosition.y, efeitoHologramaDto.TransfMainEfeito.localPosition.z);
        Vector3 localRotation = efeitoHologramaDto.TransfMainEfeito.localRotation.eulerAngles;
        efeitoHologramaDto.TransfMainEfeito.localRotation = Quaternion.Euler(localRotation.x, btnPowerUpDto.RotacaoY, localRotation.z);
        efeitoHologramaDto.TransfEfeitoVertical.localPosition = new Vector3(btnPowerUpDto.PosXPlaca, efeitoHologramaDto.TransfEfeitoVertical.localPosition.y, efeitoHologramaDto.TransfEfeitoVertical.localPosition.z);
        efeitoHologramaDto.GoEfeitoHorizontal.SetActive(true);
        efeitoHologramaDto.GoEfeitoVertical.SetActive(false);

        estadoAtual = ESTADO_LIGADO_EFEITO_HOR;
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(updateTime());
    }

    public void ligarEfeitoExtra()
    {
        estadoAtual = ESTADO_LIGADO_EFEITO_VERT;
    }

    public void desligar()
    {
        Debug.Log("Estado desligado chamado");
        estadoAtual = ESTADO_DESLIGADO;    
    }

    private IEnumerator updateTime()
    {

        while (estadoAtual == ESTADO_LIGADO_EFEITO_HOR)
        {
            efeitoHologramaDto.MeshRendererEfeitoHorizontal.sharedMaterial.SetFloat("_updateTime", Time.unscaledTime);
            yield return null;
        }

        if(estadoAtual == ESTADO_LIGADO_EFEITO_VERT)
        {
            IntervaloDeTempo intervalo = new IntervaloDeTempo(0.5f);            
            while(estadoAtual == ESTADO_LIGADO_EFEITO_VERT && !intervalo.contarTempoUnescaled())
            {
                efeitoHologramaDto.GoEfeitoHorizontal.SetActive(false);
                efeitoHologramaDto.MeshRendererEfeitoVertical.gameObject.SetActive(true);                
                efeitoHologramaDto.MeshRendererEfeitoVertical.sharedMaterial.SetFloat("_updateTime", Time.unscaledTime);
                yield return null;
            }
            estadoAtual = ESTADO_DESLIGADO;            
        }

        if(estadoAtual == ESTADO_DESLIGADO)
        {
            ContextoEstaticoUtils.continuarGame();
            yield return new WaitForSeconds(0.2f);
            efeitoHologramaDto.GoMainEfeito.SetActive(false);            
        }
    }
}
