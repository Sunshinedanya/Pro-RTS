using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionChanger : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;
    [SerializeField] private Button _fullscreenButton;

    private int _width;
    private int _height;
    private bool _isFullScreen;

    void Start()
    {
        _dropdown = _dropdown.GetComponent<Dropdown>();

        _fullscreenButton = _fullscreenButton.GetComponent<Button>();
        _fullscreenButton.onClick.AddListener(ChangeFullscreen);
    }
    public void ChangeResolution()
    {
        print(_dropdown.value);
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
    public void ChangeFullscreen()
    {
        if (_isFullScreen)
        {
            SetFullscreen(false);
        }
        else
        {
            SetFullscreen(true);
        }
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
