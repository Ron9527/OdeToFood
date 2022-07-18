using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
//name should be same as folder of RetaurantCount, it's like Model-View-Controller
namespace OdeToFood.Pages.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        //seems like controller of mvc
        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();
            //like mvc needs to create a model and then pass the model to view
            return View(count);
        }
    }
}
