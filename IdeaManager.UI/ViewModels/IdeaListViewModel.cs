using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaListViewModel : ObservableObject
    {
        private IIdeaService _ideaService;

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            Ideas = new ObservableCollection<Idea>();
            errorMessage = string.Empty;
            _ideaService.GetAllAsync().ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    foreach (var idea in task.Result)
                    {
                        Ideas.Add(idea);
                    }
                } else
                {
                    ErrorMessage = task.Exception?.Message ?? "Une erreur est survenue lors de la récupération des idées.";
                }
            });
        }
        public ObservableCollection<Idea> Ideas { get; private set; }

        [ObservableProperty]
        private string errorMessage;
    }
}
