using System;
using System.Security.Cryptography;
using System.Linq;

namespace App
{
    internal class Project
    {
        public static Int16 SIZE = 9;                 // سایز جدول سودوکو
        public static Int16 UNASSIGNED = 0;           // نمایشگر خانه خالی 
        public static Int16 RANDOMFILLER = 2;         // عدد ورودی متناسب با پر کردن رندوم
        public static Int16 USERFILLER = 1;           // عدد ورودی متناسب با پر کردن توسط کاربر
        public static double SPEED = 0.03;                 // سرعت حل        

        public static void Main()
        {
            int[,] sudoku = new int[SIZE, SIZE];
            SudokuSolver S = new SudokuSolver(UNASSIGNED, SIZE, RANDOMFILLER, USERFILLER, SPEED, sudoku);
            //انتخاب پر کردن سودوکو با کاربر یا پر کردن رندوم توسط برنامه
            int opt = 0;
            Console.WriteLine("Enter the option you want: \n"
            + "1-Fill sudoku yourself\n"
            + "2-Fill sudoku random");
            opt = Convert.ToInt16(Console.ReadLine());
            if (opt == USERFILLER)
            {
                S.sudokuFiller();
            }
            else
            {
                // گرفتن تعداد خانه های پر شده در یک ردیف 
                int difficulty = 0;
                Console.WriteLine("Enter Difficulty: (between 2-4 for quick result)");
                difficulty = Convert.ToInt16(Console.ReadLine());
                S.fillRandSudoku(difficulty);
            }

            // چاپ سودوکو اولیه
            Console.WriteLine("The sudoku :");
            S.printCurrentSudoku();

            S.solver();
        }
    }
    internal class SudokuSolver
    {
        private Int16 unassigned;
        private Int16 size;
        private Int16 randomfiller;
        private Int16 userfiller;
        private double speed;
        private int[,] sudoku;

        public Int16 Unassigned
        {
            get { return unassigned; }
            set { unassigned = value; }
        }
        public Int16 Size
        {
            get { return size; }
            set { size = value; }
        }
        public Int16 Randomfiller
        {
            get { return randomfiller; }
            set { randomfiller = value; }
        }
        public Int16 Userfiller
        {
            get { return userfiller; }
            set { userfiller = value; }
        }
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int[,] Sudoku
        {
            get { return sudoku; }
            set { sudoku = value; }
        }

        public SudokuSolver(Int16 unassigned, Int16 size, Int16 randomfiller, Int16 userfiller, double speed, int[,] sudoku)
        {
            Unassigned = unassigned;
            Size = size;
            Randomfiller = randomfiller;
            Userfiller = userfiller;
            Speed = speed;
            Sudoku = sudoku;
        }
        public SudokuSolver() { }


        // پر کردن جدول سودوکو توسط کاربر
        // آرایه ای که سودوکو در ان قراره پر بشود
        public int[,] sudokuFiller()
        {
            int userInpInt = unassigned;
            string? userInpStr;
            bool isExists = false;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.WriteLine("The current sudoku:");
                    printCurrentSudoku();
                    do
                    {
                        Console.WriteLine("Enter el [" + i + "][" + j + "]:");
                        userInpStr = Console.ReadLine();
                        if (
                            userInpStr == "" ||
                            userInpStr == " " ||
                            userInpStr == null)
                        {
                            userInpInt = unassigned;
                        }
                        else
                        {
                            userInpInt = Convert.ToInt16(userInpStr);
                        }
                        if (userInpInt > 9 || userInpInt < 0)
                        {
                            Console.WriteLine("ERR:enter number between 0-9(space or enter for skipping) !!!");
                        }
                        isExists = checkDuplicateNum(userInpInt, i, j);

                        if (isExists && userInpInt != unassigned)
                        {
                            Console.WriteLine("dont repeat two num in row or col تو سطر یا ستون یه عدد یکسان هست");
                        }
                        else
                        {
                            isExists = false;
                        }
                    } while ((userInpInt > 9 || userInpInt < 0) || isExists);

                    sudoku[i, j] = userInpInt;
                }
            }
            return sudoku;
        }

        // چاپ سودوکو فعلی
        // سودوکوای که باید چاپ بشه
        public void printCurrentSudoku()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(sudoku[i, j]);
                    if (j != 0 || j != size)
                    {
                        Console.Write("|");
                    }

                }
                Console.Write("\n------------------\n");
            }
        }

        // <summary>چک کردن قوانین تکرار تو سودوکو
        // <param name="num">عددی که قراره وارد بشه
        // <param name="sudoku">جدول سودوکو
        // <param name="x">تو چه سطری قراره وارد بشه
        // <param name="y">تو چه ستونی قراره وارد بشه
        private bool checkDuplicateNum(int num, int x, int y)
        {
            bool isExists = false;
            for (int i = 0; i < size; i++)
            {

                if (sudoku[i, y] == num)
                {
                    isExists = true;
                }

                if (sudoku[x, i] == num)
                {
                    isExists = true;
                }
            }

            return isExists;
        }

        // چک کردن پر بودن سودوکو

        private bool isFullSudoku()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (sudoku[i, j] == unassigned)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // پر کردن رندوم جدول سودوکو
        // تعدادی که باید پر بشه تو هر  خونه
        public void fillRandSudoku(int difficulty)
        {
            int[] rands = new int[difficulty];
            Random r = new Random();
            Random r2 = new Random();
            for (int i = 0; i < size; i++)
            {

                for (int k = 0; k < difficulty; k++)
                {
                    rands[k] = r.Next(0, size);
                }


                for (int j = 0; j < size; j++)
                {
                    if (rands.Contains(j))
                    {
                        for (int z = 0; z < size; z++)
                        {
                            if (!checkDuplicateNum(z, i, j))
                            {
                                sudoku[i, j] = z;
                            }
                        }
                    }
                }
            }
        }

        // حل سودوکو به صورت بازگشتی
        // پوینتر به سودوکو برای تغییر کردن مقدار پارامتر پاس داده شده
        public bool solver()
        {
            // چاپ هر مرحله از حل سودوکو
            Console.Clear();
            printCurrentSudoku();
            System.Threading.Thread.Sleep(
    (int)System.TimeSpan.FromSeconds(speed).TotalMilliseconds);
            Console.WriteLine("----------------------");


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (sudoku[i, j] == unassigned)
                    {
                        for (int n = 1; n <= size; n++)
                        {
                            // اگر عددی بین صفر تا نه هست که قوانین تکرارو نقض نکنه اون رو قرار میدیم
                            if (!checkDuplicateNum(n, i, j))
                            {
                                sudoku[i, j] = n;
                                // اگر به پابان رسیده حل سودوکو از متود بیا بیرون
                                if (solver())
                                {
                                    return true;
                                }
                                else
                                {
                                    // در غیر اینصورت یعنی تمامی اعداد بین صفر تا نه مرحله بعدی ممکن نبوده تو اون خانه قرار بگیره پس حانه قبلی رو خالی میکنیم
                                    sudoku[i, j] = unassigned;
                                }
                            }
                        }
                        // تمامی  اعداد ممکن نمیتوانند قرار بگیرند پس برمیگردیم مرحله قبل تا یه عدد دیگه جایگزین کنیم
                        return false;
                    }
                }
            }

            // حلقه اصلی تمام شد پس از متود بیا بیرون
            return true;

        }

    }
}