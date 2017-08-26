using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SQLite;
using sqllitesample.SQLite;
using sqllitesample.SQLite.SQLite;

namespace sqllitesample
{
    public partial class DrugDetailPage : ContentPage
    {
        public DrugDetailPage(string drugName, string drugDisease, string drugDosage, string drugSideEffect)
        {
            InitializeComponent();
            nameLabel.Text = drugName;
            diseaseLabel.Text = drugDisease;
            dosageLabel.Text = drugDosage;
            effectLabel.Text = drugSideEffect;
        }
    }
}
