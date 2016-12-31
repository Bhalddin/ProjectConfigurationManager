﻿using System.Diagnostics;

namespace tomenglertde.ProjectConfigurationManager.View
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Windows.Input;

    using JetBrains.Annotations;

    using tomenglertde.ProjectConfigurationManager.Model;

    using TomsToolbox.Core;
    using TomsToolbox.Desktop;
    using TomsToolbox.Wpf;
    using TomsToolbox.Wpf.Composition;

    [DisplayName("Build Configuration")]
    [VisualCompositionExport(GlobalId.ShellRegion, Sequence = 1)]
    class BuildConfigurationViewModel : ObservableObject
    {
        [NotNull]
        private readonly Solution _solution;
        [NotNull]
        private readonly ICollection<ProjectConfiguration> _selectedConfigurations = new ObservableCollection<ProjectConfiguration>();

        [ImportingConstructor]
        public BuildConfigurationViewModel([NotNull] Solution solution)
        {
            Contract.Requires(solution != null);

            _solution = solution;
        }

        [NotNull]
        public Solution Solution
        {
            get
            {
                Contract.Ensures(Contract.Result<Solution>() != null);

                return _solution;
            }
        }

        public ICollection<ProjectConfiguration> SelectedConfigurations => _selectedConfigurations;

        public ICommand DeleteCommand => new DelegateCommand(CanDelete, Delete);

        private void Delete()
        {
            var configurations = _selectedConfigurations.ToArray();

            configurations.ForEach(c => c.Delete());

            _solution.Update();
        }

        private bool CanDelete()
        {
            var canEditAllFiles = _selectedConfigurations
                .Select(cfg => cfg.Project)
                .Distinct()
                .All(prj => prj.CanEdit());

            var shouldNotBuildAny = _selectedConfigurations
                .All(cfg => !cfg.ShouldBuildInAnyConfiguration());

            return _selectedConfigurations.Any()
                   && canEditAllFiles
                   && shouldNotBuildAny;
        }

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
        [Conditional("CONTRACTS_FULL")]
        private void ObjectInvariant()
        {
            Contract.Invariant(_solution != null);
            Contract.Invariant(_selectedConfigurations != null);
        }
    }
}
