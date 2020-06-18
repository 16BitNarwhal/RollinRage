using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    void Start() {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
