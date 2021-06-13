using BookManager.MockDataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Services.Pdf.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var cartItems = DataStorage.GetAllCartItems();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF Invoic!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>Price</th>
                                        <th>Quantity</th>
                                        <th>LineTotal</th>
                                    </tr>");

            foreach (var item in cartItems)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", item.Isbn, item.Price, item.Quantity, item.CartItemTotal);
            }
            var total = cartItems.Sum(x => x.CartItemTotal);
            sb.Append(@" </table>");
            sb.Append(@$"<h3 class='totalAmount'>Total {total}</h3>");
            sb.Append(@"
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}
