using System;
using System.IO;
using UnityEngine;

public static class FileManager {
    public static string ReadFile(string path) {
        StreamReader reader = new StreamReader(path);
        var contents = reader.ReadToEnd();
        reader.Close();

        return contents;
    }

    public static string[] ReadFileLines(string path) {
        StreamReader reader = new StreamReader(path);
        string[] lines = reader.ReadToEnd().Split(new char[] {'\n'});
        reader.Close();
        return lines;
    }

    public static void WriteFile(string path, string[] data, bool generateOld) {
        if (!File.Exists(path)) {
            File.Create(path).Dispose();
        }
        
        if (generateOld) {
            GenerateOld(path);
        }
        
        File.WriteAllText(path, String.Empty);
        StreamWriter writer = new StreamWriter(path, true);
        foreach (var s in data) {
            writer.WriteLine(s);
        }
        writer.Close();
    }

    private static void GenerateOld(string path) {
        if (File.Exists(path + ".old")) {
            File.Delete(path + ".old");
        }

        if (File.Exists(path)) {
            File.Copy(path, path + ".old");
        }
    }
}