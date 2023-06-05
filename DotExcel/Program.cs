using System;
using OfficeOpenXml;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using DotExcel;

class Program
{
    public static void Main(string[] args)
    {
        Menu();
        Console.ReadKey();
    }
    public static void Menu()
    {
        Acoes a = new Acoes();
        int i = 1;
        Pessoa p;
        while (i > 0 && i <= 3)
        {
            i = 0;
            Console.Write("Olá, bem-vindo ao menu. Escolha uma das opções:\n1-)Importar informações do Excel\n2-)Consultar banco de dados\n3-)Atualizar alguma informação\n4-)Sair\n");
            i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    a.FuncaoExcel();
                    break;
                case 2:
                    a.ConsultaTipos();
                    break;
                case 3:
                    a.UpdateBd();
                    break;
                case 4:
                    break;
                
            }
        }
    }
}
