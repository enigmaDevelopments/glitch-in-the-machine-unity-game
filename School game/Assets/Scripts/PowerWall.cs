using UnityEngine;
using Style;

public class PowerWall : MonoBehaviour
{
    public GameObject top;
    public Transform detector;
    public Sprite angled;
    public PolygonCollider2D mainColider;
    public PolygonCollider2D angledColider;
    public LayerMask ignore;
    public float speed = .001f;
    public bool sartExtended = false;
    public Activator.Activator power;
    private bool extending;
    private bool moving = false;
    private bool lastState;
    void Start()
    {
        if (Mathf.Round(gameObject.transform.localRotation.eulerAngles.z) % 90 != 0)
        {
            SpriteChanger.changeSprite(angled, gameObject);
            mainColider.enabled = false;
            angledColider.enabled = true;
        }
        ignore = ~ignore;
        extending = sartExtended;
        if (power != null)
            lastState = power;
        for (int i = 0; i < 100000 && expandWall()&& extending; i++) { }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (power != null && lastState != power)
        {
            lastState = !lastState;
            extending = !extending;
            moving = true;
        }
        if (moving)
            moving = expandWall();
    }
   private bool expandWall()
   {
        Vector2 size = top.transform.localScale;
        if(extending)
        {
            Vector2 detectCenter = new Vector2(detector.position.x, detector.position.y + .0001f);
            Vector2 boxSize = new Vector2(.2f,.0002f);
            Collider2D[] cols = Physics2D.OverlapBoxAll(detectCenter, boxSize, gameObject.transform.localRotation.eulerAngles.z, ignore);
            foreach (Collider2D col in cols)
                if (col.gameObject != gameObject && col.gameObject != top)
                    return false;
        }
        else
            if (size.y <= 1)
                return false;
        size.y += speed * (extending ? 1 : -1);
        top.transform.localScale = size;
        return true;
    }
}
