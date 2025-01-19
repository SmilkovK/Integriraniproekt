using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using ProektService.Interface;
using System.Security.Claims;
using System.Text;

namespace Integriraniproekt.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;


        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = _orderService.GetAllOrdersForUser(userId);
            return View(orders);
        }
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _orderService.GetDetailsForOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        public IActionResult CreateInvoice(Guid? id)
        {
            HttpClient client = new HttpClient();

            var order = _orderService.GetDetailsForOrder(id);
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");
            var document = DocumentModel.Load(templatePath);

            document.Content.Replace("{{OrderNumber}}", order.Id.ToString());
            document.Content.Replace("{{FirstName}}", order.Owner.Email);
            StringBuilder sb = new StringBuilder();
            var total = 0;
            foreach (var item in order.FoodsInOrder)
            {
                sb.AppendLine("Product " + item.Foods.Name + " has quantity " + item.Quantity + " with price " + item.Foods.Price);
                total += (int)(item.Quantity * item.Foods.Price);
            }
            document.Content.Replace("{{ProductList}}", sb.ToString());
            document.Content.Replace("{{TotalPrice}}", total.ToString() + "$");

            var stream = new MemoryStream();
            document.Save(stream, new PdfSaveOptions());
            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }
    }
}
