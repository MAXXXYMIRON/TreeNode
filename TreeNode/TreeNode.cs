namespace TreeNode
{
    /// <summary>
    /// Класс TreeNode предстовляет узел бинарного дерева,
    /// данные содержащиеся в узле должны иметь тип значения
    /// </summary>
    class TreeNode<T> where T : struct
    {
        /// <summary>
        /// Левый потомок узла
        /// </summary>
        public TreeNode<T> Left { get; internal set; }
        /// <summary>
        /// Правый потомок узла
        /// </summary>
        public TreeNode<T> Right { get; internal set; }

        /// <summary>
        /// Данные узла
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="data">Неизменяемые внутри конструктора данные узла</param>
        /// <param name="left">Неизменяемая ссылка на левого потомка узла</param>
        /// <param name="right">Неизменяемая ссылка на парвого потомка узла</param>
        public TreeNode(in T data, in TreeNode<T> left = null, in TreeNode<T> right = null)
        {
            Data = data;

            Left = left;
            Right = right;
        }

        /// <summary>
        /// Удаление всех потомков узла.
        /// </summary>
        public void Delete()
        {
            Left?.Delete();
            Right?.Delete();
            Left = null;
            Right = null; 
        }
    }
}
