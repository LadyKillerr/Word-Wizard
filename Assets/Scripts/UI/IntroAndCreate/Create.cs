using DG.Tweening;
using Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI NickName;
    [SerializeField] TextMeshProUGUI textMessage;
    [SerializeField] TextMeshProUGUI placeHolder;
    [SerializeField] Image Avatar;
    [SerializeField] string notificationText;
    private void Start()
    {
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }
    private void OnInputValueChanged(string newValue)
    {
        NickName.text = newValue;
    }
    public void ChangAvatar(Button button)
    {
        Avatar.sprite = button.image.sprite;
    }
    void TweenMessage(string text)
    {
        textMessage.DOKill();
        textMessage.alpha = 0;
        textMessage.text = text;
        placeHolder.alpha = 0;
        textMessage.DOFade(1,1.5f).OnComplete(() =>
        {
            textMessage.DOFade(0, 0.5f).OnComplete(() => { placeHolder.alpha = 1; });
        });
    }
    public void OnClickCreateButton()
    {
        if (NickName.text != string.Empty)
        {
            AccountInfo accountInfo = new()
            {
                AvatarSprite = Avatar.sprite,
                UserName = NickName.text
            };
            AccountConfig.ListAccount.Add(accountInfo);
            AccountConfig.CurAcc = accountInfo;
            SceneTransitionHelper.Load(ESceneName.Home, true);
        }
        else
        {
            TweenMessage(notificationText);
        }
    }
    public void ClosePopup()
    {
        DOTween.CompleteAll(gameObject);
        gameObject.GetComponent<PopupBehaviour>().Close();
    }
}
