using System;
using System.Globalization;

class DescontoAtacado
{
    static void Main()
    {
        
        double totalDesconto = 0;
        double subtotal = 0;

        var gtins = new List<string>
        {
            "7891024110348",
            "7891048038017",
            "7896006334509",
            "7897000213142",
            "7894321171263",
            "7896001250611",
            "7793036013029",
            "7896004400914",
            "7898080640017",
            "7891025301516",
            "7891030003115"
        };

        var precoVarejo = new List<double>
        {
            2.88,
            4.40,
            5.19,
            2.39,
            9.79,
            9.89,
            12.79,
            4.20,
            6.99,
            12.99,
            3.12
        };

        var precoAtacado = new List<double>
        {
            2.51,
            4.37,
            0,
            2.38,
            0,
            9.10,
            12.35,
            4.05,
            6.89,  
            0,
            3.09
        };

        var quantidadeAtacado = new List<int>
        {
            12,
            3,
            0,
            6,
            0,
            10,
            3,
            6,
            12,
            0,
            4
        };

        var codigoCompras = new List<string>
        {
            "7891048038017",
            "7896004400914",
            "7891030003115",
            "7891024110348",
            "7898080640017",
            "7896004400914",
            "7897000213142",
            "7891048038017",
            "7793036013029",
            "7896006334509"
        };

        var comprasQuantidade = new List<int>
        {
            1,
            4,
            1,
            6,
            24,
            8,
            8,
            1,
            3,
            2
        };

        var descontoGTIN = new List<string>();
        var descontoPreco = new List<double>();

       for (int i = 0; i < codigoCompras.Count; i++)
        {
            string compradoGTIN = codigoCompras[i];
            int quantidadeComprada = comprasQuantidade[i];
        
            for (int j = 0; j < gtins.Count; j++)
            {
                if (compradoGTIN == gtins[j])
                {
                    double precoNormal = precoVarejo[j];
                    double precoDesconto = precoAtacado[j];
                    int quantidadeMinima = quantidadeAtacado[j];
        
                    if (precoDesconto > 0 && quantidadeComprada >= quantidadeMinima)
                    {
                        double precoTotal = precoDesconto * quantidadeComprada;
                        subtotal = subtotal + precoTotal;
        
                        double totalDescontoProduto = (precoNormal - precoDesconto) * quantidadeComprada;
                        totalDesconto = totalDesconto + totalDescontoProduto;
        
                        bool temitem = false;
        
                        for (int k = 0; k < descontoGTIN.Count; k++)
                        {
                            if (descontoGTIN[k] == compradoGTIN)
                            {
                                descontoPreco[k] = descontoPreco[k] + totalDescontoProduto;
                                temitem = true;
                                break;
                            }
                        }
        
                        if (!temitem)
                        {
                            descontoGTIN.Add(compradoGTIN);
                            descontoPreco.Add(totalDescontoProduto);
                        }
                    }
                    else
                    {
                        double precoTotal = precoNormal * quantidadeComprada;
                        subtotal = subtotal + precoTotal;
                    }
        
                    break;
                }
            }
        }


        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("- Desconto no Atacadão -");
        Console.ResetColor();

        for (int i = 0; i < descontoGTIN.Count; i++)
        {
            Console.WriteLine($"{descontoGTIN[i]}    R$ {descontoPreco[i]:F2}");
        }

        //vou chiorar
        //o valor n ta batendo :,)

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("------------------------");
        Console.ResetColor();

        Console.WriteLine($"Subtotal:      R$ {subtotal + totalDesconto:F2}");
        Console.WriteLine($"Descontos:     R$ {totalDesconto:F2}");
        Console.WriteLine($"Total:         R$ {subtotal:F2}");

    }
}
