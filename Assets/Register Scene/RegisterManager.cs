using System;
using nhacdongvat;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
    public Button buttonContinue;

    public TextMeshProUGUI textRemain;

    private TimeSpan checkTime;

    public void Start()
    {
        checkTime = TimeSpan.FromSeconds(GameDataManager.Instance.playerData.time);

        TimeSpan test =
            DateTime.Now.Subtract(
                DateTime.FromBinary(Convert.ToInt64(GameDataManager.Instance.playerData.timeRegister)));

        checkTime = checkTime.Subtract(test);

        string answer = string.Format("{0:D2}Day: {1:D2}h:{2:D2}m:{3:D2}s",
            checkTime.Days,
            checkTime.Hours,
            checkTime.Minutes,
            checkTime.Seconds);

        Debug.Log(answer);

        if (checkTime.TotalSeconds <= 0)
        {
            checkTime = TimeSpan.Zero;
            GameDataManager.Instance.playerData.ResetTime();
        }


        buttonContinue.onClick.AddListener(OnClickButton);

        UpdateTimeRemain();
    }

    private void OnClickButton()
    {
        gameObject.SetActive(false);
    }

    public void OnPressDown(int i)
    {
        switch (i)
        {
            case 1:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(1);
                IAPManager.Instance.BuyProductID(IAPKey.PACK1_REGISTER);
                break;
            case 2:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(7);
                IAPManager.Instance.BuyProductID(IAPKey.PACK2_REGISTER);
                break;
            case 3:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(30);
                IAPManager.Instance.BuyProductID(IAPKey.PACK3_REGISTER);
                break;
            case 4:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(90);
                IAPManager.Instance.BuyProductID(IAPKey.PACK4_REGISTER);
                break;
            case 5:
                IAPManager.OnPurchaseSuccess = () =>
                    AddTime(180);
                IAPManager.Instance.BuyProductID(IAPKey.PACK5_REGISTER);
                break;
        }
    }

    private void AddTime(int i)
    {
        checkTime = checkTime.Add(TimeSpan.FromSeconds(i * 24 * 60 * 60));

        GameDataManager.Instance.playerData.SetTimeRegister((long) checkTime.TotalSeconds);
        UpdateTimeRemain();
    }

    private float time = 1;

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            if (checkTime > TimeSpan.Zero)
            {
                checkTime = checkTime.Subtract(TimeSpan.FromSeconds(1));
            }

            UpdateTimeRemain();
            time = 1;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Test()
    {
        checkTime = TimeSpan.FromSeconds(7);
    }

    /// <summary>
    /// 
    /// </summary>
    private void UpdateTimeRemain()
    {
        if (checkTime.TotalSeconds < 1)
        {
            textRemain.text = "You need to pay to continue";
            GameDataManager.Instance.playerData.ResetTime();
        }
        else
        {
            string answer = string.Format("{0:D1}Day: {1:D2}h:{2:D2}m:{3:D2}s",
                checkTime.Days,
                checkTime.Hours,
                checkTime.Minutes,
                checkTime.Seconds);

            textRemain.text = $"Time remaining : " +
                              $"{answer}";
        }
    }
}