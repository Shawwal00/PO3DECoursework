using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureInPicture : MonoBehaviour
{
    public enum hAllignment { left, centre, right };
    public enum vAllignment {top, middle, bottom };

    public hAllignment horAlign = hAllignment.left;
    public vAllignment vertAlign = vAllignment.top;

    public enum UnitsIn {pixels, screen_percentage };
    public UnitsIn unit = UnitsIn.screen_percentage;

    public int width = 50;
    public int height = 50;
    public int xOffset = 0;
    public int yOffset = 0;

    public bool update = true;
    private int hsize, vsize, hloc, vloc;

    // Start is called before the first frame update
    void Start()
    {
        AdjustCamera ();
    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            AdjustCamera();
        }
    }

    void AdjustCamera()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        float swPercent = sw * 0.01f;
        float shPercent = sh * 0.01f;
        float xOffPercent = xOffset * swPercent;
        float yOffPercent = yOffset * shPercent;
        int xOff;
        int yOff;

        if (unit == UnitsIn.screen_percentage)
        {
            hsize = width * (int)swPercent;
            vsize = height * (int)shPercent;
            xOff = (int)xOffPercent;
            yOff = (int)yOffPercent;
        }
        else
        {
            hsize = width;
            vsize = height;
            xOff = xOffset;
            yOff = yOffset;
        }
        switch (horAlign)
        {
            case hAllignment.left:
                hloc = xOff;
                break;
            case hAllignment.right:
                int justifiedRight = (sw - hsize);
                hloc = (justifiedRight - xOff);
                break;
            case hAllignment.centre:
                float justifiedCenter = (sw * 0.5f) - (hsize * 0.5f);
                hloc = (int)(justifiedCenter - xOff);
                break;
        }
        switch (vertAlign)
        {
            case vAllignment.top:
                int justifiedTop = sh - vsize;
                vloc = (justifiedTop - yOff);
                break;
            case vAllignment.bottom:
                vloc = yOff;
                break;
            case vAllignment.middle:
                float justifiedMiddle = (sh * 0.5f) - (vsize * 0.5f);
                vloc = (int)(justifiedMiddle - yOff);
                break;
        }
        GetComponent<Camera>().pixelRect = new Rect(hloc, vloc, hsize, vsize);
    }
}
