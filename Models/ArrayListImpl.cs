namespace intervie.Models
{
    public class ArrayListImpl
    {

        private int[] data; //ячейки с даннными
        private int filledCells; // количество занятых ячеек
        private int capacity; // общий размер массива

        public int Size { get { return filledCells; } }
        public bool IsEmpty { get { return filledCells == 0; } }

        public ArrayListImpl(int initCapacity = 5)
        {
            if (initCapacity < 1) initCapacity = 1;
            this.capacity = initCapacity;
            data = new int[capacity];
        }

        public int GetIntAt(int index)
        { // получить элемент с индексом
            ThrowIfIndexOutOfRange(index);
            return data[index];
        }

        public void Add(int num)
        { //добавление нового элемента в список
            if (filledCells == capacity) Resize();
            data[filledCells++] = num;
        }
        public void Clear()
        { //очистить список
            data = new int[capacity];
            filledCells = 0;
        }
        private void Resize()
        { //изменение размерности
            int[] resize = new int[capacity * 2];
            for (int i = 0; i < capacity; i++) resize[i] = data[i];
            data = resize;
            capacity *= 2;
        }

        public void InsertAt(int x, int index)
        {
            ThrowIfIndexOutOfRange(index);
            if (filledCells == capacity) Resize();
            for (int i = filledCells; i > index; i--) data[i] = data[i - 1];
            data[index] = x;
            filledCells++;
        }
        public void RemoveAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            for (int i = index; i < filledCells - 1; i++) data[i] = data[i + 1];
            data[filledCells - 1] = default(int);
            filledCells--;
        }

        private void ThrowIfIndexOutOfRange(int index)
        { // попытка получить то чего нету
            if (index > filledCells - 1 || index < 0) throw new IndexOutOfRangeException();
        }

    }
}
