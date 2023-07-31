namespace LAtelier.Catmash.Api
{
    public static partial class Program
    {
        public static IServiceCollection AddOpenApiDocument(this IServiceCollection services)
        {
            services.AddOpenApiDocument(settings => {
                settings.XmlDocumentationFormatting = Namotion.Reflection.XmlDocsFormattingMode.Markdown;
            });

            return services;
        }
    }
}
