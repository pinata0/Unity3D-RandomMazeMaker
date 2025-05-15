using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using BackEnd;
using UnityEngine.SceneManagement;

public class ChooseButton : MonoBehaviour
{

    public Button map1; // 버튼
    public Button map2;
    public string SceneName1;
    public string SceneName2;


    async void Test()
    {
        await Task.Run(() => {

            Debug.Log("테스트를 종료합니다.");
        });
    }
    private void Start()
    {
        var bro = Backend.Initialize(true);

        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro);
        }
        else
        {
            Debug.LogError("초기화 실패 : ");
        }
        // 버튼 클릭 이벤트에 리스너 추가
        map1.onClick.AddListener(Map1);
        map2.onClick.AddListener(Map2);

    }

    private void Map1()
    {
        SceneManager.LoadScene(SceneName1);
    }

    private void Map2()
    {
        SceneManager.LoadScene(SceneName2);
    }
}