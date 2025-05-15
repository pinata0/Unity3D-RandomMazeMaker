using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using BackEnd;
using UnityEngine.SceneManagement;

public class RegisterButton : MonoBehaviour
{
    public TMP_InputField inputField1; // ù ��° InputField
    public TMP_InputField inputField2; // �� ��° InputField
    public TMP_InputField inputField3; // �� ��° InputField
    public Button okButton; // ��ư
    public string nextSceneName;


    private void Start()
    {

        // ��ư Ŭ�� �̺�Ʈ�� ������ �߰�
        okButton.onClick.AddListener(OnButtonClick);

    }

    private void OnButtonClick()
    {

        try
        {
            // �� InputField�� text ���̰� ��� 0�� �ƴ��� Ȯ��
            if (inputField1.text.Length > 0 && inputField2.text.Length > 0 && inputField2.text == inputField3.text)
            {
                try
                {
                    // �� InputField ����� ���̰� 0�� �ƴϸ� ����� �α׸� ���
                    BackendLogin.Instance.CustomSignUp(inputField1.text, inputField2.text); //231101 ���⼭ ������ �Ͼ

                    SceneManager.LoadScene(nextSceneName); //231101 �� ���� ����
                }
                catch (System.Exception)
                {
                    Debug.Log("�� ���̵� ���� �������� �ֳ����ϴ�.");
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

}