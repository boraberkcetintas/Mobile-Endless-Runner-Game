using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*  for (int i = 0; i < 11; i++)
              PlayerPrefs.DeleteKey("availableSkins" + i);*/
    }
    public static void increaseFakeLevel()
    {
        PlayerPrefs.SetInt("fakeLevel", getFakeLevel() + 1);
    }

    public static int getFakeLevel()
    {
        if (PlayerPrefs.HasKey("fakeLevel"))
            return PlayerPrefs.GetInt("fakeLevel");
        else return 1;
    }

    public static void setLastPlayedLevel(int i)
    {
        PlayerPrefs.SetInt("lastPlayedLevel", i);
    }
    public static int getLastPlayedLevel()
    {
        if (PlayerPrefs.HasKey("lastPlayedLevel"))
            return PlayerPrefs.GetInt("lastPlayedLevel");
        else return 1;
    }


    public static void setDailyRewardTaken(int i)
    {
        PlayerPrefs.SetInt("dailyreward", i);
    }

    public static int getDailyRewardTaken()
    {
        if (PlayerPrefs.HasKey("dailyreward"))
            return PlayerPrefs.GetInt("dailyreward");
        else return -1;
    }

    public static void setNextDailyRewardTime(string date)
    {
        PlayerPrefs.SetString("removeAds", date);

    }
    public static string getNextDailyRewardTime()
    {
        if (PlayerPrefs.HasKey("removeAds"))
            return PlayerPrefs.GetString("removeAds");
        else return "";
    }
    public static void removeAds()
    {
        PlayerPrefs.SetInt("removeAds", 1);
    }
    public static bool isAdsRemoved()
    {
        if (PlayerPrefs.HasKey("removeAds"))
            return true;
        else return false;
    }


    public static void addScore(int score)
    {
        PlayerPrefs.SetInt("score", getScore() + score);
    }

    public static int getScore()
    {
        if (PlayerPrefs.HasKey("score"))
            return PlayerPrefs.GetInt("score");
        else return 0;
    }



    public static void saveLvl(int i)
    {
        PlayerPrefs.SetInt("level", i);
    }

    public static int getLvl()
    {
        if (PlayerPrefs.HasKey("level"))
            return PlayerPrefs.GetInt("level");
        else return 1;
    }

    public static int getGold()
    {
        if (PlayerPrefs.HasKey("gold"))
            return PlayerPrefs.GetInt("gold");
        else return 0;
    }

    public static void addGold(int amount)
    {
        int tempGold = getGold();
        int newGoldAmount = tempGold + amount;
        PlayerPrefs.SetInt("gold", newGoldAmount);
    }
    public static void useGold(int amount)
    {
        int tempGold = getGold();
        int newGoldAmount = tempGold - amount;
        PlayerPrefs.SetInt("gold", newGoldAmount);

    }

    public static void saveLevelPlayable(int i)
    {
        PlayerPrefs.SetInt("level" + i, 1);
    }

    public static int getLevelPlayable(int i)
    {
        if (PlayerPrefs.HasKey("level" + i))
            return PlayerPrefs.GetInt("level" + i);
        else
            return 0;
    }

    public static void saveSkinOwned(int i)
    {
        PlayerPrefs.SetInt("availableSkins" + i, 1);
    }

    public static bool getSkinOwned(int index)
    {
        if (PlayerPrefs.HasKey("availableSkins" + index))
            return true;
        else
            return false;
    }

    public static void saveSelectedSkin(int i)
    {
        PlayerPrefs.SetInt("selectedSkin", i);
    }

    public static int getSelectedSkin()
    {
        if (PlayerPrefs.HasKey("selectedSkin"))
            return PlayerPrefs.GetInt("selectedSkin");
        else
            return 0;
    }


}