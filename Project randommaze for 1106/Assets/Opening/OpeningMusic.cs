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
            Debug.LogError("AudioSource 컴포넌트를 찾을 수 없습니다.");
        }

    }

    private void Update()
    {
        // 예를 들어, 스페이스바를 누르면 음악 재생/일시정지 토글
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // 재생 중인 음악을 일시 정지
            }
            else
            {
                audioSource.Play(); // 음악 재생
            }
        }
    }
}
