using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using BackEnd;
using UnityEngine.SceneManagement;

public class NicknameButton : MonoBehaviour
{
    public TMP_InputField inputField1; // ù ��° InputField
    public TMP_InputField inputField2; // �� ��° InputField
    public Button okButton; // ��ư
    public Button reButton;
    public string nextSceneName;
    public string regiSceneName;


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
        okButton.onClick.AddListener(OnButtonClick);
        reButton.onClick.AddListener(OnButtonClick1);
        Test();
    }

    private void OnButtonClick()
    {
        try
        {
            // �� InputField�� text ���̰� ��� 0�� �ƴ��� Ȯ��
            if (inputField1.text.Length > 0 && inputField2.text.Length > 0)
            {
                // �� InputField ����� ���̰� 0�� �ƴϸ� ����� �α׸� ���
                try
                {
                    BackendLogin.Instance.CustomLogin(inputField1.text, inputField2.text); // [�߰�] �ڳ� �α���
                    SceneManager.LoadScene(nextSceneName);
                }
                catch (System.Exception)
                {
                    Debug.Log("���̵�� ��й�ȣ�� ��ġ���� �ʽ��ϴ�.");
                }

            }
            else
            {
                // �ϳ� �̻��� InputField�� ���̰� 0�� ��� ����� �α׸� ������� ����
                Debug.Log("One or both InputFields have empty text.");
            }
        }
        catch (System.Exception ex)
        {
            // ���� ó��: ���� �޽����� ����� �α׿� ���
            Debug.LogError("An error occurred: " + ex.Message);
        }
    }

    private void OnButtonClick1()
    {
        SceneManager.LoadScene(regiSceneName);
    }
}