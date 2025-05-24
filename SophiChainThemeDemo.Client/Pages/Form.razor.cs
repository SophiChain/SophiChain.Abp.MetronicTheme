using System.ComponentModel.DataAnnotations;
using SophiChainThemeDemo.Extensions;
using Telerik.Blazor.Components;
using Telerik.Windows.Documents.Fixed.Model.Navigation;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;

namespace SophiChainThemeDemo.Pages;
public partial class Form
{
    public PageToolbar PageToolbar { get; set; } = new PageToolbar();
    private bool IsLoading { get; set; }
    public string? IsLoadingText { get; set; }
    public class FormDto
    {
        public string Name { get; set; } = default!;
        public string Phone { get; set; } = "09122613278";
    };

    private FormDto FormData { get; set; } = new FormDto();
    private TelerikForm FormDataRef { get; set; }

    public class DestinationDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    public string TypeSelectedDestination { get; set; }
    public string SelectedDestination { get; set; }
    public int SingleSelectedDestinationId { get; set; }
    public int SingleFilterSelectedDestinationId { get; set; }

    private bool AllowNotifications { get; set; } = true;

    public List<int> SelectedHobbyIds { get; set; }

    private int IntValue = default!;

    public string PhoneNumber { get; set; }

    public string PersonalDescription { get; set; }

    public string PromptString { get; set; } = "*";

    public char PromptChar => string.IsNullOrEmpty(PromptString) ? '_' : PromptString[0];

    public enum CommunicationType
    {
        Phone,
        Email,
        None
    }

    public class CommunicationTypeModel
    {
        public string Text { get; set; }
        public CommunicationType Value { get; set; }

        public CommunicationTypeModel()
        {
        }
    }

    public CommunicationType SelectedCommunicationType { get; set; } = CommunicationType.Phone;
    public List<CommunicationTypeModel> CommunicationTypes { get; set; } = new List<CommunicationTypeModel>()
    {
        new CommunicationTypeModel() { Text = "پیامک", Value = CommunicationType.Phone },
        new CommunicationTypeModel() { Text = "ایمیل", Value = CommunicationType.Email },
        new CommunicationTypeModel() { Text = "هیچکدام", Value = CommunicationType.None }
    };

    public IEnumerable<DestinationDto> MultiDestinationsData { get; set; } = new List<DestinationDto>()
    {
        new DestinationDto()
        {
            Id = 1,
            Title = "تهران"
        },
        new DestinationDto()
        {
            Id = 2,
            Title = "کرج"
        },
        new DestinationDto()
        {
            Id = 3,
            Title = "کیش"
        },
    };

    public IEnumerable<DestinationDto> TypeDestinationsData { get; set; } = new List<DestinationDto>()
    {
        new DestinationDto()
        {
            Id = 1,
            Title = "تهران"
        },
        new DestinationDto()
        {
            Id = 2,
            Title = "کرج"
        },
        new DestinationDto()
        {
            Id = 3,
            Title = "کیش"
        },
    };

    public IEnumerable<DestinationDto> SingleDestinationsData { get; set; } = new List<DestinationDto>()
    {
        new DestinationDto()
        {
            Id = 1,
            Title = "تهران"
        },
        new DestinationDto()
        {
            Id = 2,
            Title = "کرج"
        },
        new DestinationDto()
        {
            Id = 3,
            Title = "کیش"
        },
    };

    public IEnumerable<DestinationDto> SingleFilterDestinationsData { get; set; } = new List<DestinationDto>()
    {
        new DestinationDto()
        {
            Id = 1,
            Title = "تهران"
        },
        new DestinationDto()
        {
            Id = 2,
            Title = "کرج"
        },
        new DestinationDto()
        {
            Id = 3,
            Title = "کیش"
        },
    };

    public bool SelectAllValue { get; set; }
    public DateTime? selectedTime { get; set; } = DateTime.Now.Date.AddHours(7).AddMinutes(45);
    public DateTime? timeSelectedTime { get; set; } = DateTime.Now;

    public DateTime DateValue { get; set; }
    public DateTime MinDate { get; set; } = DateTime.Now;

    public DateTime dateFirst { get; set; } = DateTime.Now;
    public DateTime dateLast { get; set; } = DateTime.Now;

    IReadOnlyList<DateTime?> selectedDates;

    protected override async Task OnInitializedAsync()
    {
        GetToolbar();

        await base.OnInitializedAsync();
    }

    private void GetToolbar()
    {
        PageToolbar!.AddTPMButton("سبد خرید", "fa-duotone fa-solid fa-shopping-cart", "primary", "kt_drawer_cart_toggle");
        PageToolbar!.AddTPMButton("فیلترها", "fa-duotone fa-solid fa-filter", "secondary", "kt_drawer_filters_toggle");
        PageToolbar!.AddTPMButton("مدیریت", "icon-accounts-management-solid", "light", "kt_drawer_filters_toggle", enabled: false, href: "/");
    }

    private void ValueChanged(bool value)
    {
        SelectAllValue = !value;
    }
}
