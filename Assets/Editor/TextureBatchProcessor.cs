using UnityEngine;
using UnityEditor;
using System.IO;

public class TextureBatchProcessor : EditorWindow
{
    [MenuItem("Tools/Batch Compress Textures")]
    static void BatchCompressTextures()
{
    string path = Application.dataPath + "/ChangwenLiu/AnimeSuburbCity/Textures"; // 使用绝对路径
    string[] texturePaths = Directory.GetFiles(path, "*.tga", SearchOption.AllDirectories); // 获取所有 TGA 文件路径

    foreach (string texturePath in texturePaths)
    {
        // 确保路径使用正斜杠
        string normalizedPath = texturePath.Replace("\\", "/");

        // 转换为 Unity 资源路径
        string assetPath = "Assets" + normalizedPath.Substring(Application.dataPath.Length);

        // 验证资源路径是否有效
        if (File.Exists(normalizedPath))
        {
            TextureImporter importer = (TextureImporter)AssetImporter.GetAtPath(assetPath);

            if (importer == null)
            {
                Debug.LogError("Failed to find TextureImporter for " + assetPath);
                continue;
            }

            // 设置纹理压缩和最大尺寸
            importer.textureCompression = TextureImporterCompression.Compressed;
            importer.maxTextureSize = 512;

            // 强制重新导入资源并应用更改
            AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);

            Debug.Log($"Compressing texture: {assetPath}, Max Size: {importer.maxTextureSize}, Compression: {importer.textureCompression}");
        }
        else
        {
            Debug.LogError("File does not exist: " + normalizedPath);
        }
    }

    Debug.Log("Batch compressing textures complete!");
}
}