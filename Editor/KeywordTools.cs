
//using System.Collections.Generic;
//using System.Linq;
//using System.IO;
//using UnityEditor;
//using UnityEngine;

//public static class KeywordTools {
//    private const string keywordReportFilename = "/Keyword Tools/Report.txt";
//    private static string[] keywordsToRemove = new string[] {
//        // -----------------------------------------------------
//        // Your keywords go HERE! \/
//        // -----------------------------------------------------
//        "_AO2MAPUV_UV0",
//    };

//    [MenuItem("Window/Keyword Tools/Reporter", false, 100)]
//    private static void Reporter() {
//        var fileName = Application.dataPath + keywordReportFilename;
//        var sr = File.CreateText(fileName);
//        var materials = GetSceneMaterialsWithKeywords().OrderBy(m => m.name);
//        var keywordList = materials
//                        .SelectMany(m => m.shaderKeywords)
//                        .Where(k => !string.IsNullOrEmpty(k))
//                        .Distinct()
//                        .OrderBy(k => k);
//        var keywordCount = keywordList.Count();
//        var materialShaderNames = new List<string>();

//        sr.WriteLine(" ");
//        sr.WriteLine("-----------------------------------------------------------------------");
//        sr.WriteLine(" Keywords: " + keywordCount);
//        sr.WriteLine("-----------------------------------------------------------------------");

//        foreach (var keyword in keywordList) {
//            sr.WriteLine("\"" + keyword + "\",");
//        }

//        sr.WriteLine(" ");
//        sr.WriteLine("-----------------------------------------------------------------------");
//        sr.WriteLine(" Keywords -> Materials: " + keywordCount);
//        sr.WriteLine("-----------------------------------------------------------------------");

//        foreach (var keyword in keywordList) {
//            sr.WriteLine("\"" + keyword + "\",");

//            foreach (var material in materials) {
//                var shaderKeywords = material.shaderKeywords;

//                if (shaderKeywords.Contains(keyword)) {
//                    sr.WriteLine("    " + material.name);
//                }
//            }

//            sr.WriteLine(" ");
//        }

//        sr.WriteLine("-----------------------------------------------------------------------");
//        sr.WriteLine(" Materials -> Keywords: " + materials.Count());
//        sr.WriteLine("-----------------------------------------------------------------------");

//        foreach (var material in materials) {
//            var shaderKeywords = material.shaderKeywords.OrderBy(k => k);

//            sr.WriteLine(material.name);

//            foreach (var keyword in shaderKeywords) {
//                if (!string.IsNullOrEmpty(keyword)) {
//                    sr.WriteLine("    \"" + keyword + "\",");
//                }
//            }

//            sr.WriteLine(" ");
//            materialShaderNames.Add(material.shader.name);
//        }

//        var shaderNames = materialShaderNames.Distinct().OrderBy(s => s);

//        sr.WriteLine("-----------------------------------------------------------------------");
//        sr.WriteLine(" Shaders -> Materials: " + shaderNames.Count());
//        sr.WriteLine("-----------------------------------------------------------------------");

//        foreach (var shaderName in shaderNames) {
//            var shaderMaterials = materials.Where(m => m.shader.name == shaderName).Select(m => m.name);

//            sr.WriteLine("\"" + shaderName + "\"");

//            foreach (var materialName in shaderMaterials) {
//                if (!string.IsNullOrEmpty(materialName)) {
//                    sr.WriteLine("    " + materialName);
//                }
//            }

//            sr.WriteLine(" ");
//        }

//        sr.Close();
//        System.Diagnostics.Process.Start(fileName);
//    }

//    [MenuItem("Window/Keyword Tools/Obliterater", false, 100)]
//    private static void Obliterater() {
//        var materials = GetSceneMaterialsWithKeywords().ToList();

//        try {
//            for (int i = 0, length = materials.Count(); i < length; i++) {
//                var material = materials[i];
//                var keywordsToRemove = material.shaderKeywords.Intersect(KeywordTools.keywordsToRemove);

//                EditorUtility.DisplayProgressBar(
//                    "Removing Keywords...",
//                    string.Format("{0} / {1} materials cleaned.", i, length),
//                    i / (float)(length - 1));

//                if (keywordsToRemove.Count() > 0) {
//                    foreach (var keyword in keywordsToRemove) {
//                        if (!string.IsNullOrEmpty(keyword)) {
//                            material.DisableKeyword(keyword);
//                        }
//                    }

//                    EditorUtility.SetDirty(material);
//                }
//            }
//        }
//        finally {
//            EditorUtility.ClearProgressBar();
//        }
//    }

//    private static IEnumerable<Material> GetSceneMaterialsWithKeywords() {
//        return Resources.FindObjectsOfTypeAll<Material>().Where(m => m.shaderKeywords.Length > 0);
//    }
//}
