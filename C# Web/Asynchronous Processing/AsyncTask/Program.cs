// See https://aka.ms/new-console-template for more information
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());

Thread thread = new Thread(() =>
{
    for (int i = a; i <= b; i++)
    {
        if (i%2==0)
        {
            Console.WriteLine(i);
        }
    }
});
thread.Start();
thread.Join();


Console.WriteLine("Thread finished work");
