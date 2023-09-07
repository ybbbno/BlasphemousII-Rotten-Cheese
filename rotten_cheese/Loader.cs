using System.IO;
using UnityEngine;

namespace rotten_cheese{
    public static class Loader{
        public static Texture2D DuplicateTexture(Texture2D source)
        {
            RenderTexture renderTex = RenderTexture.GetTemporary(
                        source.width,
                        source.height,
                        0,
                        RenderTextureFormat.Default,
                        RenderTextureReadWrite.Linear);

            Graphics.Blit(source, renderTex);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = renderTex;
            Texture2D readableText = new Texture2D(source.width, source.height);
            readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
            readableText.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(renderTex);
            readableText.name = source.name;
            return readableText;
        }

        public static void DownloadTexture(Texture2D source, string path, string file_name){
            var source_dublicate = DuplicateTexture(source);
            //Main.rotten_cheese.Log(source_dublicate.ToString());
            byte[] source_dublicate_bytes = source_dublicate.EncodeToPNG();
            File.WriteAllBytes(path+file_name+".png", source_dublicate_bytes);
        }
    }
}