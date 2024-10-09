using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Noksan_Music_Web.Models;
using Noksan_Music_Web.Data;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Noksan_Music_Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NoksanMusicWebContext _context;

    public HomeController(ILogger<HomeController> logger, NoksanMusicWebContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    // Admin Login Page (GET)
    public IActionResult AdminEntry()
    {
        return View();
    }

    //Admin Login Process (POST)
    [HttpPost]
    public IActionResult AdminEntry(string kullaniciAdi, string sifre)
    {
        if (kullaniciAdi == "admin" && sifre == "password")
        {
            //Session'a admin olduğunu işaretle
            HttpContext.Session.SetString("Admin", "true");
            return RedirectToAction("Panel");
        }
        ViewBag.Hata = "Geçersiz kullanıcı adı veya şifre.";
        return View();
    }

    // Yönetim Paneli
    [HttpGet]
    public IActionResult Panel()
    {
        // Admin olup olmadığını kontrol et
        var admin = HttpContext.Session.GetString("Admin");
        if (admin != "true")
        {
            return RedirectToAction("AdminEntry");
        }

        //Veri tabanından mesajları çek

        var mesajlar = _context.Mesajlar.ToList();
        ViewBag.Mesajlar = mesajlar;
        return View(mesajlar);
    }

    //Çıkış yap
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Admin");
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult SubmitMesaj()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitMesaj(Mesaj mesaj)
    {
        if (ModelState.IsValid)
        {
            _context.Mesajlar.Add(mesaj);
            _context.SaveChanges();
            ViewBag.Basarili = "Mesajınız başarıyla gönderildi.";
            return View();
        }
        else
        {
            ViewBag.Hata = "Lütfen tüm alanları doğru doldurduğunuzdan emin olun.";
        }
        return View("Index");
    }

    //Hata sayfası
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
