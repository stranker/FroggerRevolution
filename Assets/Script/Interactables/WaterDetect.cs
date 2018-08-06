using UnityEngine;

public class WaterDetect : MonoBehaviour {

    public bool onWater;
    public bool onPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            onWater = true;
        }

        if (collision.tag == "Platform")
        {
            onPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            onWater = false;
        }

        if (collision.tag == "Platform")
        {
            onPlatform = false;
        }
    }
}
