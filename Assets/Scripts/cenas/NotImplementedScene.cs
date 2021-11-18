using UnityEngine;
using UnityEngine.UI;

public class NotImplementedScene : MonoBehaviour
{
    [SerializeField] private Button btnVoltar;

    // Start is called before the first frame update
    void Start()
    {
        btnVoltar.onClick.AddListener(() => CenaUtils.irParaCenaMap());
    }    
}
