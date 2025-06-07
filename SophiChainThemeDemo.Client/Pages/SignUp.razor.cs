using Microsoft.AspNetCore.Components;

namespace SophiChainThemeDemo.Pages;
public partial class SignUp
{
    [Inject] NavigationManager navigationManager { get; set; }

    public string FormState { get; set; } = default!;
    public bool OTPSent { get; set; }

    
    private string Captcha = "";
    public string CaptchaInput = "";

    protected override Task OnInitializedAsync()
    {
        FormState = "password-login";

        return base.OnInitializedAsync();
    }
    

    private async Task LoginWithOtp()
    {
        FormState = "otp-login";
        await InvokeAsync(StateHasChanged);
    }

    private async Task LoginWithPassword()
    {
        FormState = "password-login";
        await InvokeAsync(StateHasChanged);
    }

    private async Task OnForgotPassword()
    {
        FormState = "reset-password";
        await InvokeAsync(StateHasChanged);
    }

    private async Task OnSendPasswordResetLink()
    {
        Alerts.Success("لینک بازیابی رمز عبور برای شما ارسال شد.");
    }
}
