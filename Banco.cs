using System;

class CuentaBancaria
{
    public string Numero { get; set; }
    public string Titular { get; set; }
    public double Saldo { get; set; }
    public CuentaBancaria Siguiente { get; set; } 

    public CuentaBancaria(string numero, string titular, double saldo)
    {
        Numero = numero;
        Titular = titular;
        Saldo = saldo;
        Siguiente = null;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Cuenta: {Numero}, Titular: {Titular}, Saldo: ${Saldo:F2}");
    }
}

class Banco
{
    private CuentaBancaria primeraCuenta;

    public Banco()
    {
        primeraCuenta = null;
    }

    public void AgregarCuenta(CuentaBancaria nuevaCuenta)
    {
        if (primeraCuenta == null)
        {
            primeraCuenta = nuevaCuenta;
        }
        else
        {
            CuentaBancaria actual = primeraCuenta;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevaCuenta;
        }
    }

    public void MostrarCuentas()
    {
        CuentaBancaria actual = primeraCuenta;
        while (actual != null)
        {
            actual.MostrarInformacion();
            actual = actual.Siguiente;
        }
    }

    public double CalcularSaldoTotal(CuentaBancaria actual = null)
    {
        if (actual == null)
            actual = primeraCuenta;
        
        if (actual == null)
            return 0;
        
        return actual.Saldo + CalcularSaldoTotal(actual.Siguiente);
    }
}

class Program
{
    static void Main()
    {
        Banco banco = new Banco();

        banco.AgregarCuenta(new CuentaBancaria("001", "Mari Pérez", 1500.00));
        banco.AgregarCuenta(new CuentaBancaria("002", "Alan Rivero", 3200.50));
        banco.AgregarCuenta(new CuentaBancaria("003", "Mau Chale", 2150.75));

        Console.WriteLine("Información de las cuentas:");
        banco.MostrarCuentas();

        double saldoTotal = banco.CalcularSaldoTotal();
        Console.WriteLine($"Saldo total del banco: ${saldoTotal:F2}");
    }
}
