using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text score_text;
    private int player_health = 3;
    private float spawn_time = 0;
    private float score = 0;
    private bool game_ended = false;

    // Start is called before the first frame update
    void Start()
    {
        spawn_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (game_ended) return;

        score = Time.time - spawn_time;
        score_text.text = score.ToString("F1");
    }

    public void hit_obstacle()
    {
        Debug.Log("Hit obstacle");

        player_health -= 1;

        if (player_health <= 0)
        {
            game_over();
        }
    }

    public void game_over()
    {   

        if (game_ended) return;

        Debug.Log("Game over");
        player.GetComponent<PlayerController>().enabled = false;
        game_ended = true;
    }
}