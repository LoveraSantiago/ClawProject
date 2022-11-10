using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class TitleScene : MonoBehaviour
{
    [SerializeField] private MainTitleDto mainTitleDto;
    [Space(5)]
    [SerializeField] private Sprite garraMacho;
    [SerializeField] private Sprite garraFemea;
    [SerializeField] private Image imgGarra;
    [Space(5)]
    [SerializeField] private Material materialMacho;
    [SerializeField] private Material materialFemea;
    [SerializeField] private Image imgBackground;
    [Space(5)]
    [SerializeField] private Sprite btnVerde;
    [SerializeField] private Sprite btnRosa;
    [SerializeField] private Image imgBtnPlay;
    [Space(5)]
    [SerializeField] private Animator animator;

    private static readonly int ANIMACAO1_MACHO = Animator.StringToHash("macho-piscando");
    private static readonly int ANIMACAO1_FEMEA = Animator.StringToHash("femea-coracao");

    private Genero genero;
    private InputGame inputGame;

    private void Start()
    {
        GarraTitle garraTitle = new GarraTitle();

        genero = GeneroUtils.getGeneroDoIndice(MathUtils.escolherDeZeroAteLimite(2));        
        if(GeneroUtils.isGeneroMacho(genero))
        {
            imgGarra.sprite = garraMacho;
            imgBackground.material = materialMacho;
            imgBtnPlay.sprite = btnVerde;
        }
        else
        {
            imgGarra.sprite = garraFemea;
            imgBackground.material = materialFemea;
            imgBtnPlay.sprite = btnRosa;
        }

        inputGame = new InputGameImpl();
    }

    private void Update()
    {
        inputGame.update();
        if (inputGame.aconteceuTap())
        {
            if(GeneroUtils.isGeneroMacho(genero))
            {
                animator.Play(ANIMACAO1_MACHO);
            }
            else
            {
                animator.Play(ANIMACAO1_FEMEA);
            }
        }
    }

    public void irParaMainScene()
    {
        CenaUtils.irParaCenaMap();
    }
}
