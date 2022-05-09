using UnityEngine;
using System.Collections;

public class EfeitoHolograma 
{
    private readonly int ESTADO_DESLIGADO   = 0;
    private readonly int ESTADO_ESCOLHA_PUP = 1;

    private int estadoAtual;
    private GameObject goEfeitoHolograma;    

    public EfeitoHolograma(GameObject goEfeitoHolograma)
    {
        this.goEfeitoHolograma = goEfeitoHolograma;
    }

    public void ligar(EfeitoHologramaBtnPupDto efeitoHologramaDto, BotaoPowerUpDtoV2 btnPowerUpDto)
    {   
        efeitoHologramaDto.GoMainEfeito.SetActive(true);
        efeitoHologramaDto.TransfMainEfeito.localPosition = new Vector3(btnPowerUpDto.PosXBotao, efeitoHologramaDto.TransfMainEfeito.localPosition.y, efeitoHologramaDto.TransfMainEfeito.localPosition.z);
        Vector3 localRotation = efeitoHologramaDto.TransfMainEfeito.localRotation.eulerAngles;
        efeitoHologramaDto.TransfMainEfeito.localRotation = Quaternion.Euler(localRotation.x, btnPowerUpDto.RotacaoY, localRotation.z);
        efeitoHologramaDto.GoEfeitoHorizontal.SetActive(true);

        estadoAtual = ESTADO_ESCOLHA_PUP;
        Utils.MonoBehaviour.StartCoroutine(updateTime(efeitoHologramaDto.MeshRendererEfeitoHorizontal.sharedMaterial));
    }

    public void desligar()
    {
        Debug.Log("Estado desligado chamado");
        estadoAtual = ESTADO_DESLIGADO;    
    }

    private IEnumerator updateTime(Material material)
    {
        while (estadoAtual == ESTADO_ESCOLHA_PUP)
        {
            material.SetFloat("_updateTime", Time.unscaledTime);
            yield return null;
        }

        if(estadoAtual == ESTADO_DESLIGADO)
        {
            Utils.continuarGame();
            yield return new WaitForSeconds(0.25f);
            goEfeitoHolograma.SetActive(false);            
        }
    }
}
