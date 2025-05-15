using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using BackEnd;
using UnityEngine.SceneManagement;

public class RegisterButton : MonoBehaviour
{
    public TMP_InputField inputField1; // 첫 번째 InputField
    public TMP_InputField inputField2; // 두 번째 InputField
    public TMP_InputField inputField3; // 세 번째 InputField
    public Button okButton; // 버튼
    public string nextSceneName;


    private void Start()
    {

        // 버튼 클릭 이벤트에 리스너 추가
        okButton.onClick.AddListener(OnButtonClick);

    }

    private void OnButtonClick()
    {

        try
        {
            // 두 InputField의 text 길이가 모두 0이 아닌지 확인
            if (inputField1.text.Length > 0 && inputField2.text.Length > 0 && inputField2.text == inputField3.text)
            {
                try
                {
                    // 두 InputField 모두의 길이가 0이 아니면 디버그 로그를 출력
                    BackendLogin.Instance.CustomSignUp(inputField1.text, inputField2.text); //231101 여기서 문제가 일어남

                    SceneManager.LoadScene(nextSceneName); //231101 얜 문제 없음
                }
                catch (System.Exception)
                {
                    Debug.Log("이 아이디를 가진 누군가가 있나봅니다.");
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

}