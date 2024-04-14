using System;
using Unity.Collections;
using UnityEngine;

namespace Project.Gameplay.World.Tiles
{
    public enum ETileType
    {
        Walls = 0, // Black
        
        Floor = 0b111, // White
        SafeZone = 0b010, // Green
        Door = 0b110, // Yellow
        
        Liquid = 0b001, //Blue
        Decor = 0b101, // Purple
        AltDecor = 0b011, // Cyan
        
        TBD = 0b100, // Red
    }
    
    public static class TileHelper 
    {
        /// <summary>
        /// Converts a Texture2D into a 2D array of ETileType based on color mapping.
        /// </summary>
        /// <param name="pTexture">The Texture2D to convert.</param>
        /// <returns>A 2D array of ETileType representing the tile types in the texture.</returns>
        public static ETileType[,] TextureToArray(Texture2D pTexture)
        {
            if (!pTexture.isReadable)
                throw new AccessViolationException($"Image {pTexture} is not readable");
            
            NativeArray<Color32> pixels = pTexture.GetRawTextureData<Color32>();
            int width = pTexture.width;
            int height = pTexture.height;
            
            ETileType[,] tileArray = new ETileType[width, height];
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * width + x;
                    tileArray[x, y] = ColorToType(pixels[index]);

                    if (tileArray[x, y] == ETileType.TBD)
                    {
                        Debug.Log($"{pTexture.name}; [{x}, {y}]; {pixels[index]}");
                    }
                }
            }

            pixels.Dispose();
            return tileArray;
        }
        
        /// <summary>
        /// Converts a Color value to an ETileType based on a bitwise mapping of RGB channels.
        /// </summary>
        /// <param name="pColor">The Color to convert.</param>
        /// <returns>An ETileType representing the tile type based on the color.</returns>
        public static ETileType ColorToType(Color pColor)
        {
            int v = 0;
            if (pColor.r > 0.5f) v |= 0b100;
            if (pColor.g > 0.5f) v |= 0b010;
            if (pColor.b > 0.5f) v |= 0b001;
            return (ETileType)v;
        }
        
        /// <summary>
        /// Converts a Color value to an ETileType based on a bitwise mapping of RGB channels.
        /// </summary>
        /// <param name="pColor">The Color to convert.</param>
        /// <returns>An ETileType representing the tile type based on the color.</returns>
        public static ETileType ColorToType(Color32 pColor)
        {
            int v = 0;
            if (pColor.r > 32) v |= 0b100;
            if (pColor.g > 32) v |= 0b010;
            if (pColor.b > 32) v |= 0b001;
            return (ETileType)v;
        }
        
        /// <summary>
        /// Converts an ETileType back to a Color based on the bitwise mapping used in ColorToType.
        /// </summary>
        /// <param name="pType">The ETileType to convert.</param>
        /// <returns>A Color representing the original color based on the tile type.</returns>
        public static Color TypeToColor(ETileType pType)
        {
            return new Color(
                ((int)pType & 0b100) != 0 ? 1 : 0,
                ((int)pType & 0b010) != 0 ? 1 : 0,
                ((int)pType & 0b001) != 0 ? 1 : 0);
        }
    }
}
