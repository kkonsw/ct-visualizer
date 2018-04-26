using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace graphics_lab2
{
    class Bin
    {
        public static int X, Y, Z;
        public static short[] array;
        public Bin() { }

        public void readBIN(string path)
        {
            if (File.Exists(path))
            {
                BinaryReader reader =
                    new BinaryReader(File.Open(path, FileMode.Open));

                X = reader.ReadInt32();
                Y = reader.ReadInt32();
                Z = reader.ReadInt32();

                int arraySize = X * Y * Z;
                array = new short[arraySize];
                for (int i = 0; i < arraySize; ++i)
                {
                    array[i] = reader.ReadInt16();
                }

            }
        }
    }

    class MIP : Bin
    {
        public static short[] maxIntensityArray;

        public void SetUpIntensities()
        {
            int arraySize = X * Y;
            maxIntensityArray = new short[arraySize];
            short intensity = 0;
            short maxIntensity = 0;          

            for (int i = 0; i < X; ++i)
                for (int j = 0; j < Y; ++j)
                {
                    intensity = 0;
                    maxIntensity = 0;

                    for (int k = 0; k < Z; ++k)
                    {
                        int pixelNumber = i + j * X + k * X * Y;
                        intensity = array[pixelNumber];

                        if (intensity > maxIntensity)
                        {
                            maxIntensity = intensity;
                        }
                    }

                    maxIntensityArray[i + j * X] = maxIntensity;
                }
        }
    }
}
