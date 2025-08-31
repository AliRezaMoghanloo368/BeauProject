using Microsoft.AspNetCore.Components;

namespace BeauProject.Shared.Classes
{
    public class PagesList
    {
        private NavigationManager _navigation;
        public PagesList(NavigationManager navigation)
        {
            _navigation = navigation;
        }
        public void GetForm(string code)
        {
            int.TryParse(code, out int codes);
            switch (codes)
            {
                //#region Inventory
                //case 1100:
                //    ProductsForm ProductsForm = new ProductsForm();
                //    ProductsForm.ShowForm(parent, showType);
                //    break;
                //case 1101:
                //    InventoriesForm InventoriesForm = new InventoriesForm();
                //    InventoriesForm.ShowForm(parent, showType);
                //    break;
                //#endregion

                //#region Accounting
                case 1200:
                    _navigation.NavigateTo("/accounts");
                    break;
                case 1201:
                    _navigation.NavigateTo("/salaries");
                    break;
                case 1202:
                    _navigation.NavigateTo("/Counter");
                    break;
            }
        }
    }
}
