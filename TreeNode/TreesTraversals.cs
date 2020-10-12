using System;
using System.Collections.Generic;

namespace TreeNode
{
    public static class TreesTraversals<T> where T : struct
    {
        /// <summary>
        /// Кол-во листов в дереве.
        /// </summary>
        public static int CountLeaf(TreeNode<T> root)
        {
            int count = 0;
            if (root != null)
            {
                count += CountLeaf(root.Left);
                count += CountLeaf(root.Right);

                if (root.Left == null && root.Right == null) count++;
            }
            return count;
        }

        /// <summary>
        /// Вычисление глубины дерева.
        /// </summary>
        public static int Depth(TreeNode<T> root)
        {
            int depth = 0, depthLeft = 0, depthRight = 0;

            if (root == null) depth--;
            else
            {
                depthLeft = Depth(root.Left);
                depthRight = Depth(root.Left);

                depth = 1 + ((depthRight > depthLeft) ? depthRight : depthLeft);
            }
            return depth;
        }



        /// <summary>
        /// Горизонтальная печать дерева.
        /// </summary>
        public static void PrintTreeH(TreeNode<T> root, int level)
        {
            const int spaceBlock = 6;

            void PrintSpaces(int num)
            {
                for (int i = 0; i < num; i++)
                {
                    Console.Write(" ");
                }
            }

            if (root != null)
            {
                PrintTreeH(root.Right, level + 1);
                PrintSpaces(spaceBlock + level);
                Console.WriteLine(root.Data);
                PrintTreeH(root.Left, level + 1);
            }
        }

        /// <summary>
        /// Вертикальная печать дерева
        /// </summary>
        public static void PrintTreeV(TreeNode<T> root)
        {
            int depth = Depth(root);
            int width = (int)Math.Pow(2, Depth(root));
            int conutOfEl = 0;
            T? data;

            for (int level = 0; level < depth + 1; level++)
            {
                conutOfEl = (int)Math.Pow(2, level);
                for (int j = 0; j < conutOfEl; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        Console.Write(" ");
                    }
                    data = AccessToData(root, level, j);
                    Console.Write((data != null) ? $"{data}" : $"=");
                    for (int i = 0; i < width - 1; i++)
                    {
                        Console.Write(" ");
                    }
                }
                width /= 2;
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Доступ к элементу дерева по указанному уровню и номеру элемента в данном уровне нумерация с нуля
        /// </summary>
        static T? AccessToData(TreeNode<T> root, int level, int numEl)
        {
            //Определим кол-во эл в уровне
            int countOfEl = (int)Math.Pow(2, level);
            //выход если номер эл больше кол-ва эл в уровне
            if (numEl >= countOfEl) return null;

            //Объявим и определим список с направлением поиска элемента
            List<bool> directionSearch = new List<bool>();
            while (countOfEl > 1)
            {
                countOfEl /= 2;

                //При true направление влево
                //При false направление вправо

                if (numEl >= countOfEl)
                {
                    directionSearch.Add(false);
                    numEl -= countOfEl;
                }
                else
                {
                    directionSearch.Add(true);
                }
            }

            //Пройдем дерево по направлению
            foreach (bool direction in directionSearch)
            {
                //Влево
                if (direction == true)
                {
                    if (root.Left != null)
                    {
                        //Переместим ссылку на левого потомка
                        root = root.Left;
                    }
                    else return null;
                }
                //Вправо
                else
                {
                    if (root.Right != null)
                    {
                        //Переместим ссылку на правого потомка
                        root = root.Right;
                    }
                    else return null;
                }
            }
            return root.Data;
        }


        /// <summary>
        /// Удаление дерева.
        /// </summary>
        public static void DeleteTree(ref TreeNode<T> root)
        {
            root.Delete();
            root = null;
        }

        /// <summary>
        /// Копировать дерево.
        /// </summary>
        public static TreeNode<T> CopyTree(TreeNode<T> root)
        {
            TreeNode<T> newL, newR;

            if (root == null) return null;

            newL = (root.Left != null) ? CopyTree(root.Left) : null;
            newR = (root.Right != null) ? CopyTree(root.Right) : null;

            return new TreeNode<T>(root.Data, newL, newR);
        }
    }
}
