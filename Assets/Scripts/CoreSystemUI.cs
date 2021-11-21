using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreSystemUI : MonoBehaviour
{
    public static CoreSystemUI instance;
    private GameObject _winPanel;
    private GameObject _lostPanel;

    private void Awake()
    {
        instance = this;
        _winPanel = transform.GetChild(0).gameObject;
        _lostPanel = transform.GetChild(1).gameObject;
    }

    ///<summary>Set final UI panel game state. True - win, False - lost</summary>
    public void SetGameCoreState(bool isGameCompleted)
    {
        if(isGameCompleted == true)
        {
            _winPanel.SetActive(true);
            _lostPanel.SetActive(false);
        }
        else
        {
            _winPanel.SetActive(false);
            _lostPanel.SetActive(true);
        }
    }

    #region  UIButton
    ///<summary>Restarts current game level</summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

}
