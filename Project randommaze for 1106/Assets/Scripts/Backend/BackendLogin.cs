using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// �ڳ� SDK namespace �߰�
using BackEnd;

public class BackendLogin
{
    private static BackendLogin _instance = null;
    private BackendGameData backendGameData;

    public static BackendLogin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendLogin();
            }

            return _instance;
        }
    }

    public void CustomSignUp(string id, string pw)
    {
        Debug.Log("ȸ�������� ��û�մϴ�."); //231101 ����� ��

        var bro = Backend.BMember.CustomSignUp(id, pw); //231101 �갡 �ȵ�
        Debug.Log(bro.IsSuccess());
        if (bro.IsSuccess())
        {
            Backend.BMember.CreateNickname(id);

            BackendGameData.Instance.GameDataGet();

            if (BackendGameData.userData == null)
            {
                BackendGameData.Instance.GameDataInsert();
            }

            BackendGameData.Instance.ChangeNickname(id);

            BackendGameData.Instance.GameDataUpdate();

            Debug.Log("ȸ�����Կ� �����߽��ϴ�. : " + bro);
        }
        else
        {
            Debug.Log("ȸ�����Կ� �����߽��ϴ�. �̹� �ִ� ���̵��� �� �ֽ��ϴ�. : " + bro);
            throw new DivideByZeroException();
        }
    }

    public void CustomLogin(string id, string pw)
    {
        Debug.Log("�α����� ��û�մϴ�.");

        var bro = Backend.BMember.CustomLogin(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("�α����� �����߽��ϴ�. : " + bro);
        }
        else
        {
            Debug.Log("�α����� �����߽��ϴ�. : " + bro);
            throw new DivideByZeroException("0���� ���� �� �����ϴ�.");
        }

    }

    public void UpdateNickname(string nickname)
    {
        Debug.Log("�г��� ������ ��û�մϴ�.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if (bro.IsSuccess())
        {
            Debug.Log("�г��� ���濡 �����߽��ϴ� : " + bro);
        }
        else
        {
            Debug.LogError("�г��� ���濡 �����߽��ϴ� : " + bro);
        }
    }
}