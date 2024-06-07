using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Button _muteButton;

    private float _volumeLevel;
    private bool _mute;

    private void Start()
    {
        _muteButton = _muteButton.GetComponent<Button>();
        _muteButton.onClick.AddListener(Mute);

        _volumeSlider = _volumeSlider.GetComponent<Slider>();
        _volumeSlider.onValueChanged.AddListener(SetVolume);
    }
    public void SetVolume(float volume)
    {
        _volumeLevel = volume;
        _audioSource.volume = volume;
    }
    public void Mute()
    {
        if (_mute)
        {
            _mute = false;
            _audioSource.mute = false;
        }
        else
        {
            _mute = true;
            _audioSource.mute = true;
        }
    }
    public (float volume,bool mute) GetConfig()
    {
        return (_volumeLevel, _mute);
    }
    public void SetConfig((float volume, bool mute) config)
    {
        SetVolume(config.volume);
        _audioSource.mute = config.mute;
    }
}