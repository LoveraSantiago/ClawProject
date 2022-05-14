using UnityEngine;

public class SingleCompLineRendererColorivel : ComponenteColorivel
{
    private GameObject go;
    private LineRenderer lineRenderer;

    public SingleCompLineRendererColorivel(GameObject go)
    {
        this.go = go;
        lineRenderer = go.GetComponent<LineRenderer>();
    }

    public void passarCor(Color cor)
    {
        lineRenderer.startColor = cor;
        lineRenderer.endColor = cor;
    }

    public GameObject getGo()
    {
        return go;
    }

    public Color getCor()
    {
        return lineRenderer.startColor;
    }
}
