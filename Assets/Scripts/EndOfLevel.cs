﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour {

    // Variable to interface with game master
    private GameMaster GM;
    // Variable to reference the winner
    private Player winner;

    void Start() {
        // Hook to the game master for communication
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        // Raycast up from the end marker to see who wins
        // Uses the postion of the object placed, goes up beyond the bounds of the screen,
        // and ignores everything but the objects on the player level
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 10f, 1 << LayerMask.NameToLayer("Players"));

        // If a player hit the finish
        if(hit.collider != null) {
            // Determine that the player that hit, i.e. the first player to hit
            // should be the winner
            winner = hit.collider.GetComponent<Player>();
            // Tell the game master who the winner is
            GM.SetWinner(winner.number);

            SceneManager.LoadScene("Winner");
        }

    }
}
