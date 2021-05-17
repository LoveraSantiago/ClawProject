using UnityEngine;

public class SingleCompLineRendererColorivel : ComponenteColorivel
{
    private GameObject go;

    private LineRenderer lineRenderer;
    private Color corOriginal;

    public SingleCompLineRendererColorivel(GameObject go)
    {
        this.go = go;
        lineRenderer = go.GetComponent<LineRenderer>();
        corOriginal = lineRenderer.startColor;
    }

    public void resetCor()
    {
        lineRenderer.startColor = corOriginal;
        lineRenderer.endColor = corOriginal;
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
}
