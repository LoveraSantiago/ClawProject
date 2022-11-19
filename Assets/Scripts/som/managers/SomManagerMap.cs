public class SomManagerMap : SomManager,
                             SomMap
{
    private AudioMapDto audioDto;

    public SomManagerMap(AudioMapDto audioDto) 
        : base(audioDto)
    {
        this.audioDto = audioDto;
    }

    public void playSomAbrirModal()
    {
        audioPlayOneShot(getAudioSourceGarra(), audioDto.AbrirModal);//PROPOSITALMENTE PEGANDO AUDIO GARRA
    }

    public void playSomClique()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.Clique);
    }

    public void playSomCliqueBalao()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.CliqueSomBalao);
    }

    public void playSomCliqueCancelar()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.CliqueSomCancelar);
    }

    public void playSomCliqueSetas()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.CliqueSomSetas);
    }

    public void playSomStart()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.SomStart);
    }

    public void playSomUiBaloesLevel()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.BumpBaloesLevels);
    }
}
