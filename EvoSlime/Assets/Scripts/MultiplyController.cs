using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyController : MonoBehaviour
{
    // Update is called once per frame
    public Item parent1;
    public Item parent2;
    public Item child;
    static MultiplyController instance;

    private void Start()
    {
        child.Genes = Mutiply(parent1.Genes, parent1.Genes);
    }


    public static int xLength = 10, yLength = 20;//数组的1维和2维 下版本可以改成动态的 

    static string Mutiply(string ParentGenes1, string ParentGenes2)
    {
        int[,] parent1 = BuildGenesArray(ParentGenes1);
        int[,] parent2 = BuildGenesArray(ParentGenes2);
        int[,] gamate1 = GameteProduce(parent1);
        int[,] gamate2 = GameteProduce(parent2);
        int[,] childGenesArray = GamateCombine(gamate1, gamate2);
        string childGenesString = BuildGenesString(childGenesArray) ;
        return childGenesString;
    }
    static int[,] BuildGenesArray(string GenesCode)
    {
        int[,] parent = new int[yLength, xLength];
        for (int temp = 0; temp < GenesCode.Length; temp++)
        {
            parent[temp / 10, temp % 10] = Convert.ToInt32(GenesCode[temp]) - 48;//Convert后续可以改成unity的函数
        }
        return parent;
    }
    static string BuildGenesString(int[,] GenesArray)
    {
        string parent = string.Empty;
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i <10; i++)
            {
                parent += Convert.ToString(GenesArray[j, i]) ;
            }
            if (GenesArray[j+1, 0] == 0 && GenesArray[j+1, 1] == 0)
            {
                parent += "\n";
                break;
            }
        }
        return parent;
    }
    static int[,] GameteProduce(int[,] genes)//获得基因，生成配子
    {
        int[,] gamate = new int[yLength, xLength / 2 + 1];
        for (int j = 0; j < genes.GetLength(1); j++)
        {
            gamate[j, 0] = genes[j, 0];
            gamate[j, 1] = genes[j, 1];
            for (int i = 2; i < 10; i += 2)
            {
                if (genes[j, i] == genes[j, i + 1])
                {
                    gamate[j, (i + 2) / 2] = genes[j, i];//i/2是为了防止数组越界
                }
                else
                {
                    gamate[j, (i + 2) / 2] = Random.Range(0, 99999) % 2;//取0，1 后续可以改成unity的随机函数
                }
            }
            if (genes[j, 0] == 0 && genes[j, 1] == 0)
                break;
        }
        return gamate;
    }

    static int[,] GamateCombine(int[,] gamate1, int[,] gamate2)
    {
        int count1 = 0, count2 = 0;
        int count = 0;
        int[,] child = new int[yLength, xLength];
        for (int j = 0; j < yLength; j++)
        {
            if (gamate1[j, 0] != 0 || gamate1[j, 1] != 0)
                count1++;
            if (gamate2[j, 0] != 0 || gamate2[j, 1] != 0)
                count2++;
        }
        for (int i = 0; i <= count1; i++)
        {
            for (int j = 0; j <= count2; j++)
            {
                if ((gamate2[j, 0] == gamate1[i, 0] && gamate2[j, 1] == gamate1[i, 1]) && (gamate2[j, 0] != 0 || gamate2[j, 1] != 0))
                {
                    child[count, 0] = gamate1[i, 0];
                    child[count, 1] = gamate1[i, 1];
                    gamate1[i, 0] = 0;
                    gamate1[i, 1] = 0;
                    gamate2[j, 0] = 0;
                    gamate2[j, 1] = 0;
                    for (int k = 2; k < 10; k += 2)
                    {
                        child[count, k] = gamate1[i, (k + 2) / 2];
                        child[count, k + 1] = gamate2[i, (k + 2) / 2];
                    }
                    count++;
                }
            }
        }
        for (int i = 0; i <= count1; i++)
        {
            if (gamate1[i, 0] != 0 && gamate1[i, 1] != 0)
            {
                child[count, 0] = gamate1[i, 0];
                child[count, 1] = gamate1[i, 1];
                for (int k = 2; k < 10; k += 2)
                {
                    child[count, k] = gamate1[i, (k + 2) / 2];
                }
                count++;
            }
        }
        for (int j = 0; j <= count2; j++)
        {
            if (gamate2[j, 0] != 0 && gamate2[j, 1] != 0)
            {
                child[count, 0] = gamate2[j, 0];
                child[count, 1] = gamate2[j, 1];
                for (int k = 2; k < 10; k += 2)
                {
                    child[count, k] = gamate2[j, (k + 2) / 2];
                }
                count++;
            }
        }
        return child;
    }
}
