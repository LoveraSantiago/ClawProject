using UnityEngine;
using System.Collections;

public class EfeitoHolograma 
{
    private GameObject goEfeitoHolograma;
    private Coroutine coroutineUpdateTime;

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

        coroutineUpdateTime = Utils.MonoBehaviour.StartCoroutine(updateTime(efeitoHologramaDto.MeshRendererEfeitoHorizontal.sharedMaterial));
    }

    public void desligar()
    {
        goEfeitoHolograma.SetActive(false);
        Utils.MonoBehaviour.StopCoroutine(coroutineUpdateTime);
    }

    private IEnumerator updateTime(Material material)
    {
        while (true)
        {
            material.SetFloat("_updateTime", Time.unscaledTime);
            yield return null;
        }
    }
}
