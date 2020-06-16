using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitAnimation : MonoBehaviour
{
	int currentSceneIndex;
	public Animator transition;
	public GameObject panel;

	void Awake(){
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (!StaticSettings.GAME_JUST_LOADED){
			panel.SetActive(false);
		}
	}


    // Start is called before the first frame update
    void Start()
    {
    	
        if (StaticSettings.GAME_JUST_LOADED){
        	StaticSettings.GAME_JUST_LOADED = false;
			loadInitAnimation();
		}
		
    }

    void Update(){

    }

    void loadInitAnimation(){
    	StartCoroutine(initAnimation());
    }

    IEnumerator initAnimation(){
    	transition.SetTrigger("startAnim");
    	yield return new WaitForSeconds(5.5f);
    	panel.SetActive(false);
    }
}
