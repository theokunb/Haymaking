using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    private StepSoundService stepSoundService;
    private SoundService soundService;

    private void Start()
    {
        stepSoundService = ServiceLocator.Instance.GetService<StepSoundService>();
        soundService = ServiceLocator.Instance.GetService<SoundService>();
    }

    public void PlayStep()
    {
        if(stepSoundService.StepSounds.Length == 0)
        {
            Debug.Log("no step sounds");
            return;
        }

        var index = Random.Range(0, stepSoundService.StepSounds.Length);
        soundService.PlaySound(stepSoundService.StepSounds[index]);
    }
}
