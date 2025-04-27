using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Image sceneLoadAnimation;
    [SerializeField]
    private float animSpeed;

    [SerializeField]
    public GameObject backgroundMusicGameObject;

    [SerializeField]
    GameObject tutorialWindow;
    
    void Start()
    {
        DontDestroyOnLoad(backgroundMusicGameObject);
        StartCoroutine(StartGameAnimation());
    }

    void Update()
    {
        
    }


    public void StartGame()
    {
        print("test");
        StartCoroutine(ClosingSceneAnimation());
    }

    IEnumerator StartGameAnimation()
    {
        var imageTransparent = sceneLoadAnimation.color.a;
        while (imageTransparent > 0)
        {
            imageTransparent -= animSpeed * Time.deltaTime;
            sceneLoadAnimation.color = new Color(sceneLoadAnimation.color.r, sceneLoadAnimation.color.g, sceneLoadAnimation.color.b, imageTransparent);
            yield return null; // ∆дЄм следующего кадра
        }
    }

    IEnumerator ClosingSceneAnimation()
    {
        var imageTransparent = sceneLoadAnimation.color.a;
        while (imageTransparent < 1)
        {
            imageTransparent += animSpeed * Time.deltaTime;
            print(imageTransparent);
            sceneLoadAnimation.color = new Color(sceneLoadAnimation.color.r, sceneLoadAnimation.color.g, sceneLoadAnimation.color.b, imageTransparent);
            yield return null; // ∆дЄм следующего кадра
        }
        SceneManager.LoadScene("SceneLeha");
    }

    public void OpenTutorial()
    {
        tutorialWindow.active = true;
    }
}
