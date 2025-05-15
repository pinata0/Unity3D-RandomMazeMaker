using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public Transform targetPosition; // 이동 및 얼굴을 향하게 할 목표 위치를 가리키는 Transform 컴포넌트
    public float moveSpeed = 1.0f;   // 이동 속도

    private void Update()
    {
        if (targetPosition != null)
        {
            // 현재 위치에서 목표 위치까지의 벡터를 계산합니다.
            Vector3 moveDirection = targetPosition.position - transform.position;

            // 얼굴을 향하도록 회전합니다.
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = targetRotation;
            }

            // 이동 속도와 시간 간격을 곱하여 매 프레임마다 이동할 거리를 계산합니다.
            float step = moveSpeed * Time.deltaTime;

            // 이동할 거리가 현재 위치에서 목표 위치까지의 거리보다 크다면 목표 위치로 설정합니다.
            if (moveDirection.magnitude < step)
            {
                transform.position = targetPosition.position;
            }
            else
            {
                // 매 프레임마다 이동할 거리(step)만큼 현재 위치를 이동합니다.
                transform.position += moveDirection.normalized * step;
            }
        }
    }
}