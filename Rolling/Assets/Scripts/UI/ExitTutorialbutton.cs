using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitTutorialbutton : MonoBehaviour
{
    public GameObject tutorialPanel;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    
    void OnClick()
    {
        tutorialPanel.GetComponent<Animator>().SetBool("exit", true);
    }
}
