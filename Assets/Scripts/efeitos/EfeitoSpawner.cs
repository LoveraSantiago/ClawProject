using UnityEngine;

public class EfeitoSpawner 
{
    private static readonly int ID_TIMESTAMP = Shader.PropertyToID("_timestamp");

    public void spawnPowerUp(ParticleSystem efeitoSpawn, Material materialMaterialize, float haltura)
    {
        efeitoSpawn.gameObject.SetActive(true);
        efeitoSpawn.Play();        
        efeitoSpawn.transform.position = new Vector3(efeitoSpawn.transform.position.x, haltura, efeitoSpawn.transform.position.z);
        materialMaterialize.SetFloat(ID_TIMESTAMP, Time.time);
    }
}
