using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanel : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string SfxVolume = nameof(SfxVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const int LogMultiplier = 20;
    private const int MinDB = -80;
    private const int MaxDB = 0;

    [SerializeField] private AudioMixerGroup _mixer;

    public void ToggleMasterVolume(bool value)
    {
        if (value)
            _mixer.audioMixer.SetFloat(MasterVolume, MaxDB);
        else
            _mixer.audioMixer.SetFloat(MasterVolume, MinDB);

    }

    public void ChangeMasterVolume(float value)
    {
        _mixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(value) * LogMultiplier);
    }

    public void ChangeSfxVolume(float value)
    {
        _mixer.audioMixer.SetFloat(SfxVolume, Mathf.Log10(value) * LogMultiplier);
    }

    public void ChangeBackgroundMusicVolume(float value)
    {
        _mixer.audioMixer.SetFloat(MusicVolume, Mathf.Log10(value) * LogMultiplier);
    }
}
