int[] arr = InitArray();
//int[] arr = new int[] { 1, 5, 6, 7, 2 };

// Це демонстрація швидкого сортування - перша частина лабки
//QuickSort(arr, 0, arr.Length - 1);

// Це друга - порядкові статистики
RandomizedSelect(arr);

ShowArray(arr);


void ShowArray(int[] arr)
{
    Console.WriteLine("Sorted array:");
    for (int i = 0; i < arr.Length; i++)
        Console.WriteLine(arr[i]);
}

int[] InitArray()
{
    Console.WriteLine("Hello! What size will the array be?");
    bool isCorrectInput = int.TryParse(Console.ReadLine(), out int size);
    if (isCorrectInput)
    {
        int[] arr = new int[size];
        Console.WriteLine("Now input your numbers:");
        for (int i = 0; i < size; i++)
        {
            var isCorrect = int.TryParse(Console.ReadLine(), out int item);
            if (isCorrect)
            {
                arr[i] = item;
            }
            else
            {
                Console.WriteLine("Please input number");
                Environment.Exit(100);
            }
        }
        return arr;
    }
    else
    {
        Console.WriteLine("Please input number!");
        Environment.Exit(100);
        return new int[0];
    }

}

int[] QuickSort(int[] arr, int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex)
        return arr;

    int pivot = FindPivot(arr, minIndex, maxIndex);
    QuickSort(arr, minIndex, pivot - 1);
    QuickSort(arr, pivot + 1, maxIndex);

    return arr;
}

int FindPivot(int[] arr, int minIndex, int maxIndex)
{
    int pivot = minIndex - 1;
    for (int i = minIndex; i < maxIndex; i++)
    {
        if (arr[i] < arr[maxIndex])
        {
            pivot++;
            Swap(ref arr[i], ref arr[pivot]);
        }
    }

    pivot++;
    Swap(ref arr[pivot], ref arr[maxIndex]);

    return pivot;
}

int FindMinElement(int[] arr, int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex)
        return arr[maxIndex];

    int pivot = FindPivot(arr, minIndex, maxIndex);

    // Повертають останні елементи підмасивів
    int min1 = FindMinElement(arr, minIndex, pivot - 1);
    int min2 = FindMinElement(arr, pivot + 1, maxIndex);

    // і тепер ми звіряємо останні елементи підмасивів та повертаєм менший
    return min1 < min2 ? min1 : min2;
}

// аналогічно з максимальним
int FindMaxElement(int[] arr, int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex)
        return arr[maxIndex];

    int pivot = FindPivot(arr, minIndex, maxIndex);
    int max1 = FindMaxElement(arr, minIndex, pivot - 1);
    int max2 = FindMaxElement(arr, pivot + 1, maxIndex);

    return max1 > max2 ? max1 : max2;
}

int[] FindMediana(int[] arr)
{
    if (arr.Length % 2 == 0)
        return new int[] { arr[(arr.Length - 1) / 2], arr[arr.Length / 2] };
    else
        return new int[] { arr[(arr.Length - 1) / 2] };
}

void RandomizedSelect(int[] arr)
{
    Console.WriteLine("Min: " + FindMinElement(arr, 0, arr.Length - 1));
    Console.WriteLine($"Max: " + FindMaxElement(arr, 0, arr.Length - 1));

    var medArr = FindMediana(arr);
    if (medArr.Length < 2)
        Console.WriteLine("Midiana: " + medArr[0]);
    else
        Console.WriteLine("Mediana: " + medArr[0] + " | " + medArr[1]);
}

void Swap(ref int x, ref int y)
{
    var tmp = x;
    x = y;
    y = tmp;
}