using System;
using System.Runtime.InteropServices;

public class KeyboardOperations
{

    public const int KEYEVENTF_KEYDOWN = 0x0000; // New definition
    public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
    public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag


    [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
    public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

    public static void PressKey(byte bVk)
    {
        keybd_event(bVk, 0, KEYEVENTF_KEYDOWN, 0);
        keybd_event(bVk, 0, KEYEVENTF_KEYUP, 0);
    }
}