public class SomManagerMap : SomManager
{
    private AudioMapDto audioDto;

    public SomManagerMap(AudioMapDto audioDto) 
        : base(audioDto)
    {
        this.audioDto = audioDto;
    }

    public void playSomBaloesLevel()
    {
        audioPlayOneShot(getAudioSource(1), audioDto.BumpBaloesLevels);
    }
}
