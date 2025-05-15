
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using LitJson;

public class ReceiveRank : MonoBehaviour
{
    // RankInfo Ŭ���� ����
    private class RankInfo
    {
        public int rank;
        public string nickname;
        public int score;
        public string gamerInDate;
        public int index;
    }

    void Start()
    {
        string rankUUID = "54e326d0-4cad-11ee-b1b7-4f4b7e685ede";
        var bro = Backend.URank.User.GetRankList(rankUUID);

        if (bro.IsSuccess() == false)
        {
            Debug.LogError("��ŷ ��ȸ�� ������ �߻��߽��ϴ�. : " + bro);
            return;
        }
        Debug.Log("��ŷ ��ȸ�� �����߽��ϴ�. : " + bro);

        Debug.Log("�� ��ŷ ��� ���� �� : " + bro.GetFlattenJSON()["totalCount"].ToString());

        List<RankInfo> rankList = new List<RankInfo>(); // ��ŷ ������ ������ ����Ʈ ����

        foreach (JsonData jsonData in bro.FlattenRows())
        {
            RankInfo rankInfo = new RankInfo();
            rankInfo.rank = int.Parse(jsonData["rank"].ToString());
            rankInfo.nickname = jsonData["nickname"].ToString();
            rankInfo.score = int.Parse(jsonData["score"].ToString());
            rankInfo.gamerInDate = jsonData["gamerInDate"].ToString();
            rankInfo.index = int.Parse(jsonData["index"].ToString());

            rankList.Add(rankInfo); // ��ŷ ������ ����Ʈ�� �߰�
        }

        // ù ��° �׸��� �̾Ƽ� Debug.Log�� ���
        if (rankList.Count > 0)
        {
            RankInfo firstItem = rankList[0];
            Debug.Log("ù ��° �׸� - ����: " + firstItem.rank + ", �г���: " + firstItem.nickname + ", ����: " + firstItem.score);
        }
        else
        {
            Debug.Log("��ŷ ������ �����ϴ�.");
        }
    }
}
