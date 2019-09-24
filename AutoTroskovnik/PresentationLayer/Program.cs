using InfrastructureLayer.DataAcess.Repositories.Expense;
using InfrastructureLayer.DataAcess.Repositories.ExpenseType;
using InfrastructureLayer.DataAcess.Repositories.User;
using PresentationLayer.Presenters;
using PresentationLayer.Presenters.Common;
using PresentationLayer.Presenters.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.ExpenseService;
using ServiceLayer.Services.ExpenseTypeService;
using ServiceLayer.Services.UserService;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace PresentationLayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // EDIT: path to sqlite file (root of the project)
            string pathToSqliteFile = "C:/Users/Eni/Desktop/auto-troskovnik-projekt/AutoTroskovnik";


            IUnityContainer UnityC;
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            string _connectionString = "Data Source="
                + pathToSqliteFile
                + @"\AutoTroskovnik.sqlite; Version = 3;";

            UnityC = new UnityContainer()
                // views
                .RegisterType<IMainView, MainViewUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseDeleteView, ExpenseDeleteView>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseListViewUC, ExpenseListViewUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseTypeListViewUC, ExpenseTypeListViewUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IHeaderViewUC, HeaderViewUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseEditView, ExpenseEditView>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseTypeAddView, ExpenseTypeAddView>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseTypeEditView, ExpenseTypeEditView>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseAddView, ExpenseAddView>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseTypeDeleteView, ExpenseTypeDeleteView>(new ContainerControlledLifetimeManager())
                .RegisterType<ILoginViewUC, LoginViewUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IRegistrationViewUC, RegistrationViewUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IRootView, RootView>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseStatisticsViewUC, ExpenseStatisticsViewUC>(new ContainerControlledLifetimeManager())

                // repositories
                .RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(_connectionString))
                .RegisterType<IExpenseTypeRepository, ExpenseTypeRepository>(new InjectionConstructor(_connectionString))
                .RegisterType<IExpenseRepository, ExpenseRepository>(new InjectionConstructor(_connectionString))
                // services
                .RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseTypeService, ExpenseTypeService>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseService, ExpenseService>(new ContainerControlledLifetimeManager())
                // presenters
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseListPresenter, ExpenseListPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseTypeListPresenter, ExpenseTypeListPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IRootPresenter, RootPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IHeaderViewPresenter, HeaderViewPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ILoginPresenter, LoginPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IRegistrationPresenter, RegistrationPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IExpenseStatisticsPresenter, ExpenseStatisticsPresenter>(new ContainerControlledLifetimeManager())


                // session
                .RegisterType<ISession, Session>(new ContainerControlledLifetimeManager());




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IRootPresenter presenter = UnityC.Resolve<RootPresenter>();
            Application.Run((RootView)presenter.GetRootView());

        }
    }
}
