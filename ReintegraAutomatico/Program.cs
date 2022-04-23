using ReintegrationSelf.Services;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ReintegraAutomatico
{
    class Program
    {
        static void Main(string[] args)
        {

        Login:
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Digite seu login");
            string login = Console.ReadLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Digite sua senha");
            string senha = Console.ReadLine();
            Console.WriteLine("--------------------------------------------");
        //string login = "raul.rangel@snd.com.br";
        //string senha = "1Cor15#33";  

        Restart:

            ReintegraAutoService reintegraAutoService = new ReintegraAutoService();
            reintegraAutoService.GoToScremLogin();

            if(!reintegraAutoService.GoToScremLogin())
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Pagina não existe");
                Console.WriteLine("Verifique se a pagina esta correta ou se o programa local esta rodando");
                Console.WriteLine("Deseja tentar novamente?");
                Console.WriteLine("s/n");
                string go = Console.ReadLine();

                if(go == "s")
                {
                   goto Restart;
                }
                else
                {
                   goto End;
                }
                
            }
            
            reintegraAutoService.LogaAuto(login, senha);

            if (reintegraAutoService.CheckScreamLogin())
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("ATENÇÃO");
                Console.WriteLine("Login ou Senha Invalidos");
                Console.WriteLine("--------------------------------------------");
                reintegraAutoService.CloseWindowns();
                goto Login;
            }
            
            reintegraAutoService.GoToReintegrationScrem();
            reintegraAutoService.ReintegraAuto();

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("A parentemente todos os produtos foram reintegrados!!!");
            Console.WriteLine("Deseja rodar novamente o ReintegrationSelf?");
            Console.WriteLine("S/N");

            string contunue = Console.ReadLine();

            if(contunue == "s")
            {
                goto Restart;
            }

            reintegraAutoService.CloseWindowns();
            reintegraAutoService.CloseWindowns();

        End:
            Environment.Exit(0);
            
        }
    }
}
