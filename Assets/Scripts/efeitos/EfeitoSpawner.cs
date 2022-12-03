using UnityEngine;

public class EfeitoSpawner 
{
    public void spawnPowerUp(ParticleSystem efeitoSpawn, Material materialMaterialize)
    {
        efeitoSpawn.gameObject.SetActive(true);
        efeitoSpawn.Play();
    }
}
