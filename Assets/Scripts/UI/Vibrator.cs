using UnityEngine;

public static class Vibrator
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject curentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = curentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject curentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate(long miliseconds = 250)
    {
        if (IsAndroid())
        {
            vibrator.Call("vibrate", miliseconds);
        }
        else
        {
            Handheld.Vibrate();
        }
    }

    public static void Cancel()
    {
        if (IsAndroid())
        {
            vibrator.Call("vibrate");
        }
    }

    public static bool IsAndroid()
    {
#if UNITY_ANDROID
        return true;
#else
    return false;
#endif
    }


}
