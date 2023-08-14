using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerMov : MonoBehaviour
{

    public InputControl input;
    private Material init;
    public Material GhostMat;

    public GameObject Lose, Win;

    public GameObject Button;

    public GameObject scorepanel;

    int score = 0;

    void Start()
    {
        init = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
        Time.timeScale = 1;
        //game start
    }

    void Update()
    {
        //This Just Updates score panel
        scorepanel.GetComponentInChildren<TextMeshProUGUI>().text = "Score: " + score;
    }

    void OnTriggerEnter(Collider other)
    {
        //Collision tags 
        //TODO: Switch Case
        if (other.gameObject.tag == "SpeedUp")
        {
            StartCoroutine(SpeedUp());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Ghost")
        {
            StartCoroutine(Ghost());
            Destroy(other.gameObject);
        }
        else if (other.tag == "Obstacle")
        {
            Time.timeScale = 0;
            Button.SetActive(true);
            Lose.SetActive(true);

            scorepanel.SetActive(true);
        }
        else if (other.tag == "Coin")
        {
            score++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Finish")
        {
            Time.timeScale = 0;
            Button.SetActive(true);
            Win.SetActive(true);
            scorepanel.SetActive(true);
        }

    }
    IEnumerator SpeedUp()
    {
        //SpeedUp function
        input.speed *= 2;
        yield return new WaitForSeconds(2f);
        input.speed /= 2;

    }
    IEnumerator Ghost()
    {
        //Ghost function
        GetComponent<Collider>().isTrigger = false;
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = GhostMat;
        yield return new WaitForSeconds(2f);
        GetComponent<Collider>().isTrigger = true;
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = init;
    }
}
