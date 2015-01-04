using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class SectionManageViewModel :ViewModelBase
    {
        //Dit viewmodel is puur en alleen om alle content in het section manage window te handelen. Alle objecten die hierin getoond zijn zijn andere viewmodels.
        //In dit viewmodel staan ook alle Button en textbox afhandelingen

        //variabelen
        private Database datab;
        private SectionsVM _sections;
        private SectionVM _selectedSection;
        
        //Variabele die de textbox text bijhoud
        private string _textIn;

        //Property om de sections op te vragen
        public SectionsVM Sections
        {
            get
            {
                //Dit is het SectionsVM
                return _sections;
            }
        }

        //Deze handeld de Text in property af. Bij elke verandering wordt er opgeslagen in _textIn en gezecht dat de property veranderd.
        public String TextIn
        {
            get
            {
                return _textIn;
                ;
            }

            set
            {
                _textIn = value;
                RaisePropertyChanged("TextIn");
            }
        }

        public SectionVM SelectedSection
        {
            get
            {
                return _selectedSection;
            }

            set
            {
                _selectedSection = value;
                RaisePropertyChanged("SelectedSection");
            }
        }

        //variabele die de add knop afhandeld
        public RelayCommand AddSectionCommand { get; set; }
        public RelayCommand DeleteSectionCommand { get; set; }

        private void Add()
        {
            //zegt tegen het sections viewmodel dat er een section moet worden aangemaakt.
            _sections.addSectionCommand(TextIn);
            TextIn = "";
        }

        private void Delete()
        {
            if(_selectedSection != null){
                _sections.deleteSectionCommand(_selectedSection.GetSection());
            }
        }

        //Constructor. De parameters worden door het IOC framework ingepusht. Daardoor loopt alles op 1 database object. En bestaan bepaalde viewmoddels maar 1x
        public SectionManageViewModel(Database datab, SectionsVM Sections)
        {
            this.datab = datab;
            this._sections = Sections;
            this.DeleteSectionCommand = new RelayCommand(Delete);
            this.AddSectionCommand = new RelayCommand(Add);
        }
    }
}
