using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MellowWoodProject.Localization
{
    public static class MellowWoodProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MellowWoodProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MellowWoodProjectLocalizationConfigurer).GetAssembly(),
                        "MellowWoodProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
