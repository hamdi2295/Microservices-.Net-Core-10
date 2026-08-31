using MySchool.Routes;

namespace MySchool.Features.Students
{
    public static class StudentRoutes
    {
        public const string Base = $"{RoutesConfig.Prefix}/students";
        public const string GetById = $"{Base}/{{id:long}}";
        public const string Create = $"{Base}";
        public const string Update = $"{Base}";
    }
}
