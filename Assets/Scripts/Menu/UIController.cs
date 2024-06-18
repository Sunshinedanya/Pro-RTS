using System.Collections. Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private MapConfig _mapConfig;

    public MapConfig mapConfig => _mapConfig;

    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _settingsBtn;
    [SerializeField] private Button _exitGameBtn;

    [SerializeField] private Button[] _closeBtns;

    [SerializeField] private TMP_Dropdown _windowSizeDropdown;
    [SerializeField] private Button _windowModeBtn;
    [SerializeField] private Button _soundsAndMusicBtn;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Button _exitBtn; // выход
    [SerializeField] private Button _saveBtn;

    [SerializeField] private TMP_Dropdown _enemiesCountDropdown;
    [SerializeField] private GameObject _enemyPanel;
    private List<GameObject> _enemyPanels = new List<GameObject>();
    private Color _playerColor = Color.red;
    [SerializeField] private RectTransform _enemyPanelsParent;
    [SerializeField] private TMP_InputField _playerNameInputField;
    [SerializeField] private Button _playerColorBtn;
    [SerializeField] private TMP_Dropdown _difficultyDropdown;
    [SerializeField] private TMP_InputField _mapSizeInputField;
    [SerializeField] private Button _startGameBtn;

    [SerializeField] private RectTransform _contentOfScrollView;

    [SerializeField] private GameObject _gameSettingsPanel;
    [SerializeField] private GameObject _settingsPanel;

    // isOn
    [SerializeField] private TMP_Text _windowModeText;
    [SerializeField] private TMP_Text _soundsAndMusicText;

    [SerializeField] private GameObject _windowModeOn;
    [SerializeField] private GameObject _windowModeOff;

    [SerializeField] private GameObject _soundsAndMusicOn;
    [SerializeField] private GameObject _soundsAndMusicOff;

    private void Start()
    {
        _mapConfig = Resources.Load<MapConfig>("MapConfig");

        _windowModeText.text = "OFF";
        _windowModeOn.SetActive(false);
        _windowModeOff.SetActive(true);

        _soundsAndMusicText.text = "ON";
        _soundsAndMusicOn.SetActive(true);
        _soundsAndMusicOff.SetActive(false);


        _settingsBtn.onClick.AddListener(() =>
        {
            _settingsPanel.SetActive(true);
        });

        _exitGameBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        foreach (var btn in _closeBtns)
        {
            btn.onClick.AddListener(() =>
            {
                _gameSettingsPanel.SetActive(false);
                _settingsPanel.SetActive(false);
            });
        }

        _windowModeBtn.onClick.AddListener(() =>
        {
            if (_windowModeText.text == "ON")
            {
                _windowModeText.text = "OFF";
                _windowModeOn.SetActive(false);
                _windowModeOff.SetActive(true);
            }
            else
            {
                _windowModeText.text = "ON";
                _windowModeOn.SetActive(true);
                _windowModeOff.SetActive(false);
            }
        });

        _soundsAndMusicBtn.onClick.AddListener(() =>
        {
            if (_soundsAndMusicText.text == "ON")
            {
                _soundsAndMusicText.text = "OFF";
                _soundsAndMusicOn.SetActive(false);
                _soundsAndMusicOff.SetActive(true);
            }
            else
            {
                _soundsAndMusicText.text = "ON";
                _soundsAndMusicOn.SetActive(true);
                _soundsAndMusicOff.SetActive(false);
            }
        });

        _saveBtn.onClick.AddListener(() =>
        {
            if (_windowModeText.text == "ON")
            {
                Screen.fullScreen = false;
                Debug.Log(_windowSizeDropdown.captionText.text);
                int sizeX = int.Parse(_windowSizeDropdown.captionText.text.Split(':')[0]);
                int sizeY = int.Parse(_windowSizeDropdown.captionText.text.Split(':')[1]);
                Screen.SetResolution(sizeX, sizeY, false);
            }
            else
            {
                Screen.fullScreen = true;
            }

            /*
             * 
             * Потом добавить настройки музыки
             * 
             */

        });

        _playerColorBtn.onClick.AddListener(() =>
        {
            _playerColor = ChangeColorOnButton(_playerColor);
            _playerColorBtn.GetComponent<Image>().color = _playerColor;
        });

        _startGameBtn.onClick.AddListener(() =>
        {
            for (int i = 0; i < _enemyPanels.Count; i++)
            {
                for (int j = 0; j < _enemyPanels.Count; j++)
                {
                    if (_enemyPanels[i].transform.GetChild(0).GetComponent<TMP_InputField>().text ==
                        _enemyPanels[j].transform.GetChild(0).GetComponent<TMP_InputField>().text &&
                        i != j)
                    {
                        return; // names are not unique
                    }
                }
            }

            if (float.Parse(_mapSizeInputField.text) < 2500 || float.Parse(_mapSizeInputField.text) > 10000) // map size is not in range [2500; 10000]
                return;

            _mapConfig.enemyCount = int.Parse(_enemiesCountDropdown.captionText.text);
            foreach (var enemy in _enemyPanels)
            {
                Enemy enemyStruct = new Enemy();
                enemyStruct.name = enemy.transform.GetChild(0).GetComponent<TMP_InputField>().text;
                enemyStruct.color = enemy.transform.GetChild(1).GetComponent<Image>().color;

                _mapConfig.enemies.Add(enemyStruct);
            }
            Player player = new Player();
            player.name = _playerNameInputField.text;
            player.color = _playerColor;
            _mapConfig.player = player;
            _mapConfig.difficulty = _difficultyDropdown.captionText.text;
            _mapConfig.mapSize = float.Parse(_mapSizeInputField.text);

            SceneManager.LoadScene(1);
        });
    }

    private void Update()
    {
        while (_enemyPanels.Count < int.Parse(_enemiesCountDropdown.captionText.text))
        {
            GameObject enemyPanel = Instantiate(_enemyPanel, Vector2.zero, Quaternion.identity, _enemyPanelsParent);
            enemyPanel.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
            {
                enemyPanel.transform.GetChild(1).GetComponent<Image>().color = ChangeColorOnButton(enemyPanel.transform.GetChild(1).GetComponent<Image>().color);
            });
            _enemyPanels.Add(enemyPanel);
        }
        while (_enemyPanels.Count > int.Parse(_enemiesCountDropdown.captionText.text))
        {
            GameObject obj = _enemyPanels[_enemyPanels.Count - 1];
            _enemyPanels.Remove(obj);
            Destroy(obj);
        }

        _enemyPanelsParent.sizeDelta = new Vector2(_enemyPanelsParent.rect.width, (_enemyPanels.Count * 75) + ((_enemyPanels.Count - 1) * 10));
        _contentOfScrollView.sizeDelta = new Vector2(0, ((4 + _enemyPanels.Count) * 75) + ((3 + _enemyPanels.Count) * 10));

        for (int i = 0; i < _enemyPanels.Count; i++)
        {
            bool isUniqueName = true;
            for (int j = 0; j < _enemyPanels.Count; j++)
            {
                if (_enemyPanels[i].transform.GetChild(0).GetComponent<TMP_InputField>().text ==
                    _enemyPanels[j].transform.GetChild(0).GetComponent<TMP_InputField>().text &&
                    i != j)
                {
                    isUniqueName = false;
                    _enemyPanels[i].transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<TMP_Text>().color = Color.red;
                    _enemyPanels[j].transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<TMP_Text>().color = Color.red;
                }
            }
            if (isUniqueName)
            {
                try
                {
                    _enemyPanels[i].transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<TMP_Text>().color = Color.white;
                }
                catch (System.Exception)
                {
                    
                }
            }
        }
    }

    private Color ChangeColorOnButton(Color currentColor)
    {
        if (currentColor == Color.red) return Color.blue;
        else if (currentColor == Color.blue) return Color.green;
        else if (currentColor == Color.green) return Color.cyan;
        else if (currentColor == Color.cyan) return Color.white;
        else if (currentColor == Color.white) return Color.black;
        else if (currentColor == Color.black) return Color.yellow;
        else if (currentColor == Color.yellow) return Color.gray;
        else return Color.red;
    }
}
