using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] Canvas towersCanvas;
    [SerializeField] Canvas upgradesCanvas;

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

}
