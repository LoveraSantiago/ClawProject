using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ElevadorDto 
{
    [SerializeField] private float alturaSubida;
    [SerializeField] private float posBaixo;
    [SerializeField] private float velocidadeSubida;
    [Space(3)]
    [SerializeField] private GameObject paredeHorizontal1;
    [SerializeField] private GameObject paredeHorizontal2;

    public float AlturaSubida { get { return alturaSubida; } }
    public float PosBaixo { get { return posBaixo; } }
    public float VelocidadeSubida { get { return velocidadeSubida; } }

    public GameObject ParedeHorizontal1 { get { return paredeHorizontal1; } }
    public GameObject ParedeHorizontal2 { get { return paredeHorizontal2; } }

}
