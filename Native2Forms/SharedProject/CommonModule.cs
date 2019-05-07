using Autofac;
using Phoneword.SharedProject.Views;

namespace Phoneword.SharedProject
{
    class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PhonewordPage>().AsSelf();
        }
    }
}
