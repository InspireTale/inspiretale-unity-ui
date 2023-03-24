using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InspireTale.UI;

public class SampleSceneUI : MonoBehaviour
{
    [SerializeField]
    private BaseGUICanvas mainCanvas;
    [SerializeField]
    private BaseGUICanvas buttonCanvas;

    // Start is called before the first frame update
    void Start()
    {
        this.mainCanvas.Show();
        this.buttonCanvas.Show();
    }

    public void ShowMainCanvas()
    {
        this.mainCanvas.Show();
    }

    public void HideMainCanvas()
    {
        this.mainCanvas.Hide();
    }
}
