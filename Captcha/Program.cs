// See https://aka.ms/new-console-template for more information
using Captcha;

Console.WriteLine("Hello, World!");


var captcha = new CaptchaService();

captcha.Generate("captcha1.jpeg");