using Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccountInfo : IDataUnit<AccountInfo>
{
    public int Index { get; set; }
    public string UserName { get; set; }
    public Sprite AvatarSprite { get; set; }
    public int StarAmount {  get; set; }
}

public class AccountCard : CardBase<AccountInfo>
{
    [SerializeField] TextMeshProUGUI userName;
    [SerializeField] Image avatar;
    public override void BuildView(AccountInfo info)
    {
        base.BuildView(info);
        userName.text = info.UserName;
        avatar.sprite = info.AvatarSprite;

    }
    public void OnSellectAccount()
    {
        AccountConfig.CurAcc = info;
        int countOfList = AccountConfig.ListAccount.Count;
        AccountInfo tempAccount = AccountConfig.ListAccount[countOfList - 1 - Info.Index];
        AccountConfig.ListAccount.RemoveAt(countOfList - 1 - Info.Index);
        AccountConfig.ListAccount.Add(tempAccount);
    }
}
