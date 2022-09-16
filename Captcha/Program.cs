// See https://aka.ms/new-console-template for more information
using Captcha;

Console.WriteLine("Hello, World!");


var captcha = new CaptchaService();

var rand = new Random();

for (int i = 0; i < 20; i++)
{
    captcha.Generate($"captcha{rand.Next(1,1000)}.jpeg");
}