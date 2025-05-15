using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public Transform targetPosition; // �̵� �� ���� ���ϰ� �� ��ǥ ��ġ�� ����Ű�� Transform ������Ʈ
    public float moveSpeed = 1.0f;   // �̵� �ӵ�

    private void Update()
    {
        if (targetPosition != null)
        {
            // ���� ��ġ���� ��ǥ ��ġ������ ���͸� ����մϴ�.
            Vector3 moveDirection = targetPosition.position - transform.position;

            // ���� ���ϵ��� ȸ���մϴ�.
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = targetRotation;
            }

            // �̵� �ӵ��� �ð� ������ ���Ͽ� �� �����Ӹ��� �̵��� �Ÿ��� ����մϴ�.
            float step = moveSpeed * Time.deltaTime;

            // �̵��� �Ÿ��� ���� ��ġ���� ��ǥ ��ġ������ �Ÿ����� ũ�ٸ� ��ǥ ��ġ�� �����մϴ�.
            if (moveDirection.magnitude < step)
            {
                transform.position = targetPosition.position;
            }
            else
            {
                // �� �����Ӹ��� �̵��� �Ÿ�(step)��ŭ ���� ��ġ�� �̵��մϴ�.
                transform.position += moveDirection.normalized * step;
            }
        }
    }
}