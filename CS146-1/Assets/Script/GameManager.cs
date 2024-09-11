using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 // Add the using directive for the namespace that contains the 'UnitCircleSlider' class

public class GameManager : MonoBehaviour
{
    public GameObject audio_manager;
    public GameObject health_slider;
    public GameObject bullet_slider;
    public GameObject player;
    public GameObject bullet;
    public Text score_text;
    public Text instruction_text;
    public Text end_text;

    private int player_bullets;
    public int max_player_bullets = 100;
    private int player_health;
    public int max_player_health = 3;
    private bool player_can_be_hit = true;
    private float last_time_hitted = -1;
    public float least_hit_interval = 0.5f;
    private float score = 0;
    private bool game_ended = false;
    public bool is_game_ended { get { return game_ended; } }
    private bool game_started = false;

    // Start is called before the first frame update
    void Start()
    {
        audio_manager.GetComponent<AudioManager>().PlayBackgroundSound();

        player_bullets = max_player_bullets;
        player_health = max_player_health;
        health_slider.GetComponent<UnitCircleSlider>().set_value(max_player_health);
        bullet_slider.GetComponent<UnitCircleSlider>().set_value(max_player_bullets);

        FindObjectOfType<ObstacleSpawner>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        end_text.enabled = false;
    }

    public void fire_bullet() 
    {
        if (player_bullets <= 0) return;

        audio_manager.GetComponent<AudioManager>().PlayShootSound();

        Vector3 bullet_offset = new Vector3(0, 0, bullet.transform.localScale.z + 0.1f);
        Instantiate(bullet, player.transform.position + bullet_offset, bullet.transform.rotation);

        bullet_slider.GetComponent<UnitCircleSlider>().value_min();
        player_bullets-=1;
    }

    public void add_bullet() {
        audio_manager.GetComponent<AudioManager>().PlayClickSound();

        if (player_bullets >= max_player_bullets) return;

        bullet_slider.GetComponent<UnitCircleSlider>().value_plus();
        player_bullets += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_can_be_hit && Time.time - last_time_hitted > least_hit_interval)
        {
            player_can_be_hit = true;
        }

        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        if (!game_started)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                game_started = true;
                ObstacleSpawner obs = FindObjectOfType<ObstacleSpawner>();
                obs.enabled = true;

                player.GetComponent<PlayerController>().enabled = true;

                instruction_text.enabled = false;
            }
            else return;
        } 

        if (game_ended)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Menu");
            }
        }

    }

    public void add_health()
    {
        audio_manager.GetComponent<AudioManager>().PlayClickSound();

        if (player_health >= max_player_health) return;

        health_slider.GetComponent<UnitCircleSlider>().value_plus();
        player_health += 1;
    }

    public void hit_obstacle()
    {
        if (!player_can_be_hit) return;

        Debug.Log("Hit obstacle");

        health_slider.GetComponent<UnitCircleSlider>().value_min();
        player_health -= 1;
        player_can_be_hit = false;
        last_time_hitted = Time.time;

        if (player_health <= 0)
        {
            game_over();
        }
    }

    public void hit_checkpoint()
    {
        Debug.Log("Hit checkpoint");
        if (game_ended) return;
        
        score++;
        score_text.text = score.ToString("0");
    }

    public void game_over()
    {   

        if (game_ended) return;

        audio_manager.GetComponent<AudioManager>().StopBackgroundSound();
        audio_manager.GetComponent<AudioManager>().PlayGameOverSound();

        Debug.Log("Game over");
        
        player.GetComponent<PlayerController>().enabled = false;
        end_text.enabled = true;
        game_ended = true;
    }

}