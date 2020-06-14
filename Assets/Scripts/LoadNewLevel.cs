using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewLevel : MonoBehaviour
{
    public int proximoLvl;

    public Animator transition;
    public float transitionTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "MainPlayer")
        {
            StartCoroutine(LoadLevel(proximoLvl));   
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("StartNewLevel");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
