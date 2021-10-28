using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotoesLigaDesligaDto
{
    [SerializeField] private GameObject goBtnBordas;
    [SerializeField] private GameObject goBtnOnOff;

    public GameObject GoBtnBordas { get { return goBtnBordas; } }
    public GameObject GoBtnOnOff { get { return goBtnOnOff; } }

}
