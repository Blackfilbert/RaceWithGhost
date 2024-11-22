using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text lapText;
    [SerializeField] private GameObject startButton;

    private LoopFinish loop;

    private void Start() {
        Time.timeScale = 0f;
        loop = loop = GameObject.FindGameObjectWithTag("Finish").GetComponent<LoopFinish>();
    }

    private void Update() {
        lapText.text = "Lap: " + loop.loop;
    }

    public void StartButtonPressed() {
        startButton.SetActive(false);
        Time.timeScale = 1f;
    }
}
