using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatB : MonoBehaviour
{

    public enum IconType
    {
        BottomBun,
        Patty,
        Lettuce,
        Cheese,
        TopBun,
    }
    [SerializeField] private Sprite LettuceSprite;
    [SerializeField] private Sprite CheeseSprite;
    [SerializeField] private Sprite PattySprite;
    [SerializeField] private Sprite BottomBunSprite;
    private SpriteRenderer backgroundpriteRenderer;
    private SpriteRenderer iconSpriteRenderer;

    // Start is called before the first frame update

    
    private void Awake()
    {
        backgroundpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        iconSpriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
      //  SetUp(IconType.Lettuce);
    }
    public void SetUp(IconType iconType)
    {
        iconSpriteRenderer.sprite = GetIcon(iconType);
    }
    private Sprite GetIcon(IconType iconType)
    {
        switch (iconType)
        {
            default:
            case IconType.BottomBun: return BottomBunSprite;
                break;
            case IconType.Patty: return PattySprite;
                break;
            case IconType.Cheese: return CheeseSprite;
                break;
            case IconType.Lettuce: return LettuceSprite;
                break;
        }
    }
   
}
