using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject eventObj;
    public Button btnA;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(this.eventObj);

        btnA.onClick.AddListener(LoadSceneA);
    }

    private void LoadSceneA()
    {
        StartCoroutine(LoadScene(1));
    }

    IEnumerator LoadScene(int index)
    {
        animator.SetBool("FadeIn",true);
        animator.SetBool("FadeOut",false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadedScene;
    }

    private void OnLoadedScene(AsyncOperation obj)
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
