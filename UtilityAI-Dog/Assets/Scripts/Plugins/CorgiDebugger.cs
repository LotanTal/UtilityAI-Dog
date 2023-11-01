using System;
using UnityEngine;

namespace CorgiTools.Debugger
{
    public static class CorgiDebugger
    {
        public static void PrintProgressBar(object value,
                                            string filledColorHex = null,
                                            string emptyColorHex = null,
                                            Color? filledColor = null,
                                            Color? emptyColor = null)
        {
            float percentage = GetTypeOfValue(value);

            int totalBars = 50;
            int filledBars = Mathf.RoundToInt(percentage * totalBars);

            // Create the filled and empty parts of the progress bar
            string filledPart = new string('▇', filledBars);
            string emptyPart = new string('▇', totalBars - filledBars);

            // Get the final colors to use
            string filledColorValue = GetColorValue(filledColor, filledColorHex, Color.green);
            string emptyColorValue = GetColorValue(emptyColor, emptyColorHex, Color.clear);

            // Print the progress bar to the console
            Debug.Log($"|<color={filledColorValue}>{filledPart}</color><color={emptyColorValue}>{emptyPart}</color>| {(percentage * 100):0.00}%");
        }

        private static string GetColorValue(Color? color, string colorHex, Color defaultColor)
        {
            if (!string.IsNullOrEmpty(colorHex))
            {
                return colorHex;
            }

            Color finalColor = color ?? defaultColor;
            return ColorToHex(finalColor);
        }

        private static string ColorToHex(Color color)
        {
            return $"#{ColorUtility.ToHtmlStringRGB(color)}";
        }

        private static float GetTypeOfValue(object value)
        {
            switch (value)
            {
                case int intValue:
                    return Mathf.Clamp01(intValue / 100f);
                case float floatValue:
                    return Mathf.Clamp01(floatValue / 100f);
                case double doubleValue:
                    return Mathf.Clamp01((float)doubleValue / 100f);
                default:
                    Debug.LogError("Unsupported value type for PrintProgressBar.");
                    return 0f;
            }
        }
    }
}
