using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _systems;
    [SerializeField] private GameObject _HPCanvas;
    [SerializeField] private GameObject _CurrencyCanvas;
    [SerializeField] private GameObject _ShopUI;
    [SerializeField] private GameObject _EndGameCanvas;
    [SerializeField] private GameObject _StartGameCanvas;


    private void Awake()
    {
        _player.SetActive(false);
        _systems.SetActive(false);
        _CurrencyCanvas.SetActive(false);
        _HPCanvas.SetActive(false);
        _ShopUI.SetActive(false);
        _StartGameCanvas.SetActive(true);
    }

    public void StartGame()
    {
        _player.SetActive(true);
        _systems.SetActive(true);
        _CurrencyCanvas.SetActive(true);
        _HPCanvas.SetActive(true);
        _EndGameCanvas.SetActive(false);
        _StartGameCanvas.SetActive(false);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
