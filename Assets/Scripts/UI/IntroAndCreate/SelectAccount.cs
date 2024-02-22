using DG.Tweening;
using Framework;
using UnityEngine;

public class SelectAccount : MonoBehaviour
{
    [SerializeField] AccountCllectionView accCollection;

    private void Start()
    {
        accCollection.BuildView(AccountConfig.ListAccount);
    }

    public void ClosePopup()
    {
        DOTween.CompleteAll(gameObject);
        gameObject.GetComponent<PopupBehaviour>().Close();
    }
}
