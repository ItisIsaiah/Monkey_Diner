using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatB : MonoBehaviour
{

    public enum IconType
    {
        BOTTOMBUN,
        PATTY,
        LETTUCE,
        CHEESE,
        TOPBUN,
    }

    [SerializeField] private Object SpriteHolder;
    ArrayList spriteRenders=new ArrayList();
    Orders food; 
    [SerializeField] private Sprite LettuceSprite;
    [SerializeField] private Sprite CheeseSprite;
    [SerializeField] private Sprite PattySprite;
    [SerializeField] private Sprite BottomBunSprite;
    private SpriteRenderer backgroundpriteRenderer;
    private SpriteRenderer iconSpriteRenderer;

    private GameObject[] sprites;

    // Start is called before the first frame update
    [SerializeField]
    GameObject BG;
    
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
    public void newSetUp(IconType ic, SpriteRenderer sp)
    {
        sp.sprite = GetIcon(ic);
    }
    public Sprite GetIcon(IconType iconType)
    {
        switch (iconType)
        {
            default:
            case IconType.BOTTOMBUN: return BottomBunSprite;
                break;
            case IconType.PATTY: return PattySprite;
                break;
            case IconType.CHEESE: return CheeseSprite;
                break;
            case IconType.LETTUCE: return LettuceSprite;
                break;
        }
    }
    
    public SpriteRenderer[] CreateOrderSheet(int foodAmount)
    {
        food = (Orders)ScriptableObject.CreateInstance(typeof(Orders));
        BG.transform.localScale = new Vector3(BG.transform.localScale.x,BG.transform.localScale.y,BG.transform.localScale.z*foodAmount);
        float increment = (foodAmount-.5f/4);
        float scalar = increment;
        //Modify the scale of the Ordersheet
        for (int i=0;i<foodAmount;i++)
        {
            GameObject fooditem=(GameObject)Instantiate(SpriteHolder,this.gameObject.transform);

            

            spriteRenders.Add(fooditem);
        }
        //This for loop sets the hieght on the ordersheet on the  food so we can stack the sprites dynamically.
        foreach (GameObject S in spriteRenders){
            
            SpriteRenderer foodRender = S.GetComponent<SpriteRenderer>();
            S.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z-increment);
            increment += scalar;

        }
        int j = 0;
        foreach (string s in food.coreParts)
        {
            //string to iconType;

            newSetUp(stringToIconType(s),(SpriteRenderer)spriteRenders[j]);
        }

        for(int i = 0; i <= foodAmount - food.coreParts.Length-1; i++)
        {
            string s = food.foodParts[Random.Range(0, food.foodParts.Length-1)];
            newSetUp(stringToIconType(s), (SpriteRenderer)spriteRenders[j]);
            //Randomize from the ScriptableObject
        }
        return null;
    }

    public IconType stringToIconType(string s)
    {
        //Fix{
        IconType icon;
        if (IconType.TryParse<IconType>(s.ToUpper(), out icon))
        {
            icon = (IconType)IconType.Parse(typeof(IconType),s.ToUpper());
            return icon;
        }
        else
        {
            Debug.LogError(s+" IS NOT A VALID ENUM YOU DUFUS.");
            return icon;
        }
        
        
    }
}
