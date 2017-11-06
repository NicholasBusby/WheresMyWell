using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using Wheres_My_Well.Models;
using Xamarin.Forms.Xaml;

namespace Wheres_My_Well.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Filter : PopupPage
    {
        private IEnumerable<Well> availableWells;
        public Filter(IEnumerable<Well> availableWells)
        {
            InitializeComponent();
            this.availableWells = availableWells;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var wellNames = availableWells.Select(x => x.WellName).Distinct(StringComparer.OrdinalIgnoreCase).ToList<string>();
            var apis = availableWells.Select(x => x.FormattedAPINumber).Distinct(StringComparer.OrdinalIgnoreCase).ToList<string>();
            var operators = availableWells.Select(x => x.OperatorName).Distinct(StringComparer.OrdinalIgnoreCase).ToList<string>();
            var fieldNames = availableWells.Select(x => x.FieldName).Distinct(StringComparer.OrdinalIgnoreCase).ToList<string>();
            var counties = availableWells.Select(x => x.County).Distinct(StringComparer.OrdinalIgnoreCase).ToList<string>();
            WellNameAutoComplete.DataSource = wellNames;
            FormattedAPIAutoComplete.DataSource = apis;
            OperatorAutoComplete.DataSource = operators;
            FieldNameAutoComplete.DataSource = fieldNames;
            CountyAutoComplete.DataSource = counties.Take(11);
        }
    }
}