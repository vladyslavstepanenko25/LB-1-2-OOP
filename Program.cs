using System;

namespace LB_1_2
{
    public class RList
    {
        public int info;
        public RList next;

        //1.Конструктор з одним параметром (число);

        public RList(int i)
        {
            info = i;
            next = null;
        }

        //3. Конструктор копіювання;

        public RList(RList copy)
        {
            if (copy == null) return;

            this.info = copy.info;

            if (copy.next != null)
            {
                this.next = new RList(copy.next);
            }
            else
            {
                this.next = null;
            }
        }

        //6. Рекурсивний метод додавання нового елемента останнім у список;

        public void AddLast(int newValue)
        {
            if (next == null)
            {
                next = new RList(newValue);
            }
            else
            {
                next.AddLast(newValue);
            }
        }

        //10. Метод додавання нового елементу у список після елемента із заданим значенням;

        public void AddAfter(int SearchValue, int newValue)
        {
            if (this.info == SearchValue)
            {
                RList newNode = new RList(newValue, this.next);
                this.next = newNode;
            }
            else
            {
                if (next != null)
                {
                    next.AddAfter(SearchValue, newValue);
                }
                else
                {
                    Console.WriteLine($"Значення {SearchValue} не знайдено у списку.");
                }
            }
        }

        // 15. Рекурсивний метод видалення останнього в списку елемента;

        public void RemoveLast()
        {
            if (next == null) return;

            if (next.next == null)
            {
                next = null;
            }
            else
            {
                next.RemoveLast();
            }
        }

        // 16. Рекурсивний метод видалення n-ного за рахунком елемента;

        public void RemoveAt(int n)
        {
            if (n < 0) return;

            if (n == 2 && next != null) next = next.next;
            else if (next != null) next.RemoveAt(n - 1);
        }

        public RList(int i, RList n)
        {
            info = i;
            next = n;
        }
        
        // 30. Не рекурсивний метод друку всіх непарних значень елементів списку;

        public void PrintOddValues()
        {
            RList current = this;

            Console.WriteLine("Непарнi значення в списку:");
            while (current != null)
            {
                if (current.info % 2 != 0)
                {
                    Console.Write(current.info + " ");
                }

                current = current.next;
            }
        }

        // 44. Метод підрахунку суми значень елементів списку;

        public int Sum()
        {
            if (next == null) return info;
            else
            {
                return info + next.Sum();
            }
        }

        //50 .Властивість First для зчитування та установки значення першого елемента в списку;

        public int First
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }

        //63. Перевизначити для списку операцію +

        public static RList operator +(RList list1, RList list2)
        {
            if (list1 == null && list2 == null) return null;

            int val1 = (list1 != null) ? list1.info : 0;
            int val2 = (list2 != null) ? list2.info : 0;

            RList result = new RList(val1 + val2);

            result.next = (list1?.next + list2?.next);

            return result;
        }

        //79. Перевизначити для списку будь-яку операцію (Перевизначити для списку операцію ++)

        public static RList operator ++(RList list)
        {
            if (list == null) return null;

            RList result = new RList(list.info + 1);

            result.next = ++list.next;

            return result;
        }

        // Для виводу списку

        public void Print()
        {
            RList current = this;

            while (current != null)
            {
                Console.Write(current.info + " -> ");
                current = current.next;
            }
            Console.WriteLine();
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("----Перевiрка----");

                RList original = new RList(1, new RList(2, new RList(3)));
                Console.WriteLine("Оригiнал: ");
                original.Print();
                RList cloned = new RList(original);

                original.info = 10;
                original.next.info = 20;

                Console.WriteLine("Оигiнал (пiсля змiн): ");
                original.Print();
                Console.WriteLine("Копiя: ");
                cloned.Print();

                Console.WriteLine();

                RList testList = new RList(10, new RList(30));
                testList.AddLast(40);
                Console.WriteLine("Список пiсля додавання: ");
                testList.Print();

                Console.WriteLine();

                testList.AddAfter(10, 20);
                Console.WriteLine("Додано 20 пiсля 10 в тестовому списку:");
                testList.Print();
                testList.AddAfter(40, 50);
                Console.WriteLine("Додано 50 пiсля 40 в тестовому списку:");
                testList.Print();

                Console.WriteLine();

                testList.RemoveLast();
                Console.WriteLine("Список пiсля видалення останнього елемента:");
                testList.Print();

                Console.WriteLine();

                RList test2List = new RList(1, new RList(2, new RList(3, new RList(4, new RList(5)))));
                test2List.RemoveAt(4);
                Console.WriteLine("Список пiсля видалення 4-го елемента:");
                test2List.Print();

                Console.WriteLine();

                RList printtestList = new RList(1, new RList(2, new RList(3, new RList(4, new RList(5)))));
                Console.WriteLine("Повний список: ");
                printtestList.Print();
                printtestList.PrintOddValues();

                Console.WriteLine();
                Console.WriteLine();

                RList sumtestList = new RList(10, new RList(20, new RList(30, new RList(40, new RList(50)))));
                Console.WriteLine("Список для пiдрахунку суми: ");
                sumtestList.Print();
                int totalSum = sumtestList.Sum();
                Console.WriteLine("Сума елементiв списку: " + totalSum);

                Console.WriteLine();

                RList firstTestList = new RList(5, new RList(10, new RList(15)));
                Console.WriteLine("Перший елемент списку: " + firstTestList.First);
                firstTestList.First = 20;
                Console.WriteLine("Перший елемент списку пiсля змiни: " + firstTestList.First);

                Console.WriteLine();

                RList A = new RList(10, new RList(20));
                RList B = new RList(1, new RList(2, new RList(3)));
                Console.WriteLine("Список A: ");
                A.Print();
                Console.WriteLine("Список B: ");
                B.Print();
                RList C = A + B;
                Console.WriteLine("Список C: ");
                C.Print();

                Console.WriteLine();

                RList D = new RList(5, new RList(10, new RList(15)));
                Console.WriteLine("Список D: ");
                D.Print();
                RList E = D++;
                Console.WriteLine("Список D пiсля операцiї ++: ");
                E.Print();
            }
        }
    }
}

