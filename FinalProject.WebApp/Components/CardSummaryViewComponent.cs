using FinalProject.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebApp.Components
{
    public class CardSummaryViewComponent : ViewComponent
    {
        private readonly Cart _cart;

        public CardSummaryViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public string Invoke()
        {
            return _cart.Lines.Count.ToString();
        }
    }
}
