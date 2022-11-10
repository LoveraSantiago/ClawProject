using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class TitleScene : MonoBehaviour
{
    [SerializeField] private Sprite garraMacho;
    [SerializeField] private Sprite garraFemea;
    [SerializeField] private Sprite garraFaceMacho;
    [SerializeField] private Sprite garraFaceFemea;
    [SerializeField] private Image imgGarra;
    [SerializeField] private Image imgFace;
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

    private int generoResult;
    private InputGame inputGame;

    private void Start()
    {
        generoResult = MathUtils.escolherDeZeroAteLimite(2);        
        if(generoResult == 0)
        {
            imgGarra.sprite = garraMacho;
            imgFace.sprite = garraFaceMacho;
            imgBackground.material = materialMacho;
            imgBtnPlay.sprite = btnVerde;
        }
        else
        {
            imgGarra.sprite = garraFemea;
            imgFace.sprite = garraFaceFemea;
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
            if(generoResult == 0)
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
