using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создадим дерева с английским алфавитом
            TreeNode<char> liter = new TreeNode<char>('A');

            liter.Left = new TreeNode<char>('B');
            liter.Right = new TreeNode<char>('C');

            liter.Left.Left = new TreeNode<char>('D');
            liter.Left.Right = new TreeNode<char>('E');
            liter.Right.Left = new TreeNode<char>('F');
            liter.Right.Right = new TreeNode<char>('G');

            liter.Left.Left.Left = new TreeNode<char>('H');
            liter.Left.Left.Right = new TreeNode<char>('I');
            liter.Left.Right.Left = new TreeNode<char>('J');
            liter.Left.Right.Right = new TreeNode<char>('K');
            liter.Right.Left.Left = new TreeNode<char>('L');
            liter.Right.Left.Right = new TreeNode<char>('M');
            liter.Right.Right.Left = new TreeNode<char>('N');
            liter.Right.Right.Right = new TreeNode<char>('O');

            liter.Left.Left.Left.Left = new TreeNode<char>('P');
            liter.Left.Left.Left.Right = new TreeNode<char>('Q');
            liter.Left.Left.Right.Left = new TreeNode<char>('R');
            liter.Left.Left.Right.Right = new TreeNode<char>('S');
            liter.Left.Right.Left.Left = new TreeNode<char>('T');
            liter.Left.Right.Left.Right = new TreeNode<char>('U');
            liter.Left.Right.Right.Left = new TreeNode<char>('V');
            liter.Left.Right.Right.Right = new TreeNode<char>('W');
            liter.Right.Left.Left.Left = new TreeNode<char>('X');
            liter.Right.Left.Left.Right = new TreeNode<char>('Y');
            liter.Right.Left.Right.Left = new TreeNode<char>('Z');

            Console.WriteLine($"Кол-во листов дерева = {TreesTraversals<char>.CountLeaf(liter)}\n");
            Console.WriteLine($"Глубина дерева = {TreesTraversals<char>.Depth(liter)}\n");
            Console.WriteLine($"Горизонтальная печать дерева - \n");
            TreesTraversals<char>.PrintTreeH(liter, 0);

            //Скопируем дерево
            TreeNode<char> literCopy = TreesTraversals<char>.CopyTree(liter);
            //Удалим старое дерево
            TreesTraversals<char>.DeleteTree(ref liter);
            Console.WriteLine($"Удаленное дерево - {liter}\n");
            Console.WriteLine($"Вертикальная печать скопрованного дерева - \n");
            TreesTraversals<char>.PrintTreeV(literCopy);

            Console.ReadKey();
        }
    }
}
