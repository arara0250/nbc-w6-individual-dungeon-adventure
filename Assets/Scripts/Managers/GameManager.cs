using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private PlayerManager _playerManager;
    public PlayerManager PlayerManager
    {
        get
        {
            if (_playerManager == null)
            {
                _playerManager = new GameObject("PlayerManager").AddComponent<PlayerManager>();
                _playerManager.transform.parent = transform;
            }
            return _playerManager;
        }
        set { _playerManager = value; }
    }

    private UIManager _uiManager;
    public UIManager UIManager
    {
        get
        {
            if (_uiManager == null)
            {
                _uiManager = new GameObject("UIManager").AddComponent<UIManager>();
                _uiManager.transform.parent = transform;
            }
            return _uiManager;
        }
        set { _uiManager = value; }
    }


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
