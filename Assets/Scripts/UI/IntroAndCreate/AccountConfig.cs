using Framework;
using System.Collections.Generic;
using UnityEngine;

public class AccountConfig : SingletonScriptableObjectModulized<AccountConfig>
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        if (_instance == null)
        {
            Instance.ToString();
        }
    }
    [SerializeField] private List<AccountInfo> listAccount = new(); public static List<AccountInfo> ListAccount { get { return Instance.listAccount; } }
    [SerializeField] private AccountInfo curAcc; public static AccountInfo CurAcc { get { return Instance.curAcc; } set { Instance.curAcc = value; } }
}
