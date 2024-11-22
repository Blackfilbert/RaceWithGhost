using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoint;
    public float finishTime; //Time the player finished
    private List<TransformData> playerPositions = new List<TransformData>(); //List of player positions
    private float currentTime = 0f; //Record timer

    private LoopFinish loop;

    

    private void Start() {
        loop = GameObject.FindGameObjectWithTag("Finish").GetComponent<LoopFinish>();
    }

    private void Update() {
        if(loop.loop == 0) {
            Record(); //Recording first result
            finishTime = Time.time;
        }
        
        if(loop.loop != 0) {
            Replay(); //Replaying the player's path
        }
    }

    private void Record() {

        //Recording player movements
        if(currentTime < finishTime) {
            playerPositions.Add(new TransformData(player.position, player.rotation, currentTime));
            currentTime += Time.deltaTime;
        }
    }

    private void Replay() {
        float playbackTime = Time.time % finishTime;

        //Finding index with time > playbackTime
        int index = 0;
        while(index < playerPositions.Count && playerPositions[index].time < playbackTime) {
            index++;
        }

        //If index > 0 used previous index 
        if(index > 0) {
            index--;
            TransformData data = playerPositions[index];
            transform.position = data.position;
            transform.rotation = data.rotation;
        }
    }


    [Serializable]
    private struct TransformData {
        public Vector3 position;
        public Quaternion rotation;
        public float time;

        public TransformData(Vector3 pos, Quaternion rot, float t) {
            position = pos;
            rotation = rot;
            time = t;
        }
    }
}


