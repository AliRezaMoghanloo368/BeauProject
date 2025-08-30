using Microsoft.AspNetCore.Components;

namespace BeauComponents.Components.Controls
{
    public partial class BeauButton
    {
        [Parameter] public string? Name { get; set; }
        [Parameter] public string Title { get; set; } = "Button";
        [Parameter] public string? CssClass { get; set; }

        private string? _butttonStyle;
        private ButtonTypes? _buttonType;
        [Parameter] public ButtonTypes? Type 
        {
            get { return _buttonType; }
            set
            {
                _buttonType = value;
                switch(_buttonType)
                {   
                    case ButtonTypes.Primary:
                        _butttonStyle = "btn btn-primary";
                        break;
                    case ButtonTypes.Secondary:
                        _butttonStyle = "btn btn-secondary";
                        break;
                    case ButtonTypes.Success:
                        _butttonStyle = "btn btn-success";
                        break;
                    case ButtonTypes.Danger:
                        _butttonStyle = "btn btn-danger";
                        break;
                    case ButtonTypes.Warning:
                        _butttonStyle = "btn btn-warning";
                        break;
                    case ButtonTypes.Info:
                        _butttonStyle = "btn btn-info";
                        break;
                    case ButtonTypes.Light:
                        _butttonStyle = "btn btn-light";
                        break;
                    case ButtonTypes.Dark:
                        _butttonStyle = "btn btn-dark";
                        break;
                    case ButtonTypes.Link:
                        _butttonStyle = "btn btn-link";
                        break;
                }
            } 
        }
        [Parameter] public EventCallback OnClick { get; set; }
        [Parameter] public string? Style { get; set; }
        [Parameter] public string? IconClass { get; set; }

        public class Css
        {
            public string? Class { get; set; }
            public string? Style { get; set; }
        }

        public enum ButtonTypes
        {
            Primary, Secondary, Success, Danger, Warning, Info, Light, Dark, Link
        }
    }
}
