using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using BackEnd;
using UnityEngine.SceneManagement;

public class ChooseButton : MonoBehaviour
{

    public Button map1; // ��ư
    public Button map2;
    public string SceneName1;
    public string SceneName2;


    async void Test()
    {
        await Task.Run(() => {

            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }
    private void Start()
    {
        var bro = Backend.Initialize(true);

        if (bro.IsSuccess())
        {
            Debug.Log("�ʱ�ȭ ���� : " + bro);
        }
        else
        {
            Debug.LogError("�ʱ�ȭ ���� : ");
        }
        // ��ư Ŭ�� �̺�Ʈ�� ������ �߰�
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