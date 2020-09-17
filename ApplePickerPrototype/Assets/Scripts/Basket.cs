using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collideWith = coll.gameObject;
        
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
        }

        //Parese the text of the scoreGT into an int
        int score = int.Parse(scoreGT.text);
        score += 100;
        //Convert int to string
        scoreGT.text = score.ToString();
        // track the high score
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
