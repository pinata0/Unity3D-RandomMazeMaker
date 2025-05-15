using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 뒤끝 SDK namespace 추가
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
        Debug.Log("회원가입을 요청합니다."); //231101 얘까진 됨

        var bro = Backend.BMember.CustomSignUp(id, pw); //231101 얘가 안됨
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

            Debug.Log("회원가입에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.Log("회원가입에 실패했습니다. 이미 있는 아이디일 수 있습니다. : " + bro);
            throw new DivideByZeroException();
        }
    }

    public void CustomLogin(string id, string pw)
    {
        Debug.Log("로그인을 요청합니다.");

        var bro = Backend.BMember.CustomLogin(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("로그인이 성공했습니다. : " + bro);
        }
        else
        {
            Debug.Log("로그인이 실패했습니다. : " + bro);
            throw new DivideByZeroException("0으로 나눌 수 없습니다.");
        }

    }

    public void UpdateNickname(string nickname)
    {
        Debug.Log("닉네임 변경을 요청합니다.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if (bro.IsSuccess())
        {
            Debug.Log("닉네임 변경에 성공했습니다 : " + bro);
        }
        else
        {
            Debug.LogError("닉네임 변경에 실패했습니다 : " + bro);
        }
    }
}