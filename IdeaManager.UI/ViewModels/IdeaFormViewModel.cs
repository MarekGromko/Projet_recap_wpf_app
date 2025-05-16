using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaFormViewModel : ObservableObject, IDataErrorInfo
    {
        private readonly IIdeaService _ideaService;
        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string errorMessage;

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Title):
                        if (string.IsNullOrWhiteSpace(Title))
                            error = "Le \"Titre\" est nécéssaire.";
                        break;
                }
                return error;
            }
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            try
            {
                var idea = new Idea
                {
                    Title = Title,
                    Description = Description
                };

                await _ideaService.SubmitIdeaAsync(idea);
                ErrorMessage = string.Empty;
                App.MainWindow.DataContext = App.ServiceProvider.GetService(typeof(IdeaListViewModel));
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
            }
        }
    }
}
