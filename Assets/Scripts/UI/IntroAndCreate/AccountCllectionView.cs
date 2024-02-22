using Framework;
using System.Collections.Generic;
using UnityEngine;

public class AccountCllectionView : CollectionViewBase<AccountInfo>
{
    public override void BuildView()
    {
    }
    public override void BuildView(List<AccountInfo> infos)
    {
        List<AccountInfo> reverseInfos = new(infos);
        reverseInfos.Reverse();
        base.BuildView(reverseInfos);
    }
}
