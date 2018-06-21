using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CommunicationWheel : MaskableGraphic 
{
    [SerializeField]
    Texture m_Texture;

    [Range(0, 1)]
    [SerializeField]
    private float fillAmount;

    public float FillAmount
    {
        get { return fillAmount; }
        set
        {
            fillAmount = value;

            SetVerticesDirty();
        }
    }

    public bool fill = true;
    public int thickness = 5;

 

    public override Texture mainTexture
    {
        get
        {
            return m_Texture == null ? s_WhiteTexture : m_Texture;
        }
    }

   
    public Texture texture
    {
        get { return m_Texture; }

        set
        {
            if (m_Texture == value)
                return;
            m_Texture = value;
            SetVerticesDirty();
            SetMaterialDirty();
        }
    }

    UIVertex[] uiVertices = new UIVertex[4];
    Vector2[] uvs = new Vector2[4];
    Vector2[] pos = new Vector2[4];

    protected override void Start()
    {

        uvs[0] = new Vector2(0, 1);
        uvs[1] = new Vector2(1, 1);
        uvs[2] = new Vector2(1, 0);
        uvs[3] = new Vector2(0, 0);
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        float outer = -rectTransform.pivot.x * rectTransform.rect.width;
        float inner = -rectTransform.pivot.x * rectTransform.rect.width + thickness;

        float degrees = 360f / 360;
        int fa = (int)((360 + 1) * this.fillAmount);

        vh.Clear();

        float x = outer * Mathf.Cos(0);
        float y = outer * Mathf.Sin(0);
        Vector2 prevX = new Vector2(x, y);

        x = inner * Mathf.Cos(0);
        y = inner * Mathf.Sin(0);
        Vector2 prevY = new Vector2(x, y);

        for (int i = 0; i < fa - 1; i++)
        {
            float rad = Mathf.Deg2Rad * ((i + 1) * degrees);
            float c = Mathf.Cos(rad);
            float s = Mathf.Sin(rad);

            pos[0] = prevX;
            pos[1] = new Vector2(outer * c, outer * s);

            if (fill)
            {
                pos[2] = Vector2.zero;
                pos[3] = Vector2.zero;
            }
            else
            {
                pos[2] = new Vector2(inner * c, inner * s);
                pos[3] = prevY;
            }

            for (int j = 0; j < 4; j++)
            {
                uiVertices[j].color = color;
                uiVertices[j].position = pos[j];
                uiVertices[j].uv0 = uvs[j];
            }

            int vCount = vh.currentVertCount;

            vh.AddVert(uiVertices[0]);
            vh.AddVert(uiVertices[1]);
            vh.AddVert(uiVertices[2]);

            vh.AddTriangle(vCount, vCount + 2, vCount + 1);

            if (!fill)
            {
                vh.AddVert(uiVertices[3]);
                vh.AddTriangle(vCount, vCount + 3, vCount + 2);
            }

            prevX = pos[1];
            prevY = pos[2];

        }
    }
}