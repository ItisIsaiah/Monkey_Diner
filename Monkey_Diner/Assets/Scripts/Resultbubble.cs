using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resultbubble : MonoBehaviour
{

    public enum RightWrong
    {
       Wrong,Right
    }
    [SerializeField] private Sprite Right;
    [SerializeField] private Sprite Wrong;
  
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
    public void SetUp(RightWrong rightWrong)
    {
        iconSpriteRenderer.sprite = GetIcon(rightWrong);
    }
    public Sprite GetIcon(RightWrong rightWrong)
    {
        switch (rightWrong)
        {
            default:
            case RightWrong.Right:
                return Right;
                break;
            case RightWrong.Wrong:
                return Wrong;
                break;
          
        }
    }
}
