using UnityEngine;

public class MainGame : MonoBehaviour
{
    [SerializeField] ComponentesDaGarraDto componentesDaGarra;

    private Garra garra;

    void Start()
    {
        garra = new Garra(componentesDaGarra);
    }

    
    void Update()
    {
        garra.Update();
    }

    private void FixedUpdate()
    {
        garra.FixedUpdate();
    }
}
