using System.Collections.Generic;
using System.Text;
using UnityEngine;

// 뒤끝 SDK namespace 추가
using BackEnd;

public class BackendChart
{
    private static BackendChart _instance = null;

    public static BackendChart Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendChart();
            }

            return _instance;
        }
    }

    public void ChartGet(string chartId)
    {
        // Step 3. 차트 정보 가져오기 내용 추가
    }
}