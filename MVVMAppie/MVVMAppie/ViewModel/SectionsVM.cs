using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class SectionsVM : ViewModelBase
    {
        private List<Section> _sections;
        private Database database;

        public ObservableCollection<SectionVM> Sections
        {
            get
            {
                //geef een observable collection (soort list) terug van _sections
                return new ObservableCollection<SectionVM>(this._sections.Select(c => new SectionVM(c)).ToList());
            }
        }
        public SectionsVM(Database datab)
        {
            this.database = datab;
            this._sections = datab.SectionRepository.GetAll().ToList();
        }


        public void addSectionCommand(string TextIn)
        {
            //Create a new section
            Section section = new Section
            {
                Name = TextIn
            };

            //schrijf de section naar de db
            this.database.SectionRepository.Create(section);
            this.database.Save();

            //update de sections list
            this._sections = this.database.SectionRepository.GetAll().ToList();
            //Roep dat de property sections is veranderd
            RaisePropertyChanged("Sections");
        }
    }
}
