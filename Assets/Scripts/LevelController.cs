using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLable;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject loseLable;

    private void Start()
    {
        winLable.SetActive(false);
        loseLable.SetActive(false);

    }

    public void HandleLoseCondition()
    {
        loseLable.SetActive(true);
        Time.timeScale = 0;
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++; 
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <=0 &&levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    IEnumerator HandleWinCondition()
    {
        winLable.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<GameLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
