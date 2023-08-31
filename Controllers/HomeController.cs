using intervie.Models;
using intervie.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace intervie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string data) {

            MatchCollection m=Regex.Matches(data, "([0-9]+)");
            int[] send=new int[m.Count];
            for (int i = 0; i < m.Count; i++) {
                send[i] = Convert.ToInt32(m[i].Value);

            }
            return Content($"Сумма всех вторых нечётных чисел= {OddSum.sum_odd(send)}"); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Privacy(string data)
        {
            if (PalindromeCheck.palindrom(data)) {
                return Content($"Строка является палиндромом");
            }
            else return Content($"Строка не является палиндромом или неправильного типа");
        }



        public IActionResult Text()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Text(string data)
        {

            MatchCollection m = Regex.Matches(data, "([0-9]+)");
            ArrayListImpl arrayList = new ArrayListImpl();
            for (int i = 0; i < m.Count; i++)
            {
                arrayList.Add(Convert.ToInt32(m[i].Value));

            }
            arrayList=MergeSort.MergeSortImpl(arrayList);
            data = "";
            for (int i = 0; i < arrayList.Size; i++) {
                data +=arrayList.GetIntAt(i).ToString()+" ";
            }
            return Content($"Отсортированный массив = {data}");

            //return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





    }
}