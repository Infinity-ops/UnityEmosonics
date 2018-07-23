using UnityEngine;

public class FavoriteColor : MonoBehaviour
{
    public ColorPicking ColorPicker;
    SpriteRenderer Sprite;
    FavoriteColor Selected;

    public Color Color
    {
        get { return Sprite.color; }
        set { Sprite.color = value; }
    }

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Selected = gameObject.GetComponent<FavoriteColor>();
    }

    void Update()
    {
        Selected.Color = ColorPicker.Color;
    }
}
