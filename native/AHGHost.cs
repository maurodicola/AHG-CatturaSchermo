// Autore: AHG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

internal static class AHGHost
{
    private const string Origin = "chrome-extension://pjkfgghgaepmjbhplfpjaagpmglkcpbl/";
    private const uint KeyUp = 0x0002;
    [StructLayout(LayoutKind.Sequential)] private struct INPUT { public uint type; public InputUnion data; }
    [StructLayout(LayoutKind.Explicit)] private struct InputUnion
    {
        [FieldOffset(0)] public KEYBDINPUT keyboard;
        [FieldOffset(0)] public MOUSEINPUT mouse;
        [FieldOffset(0)] public HARDWAREINPUT hardware;
    }
    [StructLayout(LayoutKind.Sequential)] private struct KEYBDINPUT
    { public ushort vk; public ushort scan; public uint flags; public uint time; public UIntPtr extra; }
    [StructLayout(LayoutKind.Sequential)] private struct MOUSEINPUT
    { public int x; public int y; public uint mouseData; public uint flags; public uint time; public UIntPtr extra; }
    [StructLayout(LayoutKind.Sequential)] private struct HARDWAREINPUT
    { public uint msg; public ushort paramL; public ushort paramH; }
    [DllImport("user32.dll", SetLastError = true)] private static extern uint SendInput(uint count, INPUT[] inputs, int size);
    [DllImport("user32.dll")] private static extern short GetAsyncKeyState(int key);
    [DllImport("user32.dll")] private static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")] private static extern uint GetWindowThreadProcessId(IntPtr window, out uint process);

    private static byte[] ReadExact(Stream stream, int count)
    {
        byte[] buffer = new byte[count];
        int offset = 0;
        while (offset < count)
        {
            int read = stream.Read(buffer, offset, count - offset);
            if (read == 0) throw new EndOfStreamException();
            offset += read;
        }
        return buffer;
    }
    private static void Reply(bool ok, string error)
    {
        var payload = new Dictionary<string, object>();
        payload["ok"] = ok;
        if (error != null) payload["error"] = error;
        byte[] bytes = Encoding.UTF8.GetBytes(new JavaScriptSerializer().Serialize(payload));
        using (Stream output = Console.OpenStandardOutput())
        {
            byte[] prefix = BitConverter.GetBytes((uint)bytes.Length);
            output.Write(prefix, 0, prefix.Length);
            output.Write(bytes, 0, bytes.Length);
            output.Flush();
        }
    }
    private static INPUT Key(ushort vk, bool up)
    {
        INPUT input = new INPUT();
        input.type = 1;
        input.data.keyboard.vk = vk;
        input.data.keyboard.flags = up ? KeyUp : 0;
        return input;
    }
    private static bool ModifiersDown()
    {
        foreach (int key in new int[] { 0x10, 0x11, 0x12, 0x5B, 0x5C })
            if ((GetAsyncKeyState(key) & 0x8000) != 0) return true;
        return false;
    }
    private static void OpenPanel(string action)
    {
        // Lascia rilasciare i tasti prima di aprire il pannello.
        Thread.Sleep(350);
        for (int i = 0; i < 30 && ModifiersDown(); i++) Thread.Sleep(25);
        if (ModifiersDown()) throw new InvalidOperationException("Rilascia i tasti della tastiera e riprova.");
        uint pid;
        GetWindowThreadProcessId(GetForegroundWindow(), out pid);
        using (Process foreground = Process.GetProcessById((int)pid))
            if (!String.Equals(foreground.ProcessName, "msedge", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Torna alla finestra di Edge e riprova.");
        INPUT[] keys = new INPUT[] { Key(0x5B, false), Key(0x10, false), Key(0x53, false), Key(0x53, true), Key(0x10, true), Key(0x5B, true) };
        uint sent = SendInput((uint)keys.Length, keys, Marshal.SizeOf(typeof(INPUT)));
        if (sent != keys.Length)
        {
            SendInput(3, new INPUT[] { Key(0x53, true), Key(0x56, true), Key(0x10, true) }, Marshal.SizeOf(typeof(INPUT)));
            SendInput(1, new INPUT[] { Key(0x5B, true) }, Marshal.SizeOf(typeof(INPUT)));
            throw new InvalidOperationException("Windows non ha accettato il comando. Usa Edge senza avviarlo come amministratore e riprova.");
        }
    }
    private static int Main(string[] args)
    {
        try
        {
            if (args.Length < 1 || !String.Equals(args[0], Origin, StringComparison.Ordinal)) return 2;
            Stream input = Console.OpenStandardInput();
            uint length = BitConverter.ToUInt32(ReadExact(input, 4), 0);
            if (length < 2 || length > 4096) throw new InvalidDataException();
            string json = new UTF8Encoding(false, true).GetString(ReadExact(input, (int)length));
            var serializer = new JavaScriptSerializer();
            var message = serializer.Deserialize<Dictionary<string, object>>(json);
            object value;
            if (message == null || !message.TryGetValue("action", out value) || !(value is string)) throw new InvalidDataException();
            string action = (string)value;
            if (action != "ping" && action != "capture") throw new InvalidDataException();
            if (action != "ping") OpenPanel(action);
            Reply(true, null);
            return 0;
        }
        catch (InvalidOperationException error) { Reply(false, error.Message); return 1; }
        catch { Reply(false, "Comando non valido o componente Windows non disponibile."); return 1; }
    }
}
