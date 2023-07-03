
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberToWordscontroller : ControllerBase
    {
        [HttpPost]
        public IActionResult NumberToWordss([FromBody] long number)
        {
            string rotatedNumber = NumberToWords(number);
            return Ok(rotatedNumber);
        }

        private string NumberToWords(long number)
        {
            string[] units = { "", "մեկ", "երկու", "երեք", "չորս", "հինգ", "վեց", "յոթ", "ութ", "ինը" };
            string[] tens = { "", "տաս", "քսան", "երեսուն", "քառասուն", "հիսուն", "վաթսուն", "յոթանասուն", "ութսուն", "իննսուն", "հարյուր" };
            string[] counts = { "", "հարյուր", "հազար", "միլիոն ", "միլիարդ " };
            if (number < 0)
                return "մինուս" + " " + NumberToWords(-1 *number);
            if (number < 10)
                return (units[number]);
            if (number < 20 && number > 10)
                    return tens[number / 10] + "ն" + units[number % 10];

            if (number < 100)
                    return tens[number / 10] + " " + NumberToWords(number % 10);

            if (number < 1000)
                    return counts[1] + " " + NumberToWords(number % 100);

            if (number < 1000000)
            {
                if (number / 1000 == 1)
                    return counts[2] + " " + NumberToWords(number % 1000);
                else
                    return NumberToWords(number / 1000) + " " + counts[2] + " " + NumberToWords(number % 1000);
            }

            if (number < 1000000000)
            {
                if (number / 1000000 == 1)
                    return counts[3] + " " + NumberToWords(number % 1000000);
                else
                    return NumberToWords(number / 1000000) + " " + counts[3] + " " + NumberToWords(number % 1000000);
            }
            if (number / 1000000000 == 1)
                return counts[4] + " " + NumberToWords(number % 1000000000);
            else
                return NumberToWords(number / 1000000000) + " " + counts[4] + " " + NumberToWords(number % 1000000000);
            }
        }
}
