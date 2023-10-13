using System.Diagnostics;
using System.Runtime.InteropServices;

internal class Program
{
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern IntPtr FindWindow(string lpClassname, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern int SetWindowText(IntPtr hWnd, string lpString);

    static void UpdateNotepadWindowTitle(string newTitle)
    {
        IntPtr notepadWindow = FindWindow("Notepad",null);
        SetWindowText(notepadWindow, newTitle);
    }
    private static void Main(string[] args)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        Process process = new Process();
        process.StartInfo.FileName = "Notepad.exe";
        process.Start();
        var processes = Process.GetProcessesByName("Notepad");
        while (processes.Length > 0)
        {
            TimeSpan ts = stopWatch.Elapsed;

            string text = String.Format("{0:00}:{1:00}:{2:00}",
                                ts.Hours, ts.Minutes, ts.Seconds
                                );

            UpdateNotepadWindowTitle(text);
            Thread.Sleep(1000);
            //pr.MainWindowTitle = (DateTime.Now - dateTime_start).ToString();
        }
    }
}