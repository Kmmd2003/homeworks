#include <iostream>

using namespace std;

int main()
{
    int numbers[10][10];

    for(int i = 0; i < 10; i ++)
    {
        for(int j = 0; j < 10; j++)
        {
            cout << "addad ";
            cin >> numbers[i][j]; 
        }
    }
    int num = 0;
    int tekrar = 0;

    cout << "adad tekrari : ";
    cin >> num;
    for(int i = 0; i < 10; i ++)
    {
        for(int j = 0; j < 10; j++)
        {
            if(numbers[j][i] == num) {
                tekrar += 1;
            }
        }
    }
    cout << tekrar;

}