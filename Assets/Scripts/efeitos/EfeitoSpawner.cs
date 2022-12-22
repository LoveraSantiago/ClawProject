using UnityEngine;

public class EfeitoSpawner 
{
    private static readonly int ID_TIMESTAMP   = Shader.PropertyToID("_timestamp");
    private static readonly int ID_VELOCIDADE  = Shader.PropertyToID("_velocidade");
    private static readonly int ID_MATERIALIZE = Shader.PropertyToID("_imgMaterialize");

    private EfeitoMaterializeDto efeitoMaterializeDto;

    public EfeitoSpawner(EfeitoMaterializeDto efeitoMaterializeDto)
    {
        this.efeitoMaterializeDto = efeitoMaterializeDto;
    }

    public void spawnPowerUp(Sprite imgMaterialize, float haltura, float escala)
    {
        efeitoMaterializeDto.EfeitoSpawnParticulas.gameObject.SetActive(true);
        efeitoMaterializeDto.EfeitoSpawnParticulas.Play();
        efeitoMaterializeDto.EfeitoSpawnParticulas.transform.position = getPosicao(efeitoMaterializeDto.EfeitoSpawnParticulas.gameObject, haltura);
        efeitoMaterializeDto.MaterialMaterialize.SetFloat(ID_TIMESTAMP, Time.time);
        efeitoMaterializeDto.MaterialMaterialize.SetFloat(ID_VELOCIDADE, efeitoMaterializeDto.VelocidadeMaterializacao);
        efeitoMaterializeDto.MaterialMaterialize.SetTexture(ID_MATERIALIZE, imgMaterialize.texture);
        efeitoMaterializeDto.GoGo.transform.localScale = new Vector3(escala, escala, 0);
    }

    public void desligar()
    {
        efeitoMaterializeDto.EfeitoSpawnParticulas.gameObject.SetActive(false);
    }

    private Vector3 getPosicao(GameObject original, float haltura)
    {
        Vector3 posOriginal = original.transform.position;
        return new Vector3(posOriginal.x, haltura, posOriginal.z);
    }
}
