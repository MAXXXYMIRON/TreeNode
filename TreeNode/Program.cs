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
            TreeNode<int> node = new TreeNode<int>(1,//Данные корня
                new TreeNode<int>(2, //Данные левого потомка корня
                    new TreeNode<int>(4), //Данные левого потомка левого потомка корня
                    new TreeNode<int>(5)), //Данные правого потомка левого потомка корня
                new TreeNode<int>(3)); //Данные правого потомка корня

            Console.WriteLine(AccessToData(node, 0, 0));//Данные корня
            Console.WriteLine(AccessToData(node, 1, 1));//Данные правого потомка корня
            Console.WriteLine(AccessToData(node, 1, 0));//Данные левого потомка корня
            Console.WriteLine(AccessToData(node, 2, 1));//Данные правого потомка левого потомка корня
            Console.WriteLine(AccessToData(node, 2, 0));//Данные левого потомка левого потомка корня

            //Удалить дерево
            node.Delete();
            node = null;

            Console.ReadKey();
        }



        //Доступ к элементу дерева
        //по указанному уковню и номеру элемента в данном уровне
        //нумерация с нуля
        static T? AccessToData<T> (TreeNode<T> root, int level, int numEl) where T : struct
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
                if (numEl < countOfEl) directionSearch.Add(true);
                //При true направление вправо
                else directionSearch.Add(false);
            }

            //Пройдем дерево по направлению
            foreach (bool direction in directionSearch)
            {
                //Влево
                if(direction == true)
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
    }
}
