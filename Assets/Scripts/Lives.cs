using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lives = 5;
    Text livesText;
    

    // Start is called before the first frame update
    private void LivesDisplay()
    {
        livesText.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        LivesDisplay();
        Debug.Log("difficulty current level is " + PlayerPrefsController.GetDifficulty());
    }

    public void TakeLife()
    {
        lives -= damage;
        LivesDisplay();
        if(lives <=0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
