using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] Canvas towersCanvas;
    [SerializeField] Canvas upgradesCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas menuCanvas;
    [SerializeField] Canvas waveAndLifeCanvas;

    public void EnableUpgrading()
    {
        towersCanvas.gameObject.SetActive(false);
        upgradesCanvas.gameObject.SetActive(true);
    }

    public void EnableBuying()
    {
        towersCanvas.gameObject.SetActive(true);
        upgradesCanvas.gameObject.SetActive(false);
    }

    public void EnableGameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        menuCanvas.gameObject.SetActive(false);
        towersCanvas.gameObject.SetActive(false);
        upgradesCanvas.gameObject.SetActive(false);
        waveAndLifeCanvas.gameObject.SetActive(false);
    }

}
