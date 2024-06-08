using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionChanger : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;
    [SerializeField] private Toggle _fullscreenToggle;

    private int _width;
    private int _height;
    private bool _isFullScreen;

    void Start()
    {
        _dropdown = _dropdown.GetComponent<Dropdown>();

        _fullscreenToggle = _fullscreenToggle.GetComponent<Toggle>();
        _fullscreenToggle.onValueChanged.AddListener(ChangeFullscreen);
    }
    public void ChangeResolution()
    {
        switch (_dropdown.value)
        {
            case 0:
                SetResolution(1280, 720);
                break;
            case 1:
                SetResolution(1366, 768);
                break;
            case 2:
                SetResolution(1600, 900);
                break;
            case 3:
                SetResolution(1920, 1080);
                break;
        }
    }
    public void ChangeFullscreen(bool fullscreen)
    {
        SetFullscreen(fullscreen);
    }
    private void SetResolution(int width, int height)
    {
        _width = width;
        _height = height;
        Screen.SetResolution(width, height, _isFullScreen);
    }
    private void SetFullscreen(bool isFullScreen)
    {
        _isFullScreen = isFullScreen;
        Screen.SetResolution(_width, _height, isFullScreen);
    }
    public (int width, int height, bool fullscreen) GetConfig()
    {
        return (_width, _height, _isFullScreen);
    }
    public void SetConfig((int width, int height, bool fullscreen) config)
    {
        SetResolution(config.width, config.height);
        SetFullscreen(config.fullscreen);
    }
}
