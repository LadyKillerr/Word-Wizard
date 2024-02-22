using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] Image userAvatar;
    private void Start()
    {
        if (AccountConfig.CurAcc != null)
        {
            userAvatar.sprite = AccountConfig.CurAcc.AvatarSprite;
        }
        else
        {
            Debug.Log("Don't have account");
        }
    }
}
