using System;

namespace RANA
{
    public static class Charco
    {

        public static int ComiendoChocolates(bool[,] chocos, int[] ranas)
        {
            int chocolatesComidos = 0;
            int result = 0;
            ComiendoChocolates(chocos, ranas, ref chocolatesComidos, ref result, 0, 0);
            return result;
            throw new Exception();
        }
        static void ComiendoChocolates(bool[,] chocos, int[] actualCoordFrogs, ref int chocolatesComidos, ref int result, int row, int ranaActual)
        {
            if (ranaActual == 0)
            {
                for (int i = 0; i < actualCoordFrogs.Length; i++)
                {
                    if (chocos[row, actualCoordFrogs[i]])//si hay chocolate
                        chocolatesComidos++;
                }
            }

            if (row + 1 >= chocos.GetLength(0))//llegaste final
            {
                if (chocolatesComidos > result)
                {
                    int temp = chocolatesComidos;
                    result = temp;
                }
                chocolatesComidos = 0;
                return;
            }


            if (actualCoordFrogs[ranaActual] - 1 < 0)//no izq  coordFrogs[row][ranaActual]<= fue lo q cambie
            {
                if (ContainsRepitedElements(actualCoordFrogs))
                {
                    return;
                }

                ComiendoChocolates(chocos, actualCoordFrogs, ref chocolatesComidos, ref result, ranaActual + 1 >= actualCoordFrogs.Length ? row + 1 : row, ranaActual + 1 >= actualCoordFrogs.Length ? 0 : ranaActual + 1);//arreglar array

            }
            else
            {
                actualCoordFrogs[ranaActual] -= 1;
                if (ContainsRepitedElements(actualCoordFrogs))
                {
                    actualCoordFrogs[ranaActual] += 1;
                    return;
                }


                ComiendoChocolates(chocos, actualCoordFrogs, ref chocolatesComidos, ref result, ranaActual + 1 >= actualCoordFrogs.Length ? row + 1 : row, ranaActual + 1 >= actualCoordFrogs.Length ? 0 : ranaActual + 1);//arreglar array

            }
            if (actualCoordFrogs[ranaActual] + 1 >= chocos.GetLength(1))//no derecha
            { return; }

            actualCoordFrogs[ranaActual] += 1;
            if (ContainsRepitedElements(actualCoordFrogs))
            {
                actualCoordFrogs[ranaActual] -= 1;
                return;
            }

            ComiendoChocolates(chocos, actualCoordFrogs, ref chocolatesComidos, ref result, ranaActual + 1 >= actualCoordFrogs.Length ? row + 1 : row, ranaActual + 1 >= actualCoordFrogs.Length ? 0 : ranaActual + 1);//arreglar array

            return;
        }
        private static bool ContainsRepitedElements(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                        return true;
                }
            }
            return false;
        }
    }
}