Console.WriteLine("Escribe el numero a multiplicar: ");
int numero = int.Parse(Console.ReadLine());

Console.WriteLine($"Tabla de multiplicar del numero {numero}: ");

for (int i = 1;  i <= 15; i++)
{
    int resultado = numero * i;
    Console.WriteLine($"{numero}x{i}={resultado}");
}

Console.ReadKey();
