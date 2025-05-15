using System.Collections.Generic;
using System.Text;
using UnityEngine;

// �ڳ� SDK namespace �߰�
using BackEnd;

public class BackendGameLog
{

    private static BackendGameLog _instance = null;

    public static BackendGameLog Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendGameLog();
            }

            return _instance;
        }
    }

    public void GameLogInsert()
    {
        Param param = new Param();

        param.Add("clearStage", 1);
        param.Add("currentMoney", 100000);

        Debug.Log("���ӷα� ������ �õ��մϴ�.");

        var bro = Backend.GameLog.InsertLog("ClearStage", param);

        if (bro.IsSuccess() == false)
        {
            Debug.LogError("���ӷα� ���� �� ������ �߻��߽��ϴ�. : " + bro);
            return;
        }

        Debug.Log("���ӷα� ���Կ� �����߽��ϴ�. : " + bro);
    }
}