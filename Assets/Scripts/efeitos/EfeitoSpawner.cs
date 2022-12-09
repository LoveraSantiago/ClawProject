using UnityEngine;

public class EfeitoSpawner 
{
    private static readonly int ID_TIMESTAMP   = Shader.PropertyToID("_timestamp");
    private static readonly int ID_VELOCIDADE  = Shader.PropertyToID("_velocidade");
    private static readonly int ID_MATERIALIZE = Shader.PropertyToID("_imgMaterialize");

    public void spawnPowerUp(EfeitoMaterializeDto efeitoMaterializeDto, Sprite imgMaterialize, float haltura)
    {
        efeitoMaterializeDto.EfeitoSpawnParticulas.gameObject.SetActive(true);
        efeitoMaterializeDto.EfeitoSpawnParticulas.Play();
        efeitoMaterializeDto.EfeitoSpawnParticulas.transform.position = getPosicao(efeitoMaterializeDto.EfeitoSpawnParticulas.gameObject, haltura);
        efeitoMaterializeDto.MaterialMaterialize.SetFloat(ID_TIMESTAMP, Time.time);
        efeitoMaterializeDto.MaterialMaterialize.SetFloat(ID_VELOCIDADE, efeitoMaterializeDto.VelocidadeMaterializacao);
        efeitoMaterializeDto.MaterialMaterialize.SetTexture(ID_MATERIALIZE, imgMaterialize.texture);
    }

    public void desligar(EfeitoMaterializeDto efeitoMaterializeDto)
    {
        efeitoMaterializeDto.EfeitoSpawnParticulas.gameObject.SetActive(false);
    }

    private Vector3 getPosicao(GameObject original, float haltura)
    {
        Vector3 posOriginal = original.transform.position;
        return new Vector3(posOriginal.x, haltura, posOriginal.z);
    }
}
