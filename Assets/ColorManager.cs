using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

    public static ColorManager Instance;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            print("Create color manager");
        }
    }

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            print("Create color manager");
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private Color color;

    void OnColorChange(HSBColor newColor) {
        this.color = newColor.ToColor();
        print("Color change");
    }

    public Color GetCurrentColor() {
        return this.color;
    }
}
