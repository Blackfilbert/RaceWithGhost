using System.Collections;
using System.Collections.Generic;
using Ashsvp;
using UnityEngine;

public class LoopFinish : MonoBehaviour
{
    private int loopNumber = 0;
    public float bestTime; //TODO: add best time for ghost
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject startButton;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            other.transform.position = spawnPoint.transform.position; //return Player to spawn position
            loopNumber++;

            startButton.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public int loop {
        get { return loopNumber; }
    }
}
