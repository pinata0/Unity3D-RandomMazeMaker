using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{

    public TextMeshProUGUI myText;
    public CoinScript coinScript;
    public string nextSceneName;
    private bool isRunning = true;


    public string UpdateText(string newText)
    {
        // Text 요소의 텍스트 업데이트
        myText.text = newText;
        return newText;
    }

    private void Start()
    {
        StartCoroutine(DelayedAction());
    }

    private IEnumerator DelayedAction()
    {
        UpdateText("Welcome!");
        yield return new WaitForSeconds(2.0f); // 2초 동안 딜레이
        UpdateText("I'll explain you how to play this game.");
        yield return new WaitForSeconds(4.0f);
        UpdateText("You can move your character by pressing WASD keys.");
        yield return new WaitForSeconds(4.0f);
        UpdateText("You can use Dash ability by pressing shift key.");
        yield return new WaitForSeconds(4.0f);
        UpdateText("You should collect 10 coins to clear this game.");
        yield return new WaitForSeconds(4.0f);
        UpdateText("The number under this message shows how many coins you collected.");
        yield return new WaitForSeconds(4.0f);
        UpdateText("Now, let's collect 3 coins for practice!");
        yield return new WaitForSeconds(4.0f);
        UpdateText("");
    }

    private void Update()
    {
        if (isRunning)
        {
            if (coinScript.eatencoin == 3)
            {
                StartCoroutine(ClearedAction());
                isRunning = false;
            }
        }
        
    }

    private IEnumerator ClearedAction()
    {
        UpdateText("Great");
        yield return new WaitForSeconds(2.0f);
        UpdateText("Now, let's start the game.");
        yield return new WaitForSeconds(4.0f);
        UpdateText("You'll choose map that you want to play.");
        yield return new WaitForSeconds(4.0f);
        UpdateText("Notice that Horror map includes a ghost which chase you.");
        yield return new WaitForSeconds(4.0f);
        UpdateText("Good luck:).");
        yield return new WaitForSeconds(2.0f);
        UpdateText("");
        SceneManager.LoadScene(nextSceneName);
    }


}
