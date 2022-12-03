using UnityEngine;

public class EfeitoSpawner 
{
    private static readonly int ID_TIMESTAMP = Shader.PropertyToID("_timestamp");

    public void spawnPowerUp(EfeitoMaterializeDto efeitoMaterializeDto, float haltura)
    {
        efeitoMaterializeDto.EfeitoSpawnParticulas.gameObject.SetActive(true);
        efeitoMaterializeDto.EfeitoSpawnParticulas.Play();
        efeitoMaterializeDto.EfeitoSpawnParticulas.transform.position = getPosicao(efeitoMaterializeDto.EfeitoSpawnParticulas.gameObject, haltura);
        efeitoMaterializeDto.MaterialMaterialize.SetFloat(ID_TIMESTAMP, Time.time);
    }

    private Vector3 getPosicao(GameObject original, float haltura)
    {
        Vector3 posOriginal = original.transform.position;
        return new Vector3(posOriginal.x, haltura, posOriginal.z);
    }
}
