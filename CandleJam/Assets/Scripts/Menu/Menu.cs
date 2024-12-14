
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button m_playButton;
    [SerializeField] Button m_audioButton;
    [SerializeField] Button m_exitButton;
    [SerializeField] GameObject m_audio;
    [SerializeField] KeyController m_keyController;

    private void Awake()
    {
        m_playButton.onClick.AddListener(OnPlayClick);
        m_audioButton.onClick.AddListener(OnAudioClick);
        m_exitButton.onClick.AddListener(OnExitClick);
    }

    private void OnPlayClick()
    {
        gameObject.SetActive(false);
        m_keyController.isOpenedMenu = false;

    }

    private void OnAudioClick()
    {
        m_audio.gameObject.SetActive(true);
    }

    private void OnExitClick()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
} 
