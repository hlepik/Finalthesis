#pragma warning disable 1591

namespace WebApp.Helpers;

public class ConfigureModelBindingLocalization : IConfigureOptions<MvcOptions>
{
    public void Configure(MvcOptions options)
    {
        options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(value =>
            string.Format("Value {} is invalid", value));
    }
}