using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using BackEnd;
using UnityEngine.SceneManagement;

public class NicknameButton : MonoBehaviour
{
    public TMP_InputField inputField1; // 첫 번째 InputField
    public TMP_InputField inputField2; // 두 번째 InputField
    public Button okButton; // 버튼
    public Button reButton;
    public string nextSceneName;
    public string regiSceneName;


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
        okButton.onClick.AddListener(OnButtonClick);
        reButton.onClick.AddListener(OnButtonClick1);
        Test();
    }

    private void OnButtonClick()
    {
        try
        {
            // 두 InputField의 text 길이가 모두 0이 아닌지 확인
            if (inputField1.text.Length > 0 && inputField2.text.Length > 0)
            {
                // 두 InputField 모두의 길이가 0이 아니면 디버그 로그를 출력
                try
                {
                    BackendLogin.Instance.CustomLogin(inputField1.text, inputField2.text); // [추가] 뒤끝 로그인
                    SceneManager.LoadScene(nextSceneName);
                }
                catch (System.Exception)
                {
                    Debug.Log("아이디와 비밀번호가 일치하지 않습니다.");
                }

            }
            else
            {
                // 하나 이상의 InputField의 길이가 0인 경우 디버그 로그를 출력하지 않음
                Debug.Log("One or both InputFields have empty text.");
            }
        }
        catch (System.Exception ex)
        {
            // 예외 처리: 오류 메시지를 디버그 로그에 출력
            Debug.LogError("An error occurred: " + ex.Message);
        }
    }

    private void OnButtonClick1()
    {
        SceneManager.LoadScene(regiSceneName);
    }
}