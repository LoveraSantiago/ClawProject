using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class LinhaChallengeDto 
{
    [SerializeField] private Image imgEstrela;
    [SerializeField] private Text lblTextoChallenge;
    [Space(3)]
    [SerializeField] private Image img1;
    [SerializeField] private Image img2;
    [SerializeField] private Image img3;

    public Image ImgEstrela { get { return imgEstrela; } }
    public Text LblTextoChallenge { get { return lblTextoChallenge; } }

    public Image Img1 { get { return img1; } }
    public Image Img2 { get { return img2; } }
    public Image Img3 { get { return img3; } }
}
