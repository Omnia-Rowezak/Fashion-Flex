using Fashion_Flex.Models;
using Fashion_Flex.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fashion_Flex.Controllers
{
    public class PaymentController : Controller
    {
        List<SelectListItem> countryPhoneCodes = new List<SelectListItem>
            {
                new SelectListItem { Value = "+1", Text = "United States +1" },
                new SelectListItem { Value = "+44", Text = "United Kingdom +44" },
                new SelectListItem { Value = "+93", Text = "Afghanistan +93" },
                new SelectListItem { Value = "+355", Text = "Albania +355" },
                new SelectListItem { Value = "+213", Text = "Algeria +213" },
                new SelectListItem { Value = "+376", Text = "Andorra +376" },
                new SelectListItem { Value = "+244", Text = "Angola +244" },
                new SelectListItem { Value = "+54", Text = "Argentina +54" },
                new SelectListItem { Value = "+374", Text = "Armenia +374" },
                new SelectListItem { Value = "+61", Text = "Australia +61" },
                new SelectListItem { Value = "+43", Text = "Austria +43" },
                new SelectListItem { Value = "+994", Text = "Azerbaijan +994" },
                new SelectListItem { Value = "+973", Text = "Bahrain +973" },
                new SelectListItem { Value = "+880", Text = "Bangladesh +880" },
                new SelectListItem { Value = "+375", Text = "Belarus +375" },
                new SelectListItem { Value = "+32", Text = "Belgium +32" },
                new SelectListItem { Value = "+501", Text = "Belize +501" },
                new SelectListItem { Value = "+229", Text = "Benin +229" },
                new SelectListItem { Value = "+975", Text = "Bhutan +975" },
                new SelectListItem { Value = "+591", Text = "Bolivia +591" },
                new SelectListItem { Value = "+387", Text = "Bosnia and Herzegovina +387" },
                new SelectListItem { Value = "+267", Text = "Botswana +267" },
                new SelectListItem { Value = "+55", Text = "Brazil +55" },
                new SelectListItem { Value = "+359", Text = "Bulgaria +359" },
                new SelectListItem { Value = "+226", Text = "Burkina Faso +226" },
                new SelectListItem { Value = "+257", Text = "Burundi +257" },
                new SelectListItem { Value = "+855", Text = "Cambodia +855" },
                new SelectListItem { Value = "+237", Text = "Cameroon +237" },
                new SelectListItem { Value = "+1", Text = "Canada +1" },
                new SelectListItem { Value = "+238", Text = "Cape Verde +238" },
                new SelectListItem { Value = "+236", Text = "Central African Republic +236" },
                new SelectListItem { Value = "+235", Text = "Chad +235" },
                new SelectListItem { Value = "+56", Text = "Chile +56" },
                new SelectListItem { Value = "+86", Text = "China +86" },
                new SelectListItem { Value = "+57", Text = "Colombia +57" },
                new SelectListItem { Value = "+269", Text = "Comoros +269" },
                new SelectListItem { Value = "+243", Text = "Congo (DRC) +243" },
                new SelectListItem { Value = "+242", Text = "Congo (Republic) +242" },
                new SelectListItem { Value = "+506", Text = "Costa Rica +506" },
                new SelectListItem { Value = "+385", Text = "Croatia +385" },
                new SelectListItem { Value = "+53", Text = "Cuba +53" },
                new SelectListItem { Value = "+357", Text = "Cyprus +357" },
                new SelectListItem { Value = "+420", Text = "Czech Republic +420" },
                new SelectListItem { Value = "+45", Text = "Denmark +45" },
                new SelectListItem { Value = "+253", Text = "Djibouti +253" },
                new SelectListItem { Value = "+1", Text = "Dominica +1" },
                new SelectListItem { Value = "+1", Text = "Dominican Republic +1" },
                new SelectListItem { Value = "+593", Text = "Ecuador +593" },
                new SelectListItem { Value = "+20", Text = "Egypt +20" },
                new SelectListItem { Value = "+503", Text = "El Salvador +503" },
                new SelectListItem { Value = "+240", Text = "Equatorial Guinea +240" },
                new SelectListItem { Value = "+291", Text = "Eritrea +291" },
                new SelectListItem { Value = "+372", Text = "Estonia +372" },
                new SelectListItem { Value = "+251", Text = "Ethiopia +251" },
                new SelectListItem { Value = "+358", Text = "Finland +358" },
                new SelectListItem { Value = "+33", Text = "France +33" },
                new SelectListItem { Value = "+241", Text = "Gabon +241" },
                new SelectListItem { Value = "+220", Text = "Gambia +220" },
                new SelectListItem { Value = "+995", Text = "Georgia +995" },
                new SelectListItem { Value = "+49", Text = "Germany +49" },
                new SelectListItem { Value = "+233", Text = "Ghana +233" },
                new SelectListItem { Value = "+350", Text = "Gibraltar +350" },
                new SelectListItem { Value = "+30", Text = "Greece +30" },
                new SelectListItem { Value = "+502", Text = "Guatemala +502" },
                new SelectListItem { Value = "+224", Text = "Guinea +224" },
                new SelectListItem { Value = "+245", Text = "Guinea-Bissau +245" },
                new SelectListItem { Value = "+592", Text = "Guyana +592" },
                new SelectListItem { Value = "+509", Text = "Haiti +509" },
                new SelectListItem { Value = "+504", Text = "Honduras +504" },
                new SelectListItem { Value = "+852", Text = "Hong Kong +852" },
                new SelectListItem { Value = "+36", Text = "Hungary +36" },
                new SelectListItem { Value = "+354", Text = "Iceland +354" },
                new SelectListItem { Value = "+91", Text = "India +91" },
                new SelectListItem { Value = "+62", Text = "Indonesia +62" },
                new SelectListItem { Value = "+98", Text = "Iran +98" },
                new SelectListItem { Value = "+964", Text = "Iraq +964" },
                new SelectListItem { Value = "+353", Text = "Ireland +353" },
                new SelectListItem { Value = "+972", Text = "Israel +972" },
                new SelectListItem { Value = "+39", Text = "Italy +39" },
                new SelectListItem { Value = "+81", Text = "Japan +81" },
                new SelectListItem { Value = "+962", Text = "Jordan +962" },
                new SelectListItem { Value = "+7", Text = "Kazakhstan +7" },
                new SelectListItem { Value = "+254", Text = "Kenya +254" },
                new SelectListItem { Value = "+686", Text = "Kiribati +686" },
                new SelectListItem { Value = "+383", Text = "Kosovo +383" },
                new SelectListItem { Value = "+965", Text = "Kuwait +965" },
                new SelectListItem { Value = "+996", Text = "Kyrgyzstan +996" },
                new SelectListItem { Value = "+856", Text = "Laos +856" },
                new SelectListItem { Value = "+371", Text = "Latvia +371" },
                new SelectListItem { Value = "+961", Text = "Lebanon +961" },
                new SelectListItem { Value = "+231", Text = "Liberia +231" },
                new SelectListItem { Value = "+218", Text = "Libya +218" },
                new SelectListItem { Value = "+423", Text = "Liechtenstein +423" },
                new SelectListItem { Value = "+370", Text = "Lithuania +370" },
                new SelectListItem { Value = "+352", Text = "Luxembourg +352" },
        };
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        public PaymentController(IPaymentRepository paymentRepository, IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }
        
        public IActionResult Index()
        {
            var payment = _paymentRepository.GetAll();
            return View(payment);
        }
		[HttpGet]
		public IActionResult NewPayment()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult NewPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                _paymentRepository.Add(payment);
                _paymentRepository.Save();
                return RedirectToAction("Index");
            }

            return View("New", payment);
        }
        public IActionResult Details(int id)
        {
            var payment = _paymentRepository.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }
        [HttpPost]
        public IActionResult SaveEditedPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                _paymentRepository.Update(payment);
                _paymentRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Edit", payment);
        }
        public IActionResult Delete(int id)
        {
            var payment = _paymentRepository.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }

            _paymentRepository.Delete(id);
            _paymentRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CheckOut()
        {

            return View();
        }



        public IActionResult OrderConfirmation(int paymentid, int orderid)
        {
            _paymentRepository.updatePaymentStates(paymentid);
            _orderRepository.updateOrderStates(orderid);
            Order order = _orderRepository.GetOrderById(orderid);
            Payment payment = _paymentRepository.GetById(paymentid);
            _paymentRepository.Save();
            _orderRepository.Save();
            if(order.Order_Status.ToLower() == "complete" && payment.Payment_Status.ToLower() == "paid")
            {
                return View("Successful", orderid);
            }
            else
            {
                return View("Faild", orderid);
            }
        }



    }
}

