using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Howtoplaybutton : MonoBehaviour
{
    public GameObject tutorialPanel;
    void Start() {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick() {
        tutorialPanel.SetActive(true);
    }
}
