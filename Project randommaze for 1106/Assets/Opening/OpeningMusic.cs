using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System.Text;
using System.Threading.Tasks;

public class OpeningMusic : MonoBehaviour
{

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource ������Ʈ�� ã�� �� �����ϴ�.");
        }

    }

    private void Update()
    {
        // ���� ���, �����̽��ٸ� ������ ���� ���/�Ͻ����� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // ��� ���� ������ �Ͻ� ����
            }
            else
            {
                audioSource.Play(); // ���� ���
            }
        }
    }
}
