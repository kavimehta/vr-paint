using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

    public static ColorManager Instance;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private Color color;

    void onColorChange(HSBColor newColor) {
        this.color = newColor.ToColor();
    }

    public Color GetCurrentColor() {
        return this.color;
    }
}
